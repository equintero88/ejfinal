using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine.SceneManagement;

public class MenuSeleccionLluvia : MonoBehaviour
{
    private int index;

    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    private GamManager gamManager;

    private void Start()
    {
        gamManager = GamManager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");

        if(index > gamManager.personajes.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }


    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gamManager.personajes[index].imagen;
        nombre.text = gamManager.personajes[index].nombre;
    }

    public void SiguientePersonaje()
    {
        if(index == gamManager.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorPersonaje()
    {
        if(index == 0)
        {
            index = gamManager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

