using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTermometro : MonoBehaviour
{


    public enum OpcionTemperatura
    {
        Frio,
        Templado,
        Tropical,
        Caluroso
    }

    public OpcionTemperatura opcionSeleccionada;

    // M�todo para obtener la opci�n de temperatura seleccionada por el usuario
    public OpcionTemperatura ObtenerOpcionSeleccionada()
    {
        return opcionSeleccionada;
    }


public Slider slider; // Referencia al slider que controla el llenado del term�metro
    public float velocidadLlenado = 1f; // Velocidad de llenado del term�metro
    public KeyCode teclaDetener = KeyCode.Space; // Tecla para detener el llenado del term�metro

    private bool llenando = true;
    private bool detenido = false;

    void Update()
    {
        // Detener el llenado al presionar la tecla especificada
        if (Input.GetKeyDown(teclaDetener))
        {
            detenido = true;
        }

        if (!detenido)
        {
            if (llenando)
            {
                // Incrementar el valor del slider para simular el llenado del term�metro
                slider.value += Time.deltaTime * velocidadLlenado;

                // Si el slider alcanza el valor m�ximo, invertir la direcci�n del llenado
                if (slider.value >= slider.maxValue)
                {
                    slider.value = slider.maxValue;
                    llenando = false;
                }
            }
            else
            {
                // Decrementar el valor del slider para simular el vaciado del term�metro
                slider.value -= Time.deltaTime * velocidadLlenado;

                // Si el slider alcanza el valor m�nimo, reiniciar el llenado
                if (slider.value <= slider.minValue)
                {
                    slider.value = slider.minValue;
                    llenando = true;
                }
            }
        }
    }
}
