using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpriteLayer : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnValidate()
    {
        if (spriteRenderer != null)
            spriteRenderer.sortingOrder = (int)transform.position.y * -100;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);

        SetSpriteLookDirection();
    }

    private void SetSpriteLookDirection()
    {
        if (input.MovementVector.x > 0 && !spriteRenderer.flipX)
            spriteRenderer.flipX = true;

        else if (input.MovementVector.x < 0 && spriteRenderer.flipX)
            spriteRenderer.flipX = false;
    }
}
