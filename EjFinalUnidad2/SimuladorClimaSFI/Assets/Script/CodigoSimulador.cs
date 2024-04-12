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
                if (Input.GetKeyDown(KeyCode.D))
                {
                    bajarTemperatura();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AumentoLluvia();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    DecrementoLluvia();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    AumentoVelocidadLluvia();
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    DecrementoVelocidadLluvia();
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    AumentoTiempo();
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    DecrementoTiempo();
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    SubirVelocidadTemperatura();
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    BajarVelocidadTemperatura();
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

    public void AumentoLluvia()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("rainIncrease\n");
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
    public void DecrementoLluvia()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("rainDecrease\n");
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

    public void AumentoVelocidadLluvia()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("rainSpeedUp\n");
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

    public void DecrementoVelocidadLluvia()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("rainSpeedDown\n");
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

    public void AumentoTiempo()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("timeUp\n");
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

    public void DecrementoTiempo()
    {
        switch (taskState2)
        {
            case TaskStateLluviaBajar.INIT:
                taskState2 = TaskStateLluviaBajar.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateLluviaBajar.COMMANDS:
                _serialPort.Write("timeDown\n");
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
    public void SubirVelocidadTemperatura()
    {
        switch (taskState3)
        {
            case TaskStateTemperaturaSubir.INIT:
                taskState3 = TaskStateTemperaturaSubir.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateTemperaturaSubir.COMMANDS:
                _serialPort.Write("tempSpeedUp\n");
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
    public void BajarVelocidadTemperatura()
    {
        switch (taskState3)
        {
            case TaskStateTemperaturaSubir.INIT:
                taskState3 = TaskStateTemperaturaSubir.COMMANDS;
                Debug.Log("WAIT COMMANDS");
                break;
            case TaskStateTemperaturaSubir.COMMANDS:
                _serialPort.Write("tempSpeedDown\n");
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

