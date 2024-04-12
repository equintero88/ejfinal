using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ControladorTermometro;
using static NewBehaviourScript;

public class BotonConfirmacion : MonoBehaviour
{
    public NewBehaviourScript newBehaviourScript;
    public ControladorTermometro controladorTermometro;

    public void OnClickConfirmar()
    {
        // Obtener las opciones seleccionadas por el usuario de los controladores de lluvia y temperatura
        OpcionLluvia opcionLluvia = newBehaviourScript.ObtenerOpcionSeleccionada();
        OpcionTemperatura opcionTemperatura = controladorTermometro.ObtenerOpcionSeleccionada();

        // Determinar la escena correspondiente según las opciones seleccionadas
        string nombreEscena = "";

        switch (opcionLluvia)
        {
            case OpcionLluvia.SinLluvia:
                switch (opcionTemperatura)
                {
                    case OpcionTemperatura.Frio:
                        nombreEscena = "SinLluviaFrio";
                        break;
                    case OpcionTemperatura.Templado:
                        nombreEscena = "EscenaSinLluviaTemplado";
                        break;
                    case OpcionTemperatura.Tropical:
                        nombreEscena = "EscenaSinLluviaTropical";
                        break;
                    case OpcionTemperatura.Caluroso:
                        nombreEscena = "EscenaSinLluviaCaluroso";
                        break;
                }
                break;

            case OpcionLluvia.Llovizna:
                switch (opcionTemperatura)
                {
                    case OpcionTemperatura.Frio:
                        nombreEscena = "EscenaLloviznaFrio";
                        break;
                    case OpcionTemperatura.Templado:
                        nombreEscena = "EscenaLloviznaTemplado";
                        break;
                    case OpcionTemperatura.Tropical:
                        nombreEscena = "EscenaLloviznaTropical";
                        break;
                    case OpcionTemperatura.Caluroso:
                        nombreEscena = "EscenaLloviznaCaluroso";
                        break;
                }
                break;

            case OpcionLluvia.LluviaConstante:
                switch (opcionTemperatura)
                {
                    case OpcionTemperatura.Frio:
                        nombreEscena = "EscenaLluviaConstanteFrio";
                        break;
                    case OpcionTemperatura.Templado:
                        nombreEscena = "EscenaLluviaConstanteTemplado";
                        break;
                    case OpcionTemperatura.Tropical:
                        nombreEscena = "EscenaLluviaConstanteTropical";
                        break;
                    case OpcionTemperatura.Caluroso:
                        nombreEscena = "EscenaLluviaConstanteCaluroso";
                        break;
                }
                break;

            case OpcionLluvia.LluviaFuerte:
                switch (opcionTemperatura)
                {
                    case OpcionTemperatura.Frio:
                        nombreEscena = "EscenaLluviaFuerteFrio";
                        break;
                    case OpcionTemperatura.Templado:
                        nombreEscena = "EscenaLluviaFuerteTemplado";
                        break;
                    case OpcionTemperatura.Tropical:
                        nombreEscena = "EscenaLluviaFuerteTropical";
                        break;
                    case OpcionTemperatura.Caluroso:
                        nombreEscena = "EscenaLluviaFuerteCaluroso";
                        break;
                }
                break;
        }

        if (!string.IsNullOrEmpty(nombreEscena))
        {
            Debug.Log("Cargando escena: " + nombreEscena);
            SceneManager.LoadScene(nombreEscena); // Esta línea carga la escena
        }
        else
        {
            Debug.LogError("No se pudo determinar la escena correspondiente.");
        }
    }
}

