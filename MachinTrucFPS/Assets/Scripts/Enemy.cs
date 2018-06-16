using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject bloodFX;

    public int life;

    private NavMeshAgent agent;
	
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

	void Update ()
    {
        agent.SetDestination(player.position);
	}

    public void PlayBlood(ContactPoint contact)
    {
        Instantiate(bloodFX, contact.point, transform.rotation);
    }

    public void ApplyDamages(int damages)
    {
        life -= damages;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
