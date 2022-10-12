using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Collider _collider;
    Animator _animator;
    Vector3 directionMove;
    public float movementVelocity = 2f;
    public float maxDistanceRayShoot;
    public float timeBetweenShoot = 0.8f;
    public float lastTimeShoot;
    public float damage;
    public LayerMask layersToDamage;
    Ray cameraRay;
    RaycastHit cameraRayHit;

    Vector3 direction;
    bool isShooting = false;
    Life m_Life;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<Collider>();
        m_Life = GetComponent<Life>();
        lastTimeShoot = Time.time;
        
    }
    private void Update()
    {
        if (m_Life.isAlive)
        {
            directionMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _animator.SetFloat("VelX", directionMove.x);
            _animator.SetFloat("VelZ", directionMove.z);

            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out cameraRayHit))
            {
                if (cameraRayHit.transform.tag == "Ground")
                {
                    Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                    transform.LookAt(targetPosition);
                }
            }

            if (Input.GetButtonDown("Fire1") && !isShooting)
            {
                isShooting = true;
                _animator.SetBool("Shoot", isShooting);

            }
            else if (Input.GetButtonUp("Fire1") && isShooting)
            {
                isShooting = false;
                _animator.SetBool("Shoot", isShooting);
            }
        }
    }   
    private void FixedUpdate()
    {
        if (m_Life.isAlive)
        {
            direction = new Vector3(cameraRayHit.point.x - transform.position.x, 0, cameraRayHit.point.z - transform.position.z);
            if (!isShooting)
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
