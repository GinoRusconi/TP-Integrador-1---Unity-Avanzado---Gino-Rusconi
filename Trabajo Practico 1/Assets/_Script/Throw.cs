using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    AudioSource m_AudioSource;
    public Vector3 targetWayPoint;
    private Rigidbody rb;
    public float speed;
    public float timeExplotion;

    public float damage;
    public float radioSphereCast;
    public LayerMask layersToDamage;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);
        StartCoroutine("Explote");
    }

    private void FixedUpdate()
    {
        //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint - transform.position, speed * Time.deltaTime, 0.0f);
        //transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);

    }

    private IEnumerator Explote()
    {
        yield return new WaitForSeconds(timeExplotion);
        Impact();
        m_AudioSource.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        yield return new WaitForSeconds(m_AudioSource.clip.length);
        Destroy(this.gameObject);
    }

    private void Impact()
    {
        RaycastHit[] m_Hit = Physics.SphereCastAll(transform.position, radioSphereCast, transform.forward, 0 , layersToDamage);
        if (m_Hit != null)
        {
            foreach (RaycastHit hit in m_Hit)
            {
                Debug.Log(hit.transform.name);
                hit.transform.gameObject.GetComponent<Life>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position + transform.forward * maxDistanceRayHit, transform.localScale);
        //Draw a Ray forward from GameObject toward the maximum distance
        //Gizmos.DrawRay(transform.position, transform.forward);
        //Draw a cube at the maximum distance
        //Gizmos.DrawWireCube(m_collider.bounds.center + transform.forward * maxDistanceRayHit, transform.localScale * 2f);
        Gizmos.DrawSphere(transform.position, radioSphereCast);
    }
}
