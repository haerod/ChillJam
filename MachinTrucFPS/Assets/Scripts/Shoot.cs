using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;
    [SerializeField] private MuzzleFalsh muzzleFalsh;
    [SerializeField] private GameObject shootSFX;

    [Header("Stats")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float minScreenshakeFOV;
    [SerializeField] private float screenshakeFOVModifier;

    private Bullet newBullet;
    private float baseFOV;

    void Start ()
    {
        baseFOV = Camera.main.fieldOfView;
	}
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        if(Camera.main.fieldOfView != baseFOV)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, baseFOV, 0.6f);
        }
	}

    void ShootBullet()
    {
        newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation).GetComponent<Bullet>();
        newBullet.speed = bulletSpeed;

        GameObject instaShootSFX = Instantiate(shootSFX, transform.position, Quaternion.identity);
        Destroy(instaShootSFX, 1.5f);

        muzzleFalsh.gameObject.SetActive(true);
        muzzleFalsh.StartEnd();

        if(Camera.main.fieldOfView - screenshakeFOVModifier >= minScreenshakeFOV)
        {
            Camera.main.fieldOfView -= screenshakeFOVModifier;
        }
        else
        {
            Camera.main.fieldOfView = screenshakeFOVModifier;
        }
    }
}
