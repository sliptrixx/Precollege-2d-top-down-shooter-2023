using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Given a list of sprites, picks a random one when the component becomes active
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpritePicker : MonoBehaviour
{
    [SerializeField] List<Sprite> Sprites;

    private void Start()
    {
        // get the sprite renderer and pick a random sprite from the list
        var sprite_renderer = GetComponent<SpriteRenderer>();
        var random_sprite = Sprites[Random.Range(0, Sprites.Count)];

        // spawn a random sprite
        sprite_renderer.sprite = random_sprite;

        // has performed its duty, it can now retire
        Destroy(this);
    }
}
