using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    void OnCollisionEnter(Collision col)
     {
         if(col.transform.tag == "Player")
         {
             Destroy(this.gameObject);
         }
     }
}
