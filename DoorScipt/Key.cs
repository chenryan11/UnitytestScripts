using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    public OpenDoor MyDoorR;
    public OpenDoor MyDoorL;

    public AudioClip PickUpSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UnLockDoor()
    {
        MyDoorR.isLock = false;
        MyDoorL.isLock = false;

        MyDoorR.transform.gameObject.tag = "OpenDoor";
        MyDoorL.transform.gameObject.tag = "OpenDoor";

        audioSource.PlayOneShot(PickUpSound);

        StartCoroutine("WaitForSelfDestruct");
    }

    IEnumerator WaitForSelfDestruct()
    {
        yield return new WaitForSeconds(PickUpSound.length);
        Destroy(gameObject);
    }
}
