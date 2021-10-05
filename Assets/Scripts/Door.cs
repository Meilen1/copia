using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpen = false;          //verifica si la puerta esta abierta o cerrada
    public float doorOpenAngle = 95f;      //angulo de la puerta al estar abierta
    public float doorCloseAngle = 0.0f;    //angulo de la puerta al estar cerrada
    public float soomth = 3.0f;            //velocidad con la que rotara la puerta

    void Start()
    {
        
    }

    
    void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, soomth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, soomth * Time.deltaTime);
        }
    }
}
