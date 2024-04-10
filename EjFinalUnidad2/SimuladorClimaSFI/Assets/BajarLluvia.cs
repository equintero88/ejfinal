using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

enum TaskStateLluviaBajar
{
    INIT,
    COMMANDS
}

public class BajarLluvia : MonoBehaviour
{
    private static TaskStateLluviaBajar taskState = TaskStateLluviaBajar.INIT;
    private SerialPort _serialPort = new SerialPort();
    private byte[] buffer = new byte[32];
    public TextMeshProUGUI myText;
    void Start()
    {
        try
        {
            _serialPort.PortName = "COM5";
            _serialPort.BaudRate = 115200;
            _serialPort.DtrEnable = true;
            _serialPort.Open();
            Debug.Log("Open Serial Port");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al abrir el puerto COM: " + ex.Message);
        }
    }

    public void BajarNivel()
    {
        switch (taskState)
        {
            case TaskStateLluviaBajar.INIT:
                taskState = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("rainDown\n");
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
