using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlScene : MonoBehaviour
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
        // Almacena el �ndice de la opci�n seleccionada en PlayerPrefs
        PlayerPrefs.SetInt("OptionIndex2", currentOptionIndex);

        // Guarda los cambios en PlayerPrefs
        PlayerPrefs.Save();

        // Cambia a la siguiente escena
        SceneManager.LoadScene("CuartaEscena");
    }
}
