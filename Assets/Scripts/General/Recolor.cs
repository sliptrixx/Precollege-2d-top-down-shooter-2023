using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Recolor : MonoBehaviour
{
    [SerializeField] Color RedChannel;
    [SerializeField] Color BlueChannel;
    [SerializeField] Color GreenChannel;
    
    // Reference to the attached sprite renderer
    SpriteRenderer spriteRenderer = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColors();
    }

    private void OnValidate()
    {
        UpdateColors();
    }

    void UpdateColors()
    {
        // no sprite renderer is available, early exit
        // this will prevent setting colors by on validate in edit mode
        if(spriteRenderer == null) { return; }

        // update the values in the materials
        var material = spriteRenderer.material;
        material.SetColor("_Red", RedChannel);
        material.SetColor("_Blue", BlueChannel);
        material.SetColor("_Green", GreenChannel);
    }
}
