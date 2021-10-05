using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSoulMin : MonoBehaviour
{
    public GameObject selector;
    public GameObject character1;
    public GameObject character2;

    private void Start()
    {
        character2.SetActive(false);
    }

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
        character2.SetActive(true);
        character1.SetActive(false);
    }
}
