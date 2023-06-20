using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareSound : MonoBehaviour
{
    public GameObject scareSound;

    public TriggerCloseDoor door; 

    private void Start()
    {      
        scareSound.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.GetComponent<TriggerCloseDoor>().ChangeDoorState();
            
            scareSound.SetActive(true);

            Destroy(gameObject);          
        }
    }
}
