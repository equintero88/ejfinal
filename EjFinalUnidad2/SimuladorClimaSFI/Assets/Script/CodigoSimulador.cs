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
enum TaskStateLluviaSubir
{
    INIT,
    COMMANDS
}

enum TaskStateLluviaBajar
{
    INIT,
    COMMANDS
}

enum TaskStateTemperaturaSubir
{
    INIT,
    COMMANDS
}

enum TaskStateTemperaturaBajar
{
    INIT,
    COMMANDS
}

public class CodigoSimulador : MonoBehaviour
{
    private static TaskState taskState = TaskState.INIT;
    private static TaskStateLluviaSubir taskState1 = TaskStateLluviaSubir.INIT;
    private static TaskStateLluviaBajar taskState2 = TaskStateLluviaBajar.INIT;
    private static TaskStateTemperaturaSubir taskState3 = TaskStateTemperaturaSubir.INIT;
    private static TaskStateTemperaturaBajar taskState4 = TaskStateTemperaturaBajar.INIT;
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
                    SubirLluvia();
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    BajarLluvia();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    SubirTemperatura();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bajarTemperatura();
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

    public void SubirLluvia()
    {
        switch (taskState1)
        {
            case TaskStateLluviaSubir.INIT:
                taskState1 = TaskStateLluviaSubir.COMMANDS;
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
    public void BajarLluvia()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
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

    public void SubirTemperatura()
    {
        switch (taskState3)
        {
            case TaskStateTemperaturaSubir.INIT:
                taskState3 = TaskStateTemperaturaSubir.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateTemperaturaSubir.COMMANDS:
                _serialPort.Write("tempUp\n");
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
    public void bajarTemperatura()
    {
        switch (taskState4)
        {
            case TaskStateTemperaturaBajar.INIT:
                taskState4 = TaskStateTemperaturaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateTemperaturaBajar.COMMANDS:
                _serialPort.Write("tempDown\n");
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

