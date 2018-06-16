using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFalsh : MonoBehaviour
{
	public void StartEnd ()
    {
        StartCoroutine(HideMuzzleFlash());
	}

    IEnumerator HideMuzzleFlash()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
