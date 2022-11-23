using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerControllerLvl1 : MonoBehaviour
{
    GameObject[] enemys;
    GameObject canvas;
    public UI ui;

    public Quest[] quests;
    
    private static ManagerControllerLvl1 _instance;
    public static ManagerControllerLvl1 Instance

    #region Singleton

    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ManagerControllerLvl1>();
            }

            return _instance;
        }
    }
    #endregion Singleton

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        foreach (var quest in quests)
        {
            quest.ClearCondition();
        }
    }
    void Start()
    {
        
    }

    public void PickItem(Item item)
    {
        ui.AddItem(item);

        foreach (var quest in quests)
        {
            quest.AddAmount("PickItem", 1);
        }

        foreach (var quest in quests)
        {
            if (!quest.Success()) return;

        }

        Scene currentLvl = SceneManager.GetActiveScene();
        int nextlvl = currentLvl.buildIndex + 1;
        if (nextlvl == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextlvl);
            Debug.Log("WIN");
        }
    }

    public void EnemyDie()
    {
        foreach (var quest in quests)
        {
            quest.AddAmount("KillsEnemy", 1);
        }

        foreach (var quest in quests)
        {
            if (!quest.Success()) return;

        }

        Scene currentLvl = SceneManager.GetActiveScene();
        int nextlvl = currentLvl.buildIndex + 1;
        if (nextlvl == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextlvl);
            Debug.Log("WIN");
        }
    }

    public void PlayerDie()
    {
        canvas.GetComponent<Animator>().SetBool("Lose", true);
        Invoke("GoMainMenu", 3f);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
