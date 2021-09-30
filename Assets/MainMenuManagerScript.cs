using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{
    public void CloseApplication()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LocalVersus");
    }
   
}
