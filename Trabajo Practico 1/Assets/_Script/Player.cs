using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Collider _collider;
    Animator _animator;
    Life m_Life;
    AnimationFlag m_animationFlag;
    Rigidbody rb;


    public Vector3 targetPosition;
    Vector3 directionMove;
    Vector3 direction;
    Vector3 pointGranade;

    RaycastHit cameraRayHit;
    Ray cameraRay;

    public GameObject m_Granade;
    public Transform m_granadePoint;

    public float movementVelocity = 2f;
    public float maxDistanceRayShoot;
    public float timeBetweenShoot = 0.8f;
    public float lastTimeShoot;
    public float damage;
    public LayerMask layersToDamage;

    bool isShooting = false;
    bool isThrow = false;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        m_Life = GetComponent<Life>();
        m_animationFlag = GetComponentInChildren<AnimationFlag>();
        rb = GetComponent<Rigidbody>();
        lastTimeShoot = Time.time;

    }
    private void Update()
    {
        if (m_Life.isAlive && !m_animationFlag.throwGranade)
        {
            isThrow = false;
            _animator.SetBool("Shoot", isShooting);
            directionMove = new Vector3(0, 0, Input.GetAxis("Vertical"));

            _animator.SetFloat("VelX", directionMove.x);
            _animator.SetFloat("VelZ", directionMove.z);

            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out cameraRayHit))
            {
            //    if (cameraRayHit.transform.tag == "Ground")
                //{
                    targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                    transform.LookAt(targetPosition);
             //   }
            }

            if (Input.GetButton("Fire1") && !isShooting && !isThrow)
            {
                isShooting = true;
                _animator.SetBool("Shoot", isShooting);

            }
            else if (Input.GetButtonUp("Fire1") && isShooting)
            {
                isShooting = false;
                _animator.SetBool("Shoot", isShooting);
            }

            if (Input.GetButtonDown("Fire2") && isShooting)
            {
                pointGranade = transform.position;
                m_animationFlag.throwGranade = true;
                isThrow = true;
                _animator.SetTrigger("Throw");
                isShooting = false;
            }
        }
        else if (!m_Life.isAlive)
        {
            _collider.enabled = false;
        }

        if (m_animationFlag.tossGranade)
        {
            GameObject granade = Instantiate(m_Granade,m_granadePoint.position, transform.rotation);
            m_animationFlag.tossGranade = false;
            
        }

    }   
    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        if (m_Life.isAlive)
        {
            direction = new Vector3(cameraRayHit.point.x - transform.position.x, 0, cameraRayHit.point.z - transform.position.z);
            if (!isShooting && !isThrow)
            {
                transform.Translate(directionMove * Time.deltaTime * movementVelocity);
                //_rigidbody.AddForce(movementVelocity * Time.deltaTime * directionMove, ForceMode.Acceleration);
            }
            else
            {
                if (lastTimeShoot < Time.time)
                {

                    lastTimeShoot = timeBetweenShoot + Time.time;
                    if (Physics.Raycast(_collider.bounds.center + new Vector3(0, .5f, 0), direction, out RaycastHit hitInfo, maxDistanceRayShoot, layersToDamage))
                    {
                        hitInfo.transform.gameObject.GetComponent<Life>().TakeDamage(damage);
                    }
                }
            }

            Debug.DrawRay(_collider.bounds.center + new Vector3(0, .5f, 0), direction.normalized * maxDistanceRayShoot, Color.red);
        }
    }
}
