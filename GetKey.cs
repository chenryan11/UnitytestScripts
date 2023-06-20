using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("按滑鼠左鍵");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("按滑鼠右鍵");
        }
    }
}
