using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    [SerializeField] Transform Target;

    public void UpdatePosition()
    {
        if(!Target) { return; }
        transform.position = Target.position;
    }
}
