using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private Life _PlayerLife;
    public Image _BarraDeVida;
    private float _MaxLife;
    public float timeToLerp;
    public GameObject menu;

    float _currentPorcentaje;
    void Awake()
    {
        _PlayerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        _MaxLife = _PlayerLife.maxLife;
    }

    void Update()
    {
        _currentPorcentaje = _PlayerLife.currentLife;
        _BarraDeVida.fillAmount = Mathf.Lerp(_BarraDeVida.fillAmount, _PlayerLife.currentLife / _MaxLife, timeToLerp);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }

    public void CerrarMenu()
    {
        menu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
