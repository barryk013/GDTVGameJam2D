using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    [SerializeField] private List<SpriteRenderer> spritesInFrontOfPlayer = new List<SpriteRenderer>();
    [SerializeField] private List<SpriteRenderer> spritesBehindPlayer = new List<SpriteRenderer>();

    private void OnValidate()
    {
        if (playerSpriteRenderer != null)
            playerSpriteRenderer.sortingOrder = (int)(playerSpriteRenderer.transform.position.y * -100);
    }

    // Update is called once per frame
    void Update()
    {
        playerSpriteRenderer.sortingOrder = (int)(playerSpriteRenderer.transform.position.y * -100);

        foreach (var sprite in spritesInFrontOfPlayer)
        {
            sprite.sortingOrder = playerSpriteRenderer.sortingOrder + 1;
        }
        foreach (var sprite in spritesBehindPlayer)
        {
            sprite.sortingOrder = playerSpriteRenderer.sortingOrder - 1;
        }

        SetSpriteLookDirection();
    }

    private void SetSpriteLookDirection()
    {
        Vector3 characterScale = playerSpriteRenderer.transform.localScale;

        if (input.MovementVector.x > 0)
            characterScale.x = Mathf.Abs(characterScale.x) * -1;

        else if (input.MovementVector.x < 0)
            characterScale.x = Mathf.Abs(characterScale.x);

        playerSpriteRenderer.transform.localScale = characterScale;
    }
}
