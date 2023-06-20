using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float max_door_distance = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // your camera must be tagged "MainCamera" in order to use "Camera.main"
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                // this assumes a first person perspective (camera position = player position)
                // if this is not the case, use player position instead of camera position here
                if (hit.collider.tag == "Door" && Vector3.Distance(Camera.main.transform.position, hit.point) < max_door_distance)
                {
                    Debug.Log("open door now");
                }
            }
        }
    }
}
