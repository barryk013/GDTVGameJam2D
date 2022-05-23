using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpriteLayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = (int)transform.position.y * -100;
    }

    private void OnValidate()
    {
        if(spriteRenderer != null)
            spriteRenderer.sortingOrder = (int)transform.position.y * -100;
    }
}
