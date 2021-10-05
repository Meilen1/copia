using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLAB : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool openDoor = false;
    

    
    void Update()
    {
        if (openDoor)
        {


            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }
        
    }
    public void ChangeDoorState()
    {
        openDoor = !openDoor;
    }

}
