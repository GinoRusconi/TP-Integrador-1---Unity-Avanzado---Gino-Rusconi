using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerControllerLvl1 : MonoBehaviour
{
    GameObject[] enemys;
    GameObject canvas;
    int totalEnemyToKill;
    int currentEnemyKill;
    public static ManagerControllerLvl1 Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    void Start()
    {
        totalEnemyToKill = enemys.Length;
        currentEnemyKill = 0;
    }

    public void EnemyDie()
    {
        currentEnemyKill++;
        if (currentEnemyKill == totalEnemyToKill)
        {
            Scene currentLvl = SceneManager.GetActiveScene();
            int nextlvl = currentLvl.buildIndex + 1;
            if (nextlvl == 3)
            {
                SceneManager.LoadScene(0);
            }else
            {
                SceneManager.LoadScene(nextlvl);
                Debug.Log("WIN");
            }
        }
    }

    public void PlayerDie()
    {
        canvas.GetComponent<Animator>().SetBool("Lose", true);
        Invoke("GoMainMenu",2f);
    }
    
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
