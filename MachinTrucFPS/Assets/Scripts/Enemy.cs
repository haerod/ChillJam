﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject bloodFX;
    public GameObject deadFX;
    public GameObject note;

    public int life;

    private NavMeshAgent agent;
	
    void Awake()
    {
        player = FindObjectOfType<Shoot>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

	void Update ()
    {
        agent.SetDestination(player.position);
	}

    public void PlayBlood(Vector3 hit)
    {
        Instantiate(bloodFX, hit, transform.rotation);
    }

    public void ApplyDamages(int damages)
    {
        life -= damages;
        if(life <= 0)
        {
            GameObject _deadFX = Instantiate(deadFX);
            _deadFX.transform.position = transform.position;
            GameObject _note = Instantiate(deadFX);
            _note.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
