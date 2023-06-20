/* JumpScareSystem.cs by ThunderWire_Games * Script for Simple JumpScare */

using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class JumpScareSystem : MonoBehaviour {

public GameObject ScareObject;
public string ScareObjectAnim;
public string JumscareAnim;
public AudioClip ScareSound;
public MotionBlur Sanity;

	void Start()
    {
		/*ScareObject.animation.Stop(ScareObjectAnim);   		*/	 //stop looping (walk, run or any) animation on scare object
	}

	public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*		ScareObject.animation.Play(ScareObjectAnim); 			//play stopped scare object animation
                    animation.Play(JumscareAnim);       //play jumpscare animation
                    audio.clip = ScareSound;                    //set scare sound
                    audio.Play();                                           //play scare sound
                    collider.enabled = false;                      //disable collider for repeat scare
                    if(Sanity){Sanity.enabled = true;}        //enable sanity
                    StartCoroutine(ScaredWait());            //wait for destroy and sanity
            */
        }
	}
	
	IEnumerator ScaredWait()
    {
		yield return new WaitForSeconds(3.0f);
		if(Sanity){Sanity.enabled = false;}
		Destroy(this);
	}
}
