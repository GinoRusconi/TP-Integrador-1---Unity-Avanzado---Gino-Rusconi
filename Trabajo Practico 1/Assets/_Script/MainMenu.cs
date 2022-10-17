using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] canvas;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CambiarCanvas()
    {
        foreach (var canvas in canvas)
        {
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
            }

        }
    }

    public void Exit()
    {
        Application.Quit();
    }

}
