using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slowMotion : MonoBehaviour
{
    
    
    public GameObject selector;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.3f;
            selector.SetActive(true);

            
        }
        else 
        {
            Time.timeScale = 1f;
            selector.SetActive(false);


        }


    }
}
