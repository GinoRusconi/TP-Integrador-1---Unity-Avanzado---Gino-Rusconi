using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float maxLife;
    private float currentLife;

    private Animator m_Animator;
    public bool isAlive= true;



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
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
        }
    }
}
