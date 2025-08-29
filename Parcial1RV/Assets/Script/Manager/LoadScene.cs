using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{
    public string Code ="";
    //Nota: modificar al adaptar la interfaz
    public TMP_InputField inputField;

    public GameObject panelNull;
    public GameObject panelError;
    public GameObject panelCorrect;
    /// <summary>
    /// Carga la escena especificada por su nombre. Si existe un temporizador, 
    /// lo inicia.
    /// </summary>
    /// <param name="nameScene">Nombre de la escena a cargar.</param>
    public void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene);

    }

    /// <summary>
    /// Controla los paneles que permiten acceso a la escena,
    /// </summary>
    /// <param panelNull>Advertencia que el usuario no escribio nada</param>
    /// <param panelError>Advertencia que el usuario escribio el codigo incorrecto</param>
    /// <param panelCorrect>Abre el panel que permite cambiar de escena</param>
    public void SceneControll()
    {
        string TypedCode = inputField.text;

        if (TypedCode == null)
        {
            panelNull.SetActive(true);
        }
        else if (TypedCode != Code)
        {
            panelError.SetActive(true);
        }
        else
        {
            panelCorrect.SetActive(true);
        }
    }

    /// <summary>
    /// Cierra la aplicación.
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
