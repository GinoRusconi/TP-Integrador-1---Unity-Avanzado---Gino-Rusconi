using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float maxLife;
    public float currentLife;
    

    private Animator m_Animator;
    public bool isAlive= true;

    private void OnEnable()
    {
        currentLife = maxLife;
        isAlive = true;
    }

    void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
        currentLife = maxLife;
    }

    private void Update()
    {
        if (currentLife <= 0 && isAlive)
        {
            isAlive = false;
            m_Animator.SetTrigger("Die");
           
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

    public void TakeDamage(float damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            Debug.Log($"El Personaje {gameObject.name} recibio {damage} de daño, le queda {currentLife} de vida");
        }
    }

    
}
