using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField] private GameObject feedabckBeat;    
    [SerializeField] private float beatTime;
    [SerializeField] private float allowedError;
    public float currentTime;
    public bool canShoot;




    [HideInInspector] public static Beat instance;

    float beatCalculator;
    float temp;

    void Awake ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	void Update ()
    {
        currentTime = Time.time;
        canShoot = IsInBeat();
	}

    bool IsInBeat()
    {
        beatCalculator = currentTime / beatTime;
        temp = Mathf.Floor(beatCalculator);
        beatCalculator -= temp;
        if(beatCalculator <= allowedError && beatCalculator >= allowedError*-1)
        {
            feedabckBeat.SetActive(true);
            return true;
        }
        feedabckBeat.SetActive(false);
        return false;
    }
}
