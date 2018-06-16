using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{

	void Start ()
    {
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.startLifetimeMultiplier);	
	}
}
