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

    // Método para obtener la opción de temperatura seleccionada por el usuario
    public OpcionTemperatura ObtenerOpcionSeleccionada()
    {
        return opcionSeleccionada;
    }


public Slider slider; // Referencia al slider que controla el llenado del termómetro
    public float velocidadLlenado = 1f; // Velocidad de llenado del termómetro
    public KeyCode teclaDetener = KeyCode.Space; // Tecla para detener el llenado del termómetro

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
                // Incrementar el valor del slider para simular el llenado del termómetro
                slider.value += Time.deltaTime * velocidadLlenado;

                // Si el slider alcanza el valor máximo, invertir la dirección del llenado
                if (slider.value >= slider.maxValue)
                {
                    slider.value = slider.maxValue;
                    llenando = false;
                }
            }
            else
            {
                // Decrementar el valor del slider para simular el vaciado del termómetro
                slider.value -= Time.deltaTime * velocidadLlenado;

                // Si el slider alcanza el valor mínimo, reiniciar el llenado
                if (slider.value <= slider.minValue)
                {
                    slider.value = slider.minValue;
                    llenando = true;
                }
            }
        }
    }
}
