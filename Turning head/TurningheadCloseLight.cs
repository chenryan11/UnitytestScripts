using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadCloseLight : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public float doorOpenAngle;
    public float smooth = 3f;

    private AudioSource audioSource;
    public AudioClip CloseLight;

    public GameObject CloseLightObject;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        CloseLightObject.SetActive(true);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("TurningheadCloseLight"))
            {
                audioSource.PlayOneShot(CloseLight);

                CloseLightObject.SetActive(false);

                enabled = false;

                Destroy(GetComponent<TurningheadCloseLight>());
            }
        }
    }
}
