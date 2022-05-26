using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public static TilemapManager Instance { get; private set; }
    private Tilemap _tilemap;
    private Grid _grid;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
        _grid = GetComponentInParent<Grid>();

        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    
    public void RemoveTile(Vector3 position)
    {
        Vector3Int pos = _grid.WorldToCell(position);
        _tilemap.SetTile(pos, null);
    }
}
