using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastDoorLab : MonoBehaviour
{
    public float distance = 3f;
    LayerMask mask;
    public bool openDoor = false;

    void Start()
    {
        mask = LayerMask.GetMask("Ray Cast Detected");
    }



    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            if (hit.collider.tag == "DoorLAB")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.collider.transform.GetComponent<doorLAB>().ChangeDoorState();
                        

                }
            }
        }
    }

    
}
