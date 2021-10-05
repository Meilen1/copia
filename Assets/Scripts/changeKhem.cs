using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeKhem : MonoBehaviour
{
    public GameObject selector;
    public GameObject character1;
    public GameObject character2;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Press();
            selector.SetActive(false);
        }
    }

    private void Press()
    {
        character2.SetActive(false);
        character1.SetActive(true);
    }
}
