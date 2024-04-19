using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using System;

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

enum StateEscenas
{
    INIT,
    NOLLUVIA,
    LLOVIZNA,
    LLUVIACONSTANTE,
    AGUACERO
}
public class CodigoSimulador : MonoBehaviour
{
    private static TaskState taskState = TaskState.INIT;
    private static TaskStateLluviaSubir taskState1 = TaskStateLluviaSubir.INIT;
    private static TaskStateLluviaBajar taskState2 = TaskStateLluviaBajar.INIT;
    private static TaskStateTemperaturaSubir taskState3 = TaskStateTemperaturaSubir.INIT;
    private static TaskStateTemperaturaBajar taskState4 = TaskStateTemperaturaBajar.INIT;
    private static StateEscenas stateEscenas = StateEscenas.INIT;
    private SerialPort _serialPort = new SerialPort();
    private byte[] buffer = new byte[32];
    [SerializeField] private Vector2 velocidadMovimiento;
    public TextMeshProUGUI myText;
    public Scene escena;

    void Start()
    {
        _serialPort.PortName = "COM5";
        _serialPort.BaudRate = 115200;
        _serialPort.DtrEnable = true;
        _serialPort.Open();
        Debug.Log("Open Serial Port");
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
                if (_serialPort.BytesToRead > 0)
                {
                    string response = _serialPort.ReadLine();
                    myText.text = response;
                    if(response == "cambioHora") {
                        CambioHora();
                    }
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
    public void IniciarEscena()
    {
        switch (stateEscenas)
        {
            case StateEscenas.INIT:
                _serialPort.Write("estadoLluvia\n");
                string respuesta = _serialPort.ReadLine();
                if (respuesta == "0") {
                    stateEscenas = StateEscenas.NOLLUVIA;
                    Debug.Log("NOLLUVIA");
                }
                if (respuesta == "1")
                {
                    stateEscenas = StateEscenas.LLOVIZNA;
                    Debug.Log("LLOVIZNA");
                }
                if (respuesta == "2")
                {
                    stateEscenas = StateEscenas.LLUVIACONSTANTE;
                    Debug.Log("LLUVIACONSTANTE");
                }
                if (respuesta == "3")
                {
                    stateEscenas = StateEscenas.AGUACERO;
                    Debug.Log("AGUACERO");
                }

                break;
            case StateEscenas.NOLLUVIA:
                _serialPort.Write("estadoTemp\n");
                string resp = _serialPort.ReadLine();
                 int temperatura = Int32.Parse(resp);
                if (temperatura >= 14 && temperatura <= 20)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >=  6 && hora <= 18)
                    {
                        SceneManager.LoadScene("NoLluviaFrio");
                    }
                    else
                    {
                        SceneManager.LoadScene("NoLluviaFrio");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura > 20 && temperatura <= 26)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("NoLluviaTemplado");
                    }
                    else
                    {
                        SceneManager.LoadScene("NoLluviaTemplado");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura > 26 && temperatura <= 32)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("NoLluviaCaluroso");
                    }
                    else
                    {
                        SceneManager.LoadScene("NoLluviaCaluroso");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                break;
            case StateEscenas.LLOVIZNA:
                _serialPort.Write("estadoTemp\n");
                string resp1 = _serialPort.ReadLine();
                int temperatura1 = Int32.Parse(resp1);
                if (temperatura1 >= 14 && temperatura1 <= 20)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LloviznaFrio");
                    }
                    else
                    {
                        SceneManager.LoadScene("LloviznaFrio");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura1 > 20 && temperatura1 <= 26)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LloviznaTemplado");
                    }
                    else
                    {
                        SceneManager.LoadScene("LloviznaTemplado");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura1 > 26 && temperatura1 <= 32)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LloviznaCaluroso");
                    }
                    else
                    {
                        SceneManager.LoadScene("LloviznaCaluroso");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                break;
            case StateEscenas.LLUVIACONSTANTE:
                _serialPort.Write("estadoTemp\n");
                string resp2 = _serialPort.ReadLine();
                int temperatura2 = Int32.Parse(resp2);
                if (temperatura2 >= 14 && temperatura2 <= 20)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaConstanteFrio");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaConstanteFrio");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura2 > 20 && temperatura2 <= 26)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaConstanteTemplado");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaConstanteTemplado");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura2 > 26 && temperatura2 <= 32)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaConstanteCaluroso");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaConstanteCaluroso");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                break;
            case StateEscenas.AGUACERO:
                _serialPort.Write("estadoTemp\n");
                string resp3 = _serialPort.ReadLine();
                int temperatura3 = Int32.Parse(resp3);
                if (temperatura3 >= 14 && temperatura3 <= 20)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaFuerteFrio");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaFuerteFrio");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura3 > 20 && temperatura3 <= 26)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaFuerteTemplado");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaFuerteTemplado");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                if (temperatura3 > 26 && temperatura3 <= 32)
                {
                    string response = _serialPort.ReadLine();
                    int hora = Int32.Parse(response);
                    if (hora >= 6 && hora <= 18)
                    {
                        SceneManager.LoadScene("LluviaFuerteCaluroso");
                    }
                    else
                    {
                        SceneManager.LoadScene("LluviaFuerteCaluroso");            //cambiar si hay otra escena dependiendo de la hora
                    }
                }
                break;
            default:
                Debug.Log("State Error");
                break;
        }

        _serialPort.Write("start\n");
        
        if (_serialPort.BytesToRead > 0)
        {
            string response = _serialPort.ReadLine();
            myText.text = response;
        }

    }

    public void CambioHora()
    {
        Scene escenaActual  = SceneManager.GetActiveScene();
        if(escenaActual.name == "NoLluviaFrio")
        {
            SceneManager.LoadScene("NoLluviaFrio"); //cambiar por el nombre de la escena de noche
        }
        if (escenaActual.name == "NoLluviaFrio") //cambiar por el nombre de la escena de noche
        {
            SceneManager.LoadScene("NoLluviaFrio"); 
        }
    }
}

