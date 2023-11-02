using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void IrAJuego()
    {
        Debug.Log("Entraste al juego");
        SceneManager.LoadScene("SampleScene");
    }

    public void RegresarAlMenu()
    {
        Debug.Log("Regresaste al menu");
        SceneManager.LoadScene("Menu");
    }

    public void IrAInfo()
    {
        Debug.Log("Entraste a Info");
        SceneManager.LoadScene("Information");
    }




}