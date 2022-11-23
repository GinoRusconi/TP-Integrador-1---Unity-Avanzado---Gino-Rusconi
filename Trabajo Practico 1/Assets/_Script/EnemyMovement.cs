using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public string tanEnemy;

    NavMeshAgent agent;
    Transform target;
    Animator animator;
    private Life m_Life;
    public Collider m_collider;

    public float waitTimeToBackSpawn;
    public LayerMask layersToDamage;
    public bool isAttaking = false;
    public float maxDistanceRayHit;
    public float radioSphereCast;

    private void OnEnable()
    {
        m_collider.enabled = true;
        agent.isStopped = false;
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.destination = target.position;

        animator = GetComponentInChildren<Animator>();
        m_collider = GetComponent<Collider>();
        m_Life = GetComponent<Life>();
    }

    void FixedUpdate()
    {
        if (m_Life.isAlive)
        {
            //Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, maxDistanceRayHit, layersToDamage)
            //Physics.BoxCast(m_collider.bounds.center, transform.localScale, transform.forward, out RaycastHit m_Hit, transform.rotation, maxDistanceRayHit, layersToDamage)
            if (Physics.SphereCast(m_collider.bounds.center, radioSphereCast, transform.forward, out RaycastHit m_Hit, maxDistanceRayHit, layersToDamage))
            {
                isAttaking = true;
                agent.destination = transform.position;
            }
            else
            {
                isAttaking = false;
                agent.isStopped = false;
                agent.destination = target.position;
            }

            //Debug.DrawRay(transform.position, transform.forward * maxDistanceRayHit, Color.red);
            animator.SetBool("Attack", isAttaking);
        }else
        {
            m_collider.enabled = false;
            agent.isStopped = true;
            StartCoroutine(BackToPool());
        }
    }

    private IEnumerator BackToPool()
    {
        yield return new WaitForSeconds(waitTimeToBackSpawn);

        EnemyPool.Current.SetEnemyToPool(this.gameObject, tanEnemy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position + transform.forward * maxDistanceRayHit, transform.localScale);
        //Draw a Ray forward from GameObject toward the maximum distance
        Gizmos.DrawRay(transform.position, transform.forward * maxDistanceRayHit);
        //Draw a cube at the maximum distance
        //Gizmos.DrawWireCube(m_collider.bounds.center + transform.forward * maxDistanceRayHit, transform.localScale * 2f);
        //Gizmos.DrawSphere(m_collider.bounds.center + transform.forward * maxDistanceRayHit, radioSphereCast);
    }


}
