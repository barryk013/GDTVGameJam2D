using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpriteLayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        spriteRenderer.sortingOrder = (int)(spriteRenderer.transform.position.y * -100);
    }

    private void OnValidate()
    {
        if(spriteRenderer != null)
            spriteRenderer.sortingOrder = (int)(spriteRenderer.transform.position.y * -100);
    }
}
