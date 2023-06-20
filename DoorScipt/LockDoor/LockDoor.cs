using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public bool front = false;

    private AudioSource audioSource;

    public AudioClip LockDoorSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLockDoorSound()
    {
        if(front == true)
        {
            audioSource.PlayOneShot(LockDoorSound);
        }
    }
}
