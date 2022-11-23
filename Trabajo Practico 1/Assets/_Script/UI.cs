using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private Life _PlayerLife;
    private float _MaxLife;
    private QuestUI questUI;

    public GameObject inventario;
    public Image[] items;
    public Image _BarraDeVida;
    public float timeToLerp;
    public GameObject menu;

    float _currentPorcentaje;
    void Awake()
    {
        _PlayerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        _MaxLife = _PlayerLife.maxLife;

        questUI = GetComponentInChildren<QuestUI>();
    }

    void Update()
    {
        _currentPorcentaje = _PlayerLife.currentLife;
        _BarraDeVida.fillAmount = Mathf.Lerp(_BarraDeVida.fillAmount, _PlayerLife.currentLife / _MaxLife, timeToLerp);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            questUI.gameObject.SetActive(true);
        }else
        {
            questUI.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.I))
        {
            inventario.SetActive(true);
        }
        else
        {
            inventario.SetActive(false);
        }
    }

    public void AddItem(Item item)
    {
        foreach (Image image in items)
        {
            if (image.sprite == null)
            {
                image.sprite = item.iconObject;
                return;
            }
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
