using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadTrigger : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PlayerTag))
        {
            LevelLoader.Instance.LoadLevel(sceneIndexToLoad);   
        }
    }
}
