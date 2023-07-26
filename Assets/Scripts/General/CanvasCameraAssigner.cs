using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraAssigner : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    // sole responsibility is to assign a camera and delete self
    private void Start()
    {
        canvas.worldCamera = Camera.main;
        Destroy(this);
    }
}
