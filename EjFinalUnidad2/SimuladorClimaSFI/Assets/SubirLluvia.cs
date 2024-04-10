using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

enum TaskStateLluviaSubir
{
    INIT,
    COMMANDS
}

public class SubirLluvia : MonoBehaviour
{
    private static TaskStateLluviaSubir taskState = TaskStateLluviaSubir.INIT;
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

    public void SubirNivel()
    {
        switch (taskState)
        {
            case TaskStateLluviaSubir.INIT:
                taskState = TaskStateLluviaSubir.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaSubir.COMMANDS:
                _serialPort.Write("rainUp\n");
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
