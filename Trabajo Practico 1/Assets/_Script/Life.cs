using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float maxLife;
    public float currentLife;
    public bool isAlive= true;



    protected virtual void Awake()
    {
        currentLife = maxLife;
    }

    protected virtual void Update()
    {
        if (currentLife <= 0 && isAlive)
        {
            isAlive = false;
           
            if (gameObject.tag == "Enemy")
            {
                ManagerControllerLvl1.Instance.EnemyDie();
            }
            else
            {
                ManagerControllerLvl1.Instance.PlayerDie();
            }
        }
    }

    protected void TakeDamage(float damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            Debug.Log($"El Personaje {gameObject.name} recibio {damage} de daño, le queda {currentLife} de vida");
        }
    }
}
