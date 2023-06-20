using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseEnterText : MonoBehaviour
{
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseDown()
    {
        Debug.Log(name.ToString() + "我被點了一下");
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}