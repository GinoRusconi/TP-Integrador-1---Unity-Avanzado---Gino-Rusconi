using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3 directionMove { get; private set; }
    public Vector3 targetPositionClick { get; private set; }
    
    
    public bool InputAttackFirst { get; private set; }
    public bool InputAttackSeconds { get; private set; }

    private Ray cameraRay;
    private RaycastHit cameraRayHit;

    void Update()
    {
        directionMove = new Vector3(0, 0, Input.GetAxis("Vertical"));

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out cameraRayHit))
        {
            targetPositionClick = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
        }

        if (Input.GetButton("Fire1"))
        {
            InputAttackFirst = true;
        }else
        {
            InputAttackFirst = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            InputAttackSeconds = true;
        }else
        {
            InputAttackSeconds = false;
        }
    }
}
