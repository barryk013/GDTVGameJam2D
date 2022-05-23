using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private void OnValidate()
    {
        if (playerSpriteRenderer != null)
            playerSpriteRenderer.sortingOrder = (int)transform.position.y * -100;
    }

    // Update is called once per frame
    void Update()
    {
        playerSpriteRenderer.sortingOrder = (int)(transform.position.y * -100);

        SetSpriteLookDirection();
    }

    private void SetSpriteLookDirection()
    {
        if (input.MovementVector.x > 0)
            playerSpriteRenderer.flipX = true;

        else if (input.MovementVector.x < 0)
            playerSpriteRenderer.flipX = false;
    }
}
