using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UnitColor : MonoBehaviour
{
    [SerializeField] Color PrimaryColor;
    [SerializeField] Color FaceTone;
    [SerializeField] Color HairColor;
    
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
        material.SetColor("_PrimaryColor", PrimaryColor);
        material.SetColor("_FacialTone", FaceTone);
        material.SetColor("_HairColor", HairColor);
    }
}
