using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurningheadPicture : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject back1;
    public GameObject back2;

    private AudioSource audioSource;
    public AudioClip sound;

    public TurningheadText text;


    private void Start()
    {
        back1.SetActive(true);
        back2.SetActive(false);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("Picture"))
            {
                back1.SetActive(false);
                back2.SetActive(true);

                enabled = false;

                text.GetComponent<TurningheadText>().enabled = true;

                GetComponent<AudioSource>().PlayDelayed(1F);
                GetComponent<AudioSource>().PlayOneShot(sound);

                Destroy(GetComponent<TurningheadPicture>());              
            }
        }
    }
}
