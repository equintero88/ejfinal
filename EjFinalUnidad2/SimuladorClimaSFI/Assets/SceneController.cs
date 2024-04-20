using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour

{
    // Método para cargar la escena resultante según las opciones seleccionadas en las dos primeras escenas
    public void LoadResultScene()
    {
        // Recupera los índices de las opciones seleccionadas de PlayerPrefs
        int optionIndex1 = PlayerPrefs.GetInt("OptionIndex1", -1);
        int optionIndex2 = PlayerPrefs.GetInt("OptionIndex2", -1);
        int optionIndex3 = PlayerPrefs.GetInt("OptionIndex3", -1);

        // Verifica que se hayan guardado índices válidos
        if (optionIndex1 != -1 && optionIndex2 != -1 && optionIndex3 != -1)
        {
            // Combina los índices de las opciones seleccionadas en una sola cadena
            string selectedOptions = optionIndex1.ToString() + " + " + optionIndex2.ToString() + " + " + optionIndex3.ToString();

            // Determina la escena resultante según las opciones seleccionadas
            switch (selectedOptions)
            {
                case "0 + 0 + 0":
                    SceneManager.LoadScene("NoLluviaFrio");
                    break;
                case "0 + 1 + 0":
                    SceneManager.LoadScene("NoLluviaTemplado");
                    break;
                case "0 + 2 + 0":
                    SceneManager.LoadScene("NoLluviaCaluroso");
                    break;
                case "0 + 0 + 1":
                    SceneManager.LoadScene("NoLluviaFrioNoche");
                    break;
                case "0 + 1 + 1":
                    SceneManager.LoadScene("NoLluviaTempladoNoche");
                    break;
                case "0 + 2 + 1":
                    SceneManager.LoadScene("NoLluviaCalurosoNoche");
                    break;
            }
        }
        else
        {
            Debug.LogError("No se encontraron índices de opciones seleccionadas válidos en PlayerPrefs.");
        }
    }
}
