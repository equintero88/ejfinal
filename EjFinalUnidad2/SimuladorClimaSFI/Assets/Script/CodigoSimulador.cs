using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using UnityEngine;

enum TaskState
{
    INIT,
    COMMANDS
}

public class CodigoSimulador : MonoBehaviour
{
    private static TaskState taskState = TaskState.INIT;
    private SerialPort _serialPort = new SerialPort();
    private byte[] buffer = new byte[32];
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;

    void Start()
    {
        _serialPort.PortName = "COM5";
        _serialPort.BaudRate = 115200;
        _serialPort.DtrEnable = true;
        _serialPort.Open();
        Debug.Log("Open Serial Port");
        material = GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        switch (taskState)
        {
            case TaskState.INIT:
                taskState = TaskState.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskState.COMMANDS:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    _serialPort.Write("ledON\n");
                    Debug.Log("Send ledON");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _serialPort.Write("ledOFF\n");
                    Debug.Log("Send ledOFF");
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    _serialPort.Write("readBUTTONS\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (_serialPort.BytesToRead > 0)
                {
                    string response = _serialPort.ReadLine();
                    Debug.Log(response);
                }
                break;
            default:
                Debug.Log("State Error");
                break;
        }
    }
}

