using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float speed;
    private Enemy enemy;

	void Start ()
    {
        Destroy(this.gameObject, 5f);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void Update ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    /*void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Enemy")
        {
            enemy = col.gameObject.GetComponent<Enemy>();
            enemy.PlayBlood(col.contacts[0]);
            enemy.ApplyDamages(1);
            Destroy(this.gameObject);
        }
    }*/
}
