using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using TMPro;
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
    public TextMeshProUGUI myText;

    void Start()
    {
        _serialPort.PortName = "COM5";
        _serialPort.BaudRate = 115200;
        _serialPort.DtrEnable = true;
        //_serialPort.Open();
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
                    _serialPort.Write("rainUp\n");
                    Debug.Log("Send ledON");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _serialPort.Write("rainDown\n");
                    Debug.Log("Send ledOFF");
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _serialPort.Write("timeUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _serialPort.Write("timeDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    _serialPort.Write("tempUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    _serialPort.Write("tempDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    _serialPort.Write("tempSpeedUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _serialPort.Write("tempSpeedDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    _serialPort.Write("rainSpeedUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    _serialPort.Write("rainSpeedDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    _serialPort.Write("tempUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    _serialPort.Write("tempDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    _serialPort.Write("rainUp\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    _serialPort.Write("rainDown\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    _serialPort.Write("out\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    _serialPort.Write("in\n");
                    Debug.Log("Send readBUTTONS");
                }
                if (_serialPort.BytesToRead > 0)
                {
                    string response = _serialPort.ReadLine();
                    myText.text = response;
                }
                break;
            default:
                Debug.Log("State Error");
                break;
        }
    }
}

