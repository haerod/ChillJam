using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;
    [SerializeField] private MuzzleFalsh muzzleFlash;
    [SerializeField] private GameObject shootSFX;
    [SerializeField] private GameObject feedabckBeat;

    [Header("Stats")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float minScreenshakeFOV;
    [SerializeField] private float screenshakeFOVModifier;

    private Bullet newBullet;
    private float baseFOV;

    [Header("Beat")]

    [SerializeField] private float beatTime;
    [SerializeField] private float allowedError;
    public float currentTime;
    public bool canShoot;

    float beatCalculator;
    float temp;

    void Start ()
    {
        baseFOV = Camera.main.fieldOfView;
	}
	
	void FixedUpdate ()
    {
        if(Camera.main.fieldOfView != baseFOV)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, baseFOV, 0.6f);
        }
        ShootNBeat();
    }

    void ShootBullet()
    {
        newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation).GetComponent<Bullet>();
        newBullet.speed = bulletSpeed;

        GameObject instaShootSFX = Instantiate(shootSFX, transform.position, Quaternion.identity);
        Destroy(instaShootSFX, 1.5f);

        muzzleFlash.gameObject.SetActive(true);
        muzzleFlash.StartEnd();

        if(Camera.main.fieldOfView - screenshakeFOVModifier >= minScreenshakeFOV)
        {
            Camera.main.fieldOfView -= screenshakeFOVModifier;
        }
        else
        {
            Camera.main.fieldOfView = screenshakeFOVModifier;
        }
    }

    void ShootNBeat()
    {
        currentTime = Time.time;
        beatCalculator = currentTime / beatTime;
        temp = Mathf.Floor(beatCalculator);
        beatCalculator -= temp;
        if (beatCalculator <= allowedError || (beatCalculator-allowedError >= allowedError * -1 && beatCalculator <= 0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootBullet();
            }
            feedabckBeat.SetActive(true);
        }
        else
        {
            feedabckBeat.SetActive(false);
        }
    }
}
