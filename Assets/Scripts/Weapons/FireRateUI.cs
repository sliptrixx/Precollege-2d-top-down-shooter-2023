using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Vector3 Offset;

    [Header("References")]
    [SerializeField] Image BackgroundRing;
    [SerializeField] Image ForegroundRing;
    [SerializeField] Unit  UnitToTrack;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // caching
        float fireRate = UnitToTrack.currentWeapon.FireRate;
        float timeToFire = UnitToTrack.currentWeapon.timeToFire;

        // ready to fire... don't show the ui
        if (timeToFire < 0)
        {
            BackgroundRing.gameObject.SetActive(false);
            ForegroundRing.gameObject.SetActive(false);
        }
        else
        {
            // always tracks the mouse and applies an optional offset
            // bad code... but it will do for now...
            // like I can't track firerate for any other unit now :(
            // but oh well

            var cursorPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Offset;
            cursorPosition.z = 0;
            transform.position = cursorPosition;
            
            // ui needs to be tracking the fire rate... so set the elements active
            BackgroundRing.gameObject.SetActive(true);
            ForegroundRing.gameObject.SetActive(true);

            // update the fill amount
            ForegroundRing.fillAmount = (fireRate - timeToFire) / fireRate;
        }
    }
}
