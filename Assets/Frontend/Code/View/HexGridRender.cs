using Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend
{
    public class HexGridRender : MonoBehaviour
    {
        [SerializeField]
        HexTileView tilePrefab;

        [SerializeField]
        int gridSize = 101;

        public Dictionary<HexTile, HexTileView> Map { get; } = new Dictionary<HexTile, HexTileView>();

        public void Create(HexGrid grid)
        {
            for (int x = 0; x < gridSize; ++x)
            {
                float rowOffset = tilePrefab.Extent * x % 2;

                for (int z = 0; z < gridSize; ++z)
                {
                    var tileView = Instantiate(tilePrefab);
                    tileView.Tile = grid.GetTile(x, z);
                    tileView.transform.SetParent(transform);
                    tileView.transform.position = new Vector3(x, 0, z + rowOffset);
                    Map.Add(tileView.Tile, tileView);
                }
            }
        }
    }
}