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

        // Verifica que se hayan guardado índices válidos
        if (optionIndex1 != -1 && optionIndex2 != -1)
        {
            // Combina los índices de las opciones seleccionadas en una sola cadena
            string selectedOptions = optionIndex1.ToString() + " + " + optionIndex2.ToString();

            // Determina la escena resultante según las opciones seleccionadas
            switch (selectedOptions)
            {
                case "0 + 0":
                    SceneManager.LoadScene("NoLluviaFrio");
                    break;
                case "0 + 1":
                    SceneManager.LoadScene("NoLluviaHumedo");
                    break;
                case "0 + 2":
                    SceneManager.LoadScene("NoLluviaTemplado");
                    break;
                case "0 + 3":
                    SceneManager.LoadScene("NoLluviaCaluroso");
                    break;
                case "1 + 0":
                    SceneManager.LoadScene("LloviznaFrio");
                    break;
                case "1 + 1":
                    SceneManager.LoadScene("LloviznaHumedo");
                    break;
                case "1 + 2":
                    SceneManager.LoadScene("LloviznaTemplado");
                    break;
                case "1 + 3":
                    SceneManager.LoadScene("LloviznaCaluroso");
                    break;
                case "2 + 0":
                    SceneManager.LoadScene("LluviaConstanteFrio");
                    break;
                case "2 + 1":
                    SceneManager.LoadScene("LluviaConstanteHumedo");
                    break;
                case "2 + 2":
                    SceneManager.LoadScene("LluviaConstanteTemplado");
                    break;
                case "2 + 3":
                    SceneManager.LoadScene("LluviaConstanteCaluroso");
                    break;
                case "3 + 0":
                    SceneManager.LoadScene("LluviaFuerteFrio");
                    break;
                case "3 + 1":
                    SceneManager.LoadScene("LluviaFuerteHumedo");
                    break;
                case "3 + 2":
                    SceneManager.LoadScene("LluviaFuerteTemplado");
                    break;
                case "3 + 3":
                    SceneManager.LoadScene("LluviaFuerteCaluroso");
                    break;
                // Agrega más casos según sea necesario
                default:
                    Debug.LogError("No hay una escena resultante definida para la combinación seleccionada.");
                    break;
            }
        }
        else
        {
            Debug.LogError("No se encontraron índices de opciones seleccionadas válidos en PlayerPrefs.");
        }
    }
}
