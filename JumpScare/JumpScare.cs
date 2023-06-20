using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip JumpScareSound;
    public AudioClip Breath;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           audioSource.PlayOneShot(JumpScareSound);

            gameObject.GetComponent<BoxCollider>().enabled = false;

            Invoke("Breathsound", 0.5f);
        }
    }

    void Breathsound()
    {
        audioSource.PlayOneShot(Breath);
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(gameObject, 5f);   
    }
}
