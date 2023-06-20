using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public GameObject pd;

    private void Update()
    {
        Vector2 vec2 = pd.transform.position;
        vec2.y += 100f * Time.deltaTime;

        pd.transform.position = vec2;
    }
}
