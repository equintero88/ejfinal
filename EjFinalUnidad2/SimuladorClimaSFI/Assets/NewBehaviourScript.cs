using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static NewBehaviourScript;

public class NewBehaviourScript : MonoBehaviour
{
    public enum OpcionLluvia
    {
        SinLluvia,
        Llovizna,
        LluviaConstante,
        LluviaFuerte
    }

    public OpcionLluvia opcionSeleccionada;

    // Método para obtener la opción de lluvia seleccionada por el usuario
    public OpcionLluvia ObtenerOpcionSeleccionada()
    {
        return opcionSeleccionada;
    }


private int index;
    [SerializeField] private Image Imagen;
    [SerializeField] private TextMeshProUGUI nombre;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("LluviaIndex");

        CambiarPantalla();
    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("LluviaIndex", index);
        Imagen.sprite = gameManager.lluvias[index].imagen;
        nombre.text = gameManager.lluvias[index].nombre;
    }

    public void SiguienteLluvia()
    {
        if(index == gameManager.lluvias.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    
    }

    public void AnteriorLluvia()
    {
        if (index == 0)
        {
            index = gameManager.lluvias.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();

    }
}

