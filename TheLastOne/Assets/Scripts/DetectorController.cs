using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorController : MonoBehaviour {
    public GameObject Parent;
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
            Parent.transform.position = Parent.GetComponent<Enemy1Controller>().initialposition;
           other.transform.position =PlayerController.initialPosition;
       }
   }
}
