using UnityEngine;

public class Rotatingheadswitchingscene : MonoBehaviour
{
  /* public float interactDistance = 3f;
    public LayerMask interactLayer;*/

    public GameObject OddScence;
    public GameObject NewScence;



    private void Start()
    {
        OddScence.SetActive(true);
        NewScence.SetActive(false);
    }

    /* void OnTriggerExit(Collider other)
     {
         if(other.CompareTag("Player"))
         {
             OddScence.SetActive(false);
             NewScence.SetActive(true);
         }
     }*/

    private void Update()
    {
        {

            int layerMask = 1 << 8;

            layerMask = ~layerMask;


           // Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                if(GameObject.Find("Object001123") != null)
                {
                    OddScence.SetActive(false);
                    NewScence.SetActive(true);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }

            //shoots a ray
            /* if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
             {
                 if (hit.collider.CompareTag("SwitchingScene"))
                 {
                     OddScence.SetActive(false);
                     NewScence.SetActive(true);
                 }

                 if()

                 if (other.CompareTag("Player"))
                 {
                     OddScence.SetActive(false);
                     NewScence.SetActive(true);
                 }
             }*/
        }
    }
}
