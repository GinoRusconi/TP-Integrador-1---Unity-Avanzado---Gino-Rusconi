using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMob : MonoBehaviour
{
    public SphereCollider sphereAttack;
    private Life m_Life;

    public string tagToDamage;
    public float damage;
    private void Awake()
    {
        sphereAttack = GetComponent<SphereCollider>();
        m_Life = GetComponentInParent<Life>();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToDamage) && m_Life.isAlive)
        {
            other.transform.gameObject.GetComponent<Life>().TakeDamage(damage);
            Debug.Log("Hited Player");
            DisabledShepereAttack();
        }
    }

    public void EnabledShepereAttack()
    {
        sphereAttack.enabled = true;
    }

    public void DisabledShepereAttack()
    {
        sphereAttack.enabled = false;
    }
}
