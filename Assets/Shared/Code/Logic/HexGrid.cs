using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class HexGrid
    {
        private int _width;
        private int _height;
        public HexTile[,] _tiles;

        public HexGrid(int width, int height)
        {
            _width = width;
            _height = height;

            _tiles = new HexTile[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _tiles[x, y] = new HexTile(x, y);
                }
            }
        }

        public HexTile GetTile(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null;

            return _tiles[x, y];
        }

        public HexTile GetTile(Vector2Int position)
        {
            return GetTile(position.x, position.y);
        }

        public HexTile GetRandomTile()
        {
            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);
            return GetTile(x, y);
        }

        public List<HexTile> GetNeighbors(HexTile tile)
        {
            List<HexTile> neighbors = new List<HexTile>();

            // Get neighbors to the left and right of the current tile
            int[] dx = { -1, 1 };
            for (int i = 0; i < 2; i++)
            {
                int x = tile.X + dx[i];
                int y = tile.Y;
                HexTile neighbor = GetTile(x, y);
                if (neighbor != null)
                    neighbors.Add(neighbor);
            }

            // Get neighbors to the top and bottom of the current tile
            int[] dy = { -1, 1 };
            for (int i = 0; i < 2; i++)
            {
                int x = tile.X;
                int y = tile.Y + dy[i];
                HexTile neighbor = GetTile(x, y);
                if (neighbor != null)
                    neighbors.Add(neighbor);
            }

            // Get neighbors to the top-left and bottom-right of the current tile
            int[] dx2 = { -1, 0 };
            int[] dy2 = { -1, 1 };
            for (int i = 0; i < 2; i++)
            {
                int x = tile.X + dx2[i];
                int y = tile.Y + dy2[i];
                HexTile neighbor = GetTile(x, y);
                if (neighbor != null)
                    neighbors.Add(neighbor);
            }

            // Get neighbors to the top-right and bottom-left of the current tile
            int[] dx3 = { 0, 1 };
            int[] dy3 = { -1, 1 };
            for (int i = 0; i < 2; i++)
            {
                int x = tile.X + dx3[i];
                int y = tile.Y + dy3[i];
                HexTile neighbor = GetTile(x, y);
                if (neighbor != null)
                    neighbors.Add(neighbor);
            }

            return neighbors;
        }
    }
}