using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cuarController : MonoBehaviour
{
    public Sprite[] optionSprites;
    private int currentOptionIndex = 0;
    public Image optionImage;

    void Start()
    {
        UpdateOptionDisplay();
    }

    void UpdateOptionDisplay()
    {
        optionImage.sprite = optionSprites[currentOptionIndex];
    }

    public void NextOption()
    {
        currentOptionIndex = (currentOptionIndex + 1) % optionSprites.Length;
        UpdateOptionDisplay();
    }

    public void PreviousOption()
    {
        currentOptionIndex = (currentOptionIndex - 1 + optionSprites.Length) % optionSprites.Length;
        UpdateOptionDisplay();
    }
    public void Continue()
    {
        // Almacena el índice de la opción seleccionada en PlayerPrefs
        PlayerPrefs.SetInt("OptionIndex3", currentOptionIndex);

        // Guarda los cambios en PlayerPrefs
        PlayerPrefs.Save();

        // Cambia a la siguiente escena
        SceneManager.LoadScene("TerceraEscenaDeSeleccion");
    }
}
