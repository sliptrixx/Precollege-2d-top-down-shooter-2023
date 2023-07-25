using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1;

    Vector3 startCameraPosition;

    private void Start()
    {
        startCameraPosition = transform.position;
    }

    private void LateUpdate()
    {
        // nothing to follow, don't proceed
        if(Target == null) { return; }

        Vector3 expectedPosition = Target.position;
        expectedPosition.z = startCameraPosition.z;

        // lerp - linear interpolation
        transform.position = Vector3.Lerp(transform.position, expectedPosition, Time.deltaTime * Speed);
    }
}
