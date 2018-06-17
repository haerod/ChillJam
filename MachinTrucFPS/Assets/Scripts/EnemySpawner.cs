using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;

    public int secondsBeforeSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(-60f, 60f), 0, Random.Range(-60f, 60f));
            yield return new WaitForSeconds(secondsBeforeSpawn);
            Instantiate(enemy, position, transform.rotation);
        }
    }
}
