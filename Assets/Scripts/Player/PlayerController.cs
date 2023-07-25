using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Unit unit;

    // reference to the camera
    Camera cam;

    [SerializeField] GameObject RespawnMenu;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        MovementUpdate();
        LookUpdate();

        // 0 - left click
        if(Input.GetMouseButtonDown(0))
        {
            unit.FireWeapon();
        }

        // 1 - right click
        if(Input.GetMouseButtonDown(1))
        {
            unit.StartAiming();
        }
        else if(Input.GetMouseButtonUp(1))
        {
            unit.StopAiming();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var health = GetComponent<Health>();
            health.DoDamage(5);
        }
    }

    private void OnDestroy()
    {
        if(RespawnMenu)
        {
            RespawnMenu.SetActive(true);
        }
    }

    private void MovementUpdate()
    {
        // stores the cumulative input
        Vector2 input = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }

        unit.Move(input);
    }

    private void LookUpdate()
    {
        var pointToLookAt = cam.ScreenToWorldPoint(Input.mousePosition);
        pointToLookAt.z = unit.transform.position.z;

        unit.LookAt(pointToLookAt);
    }


}
