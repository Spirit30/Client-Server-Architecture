using System;
using System.Collections.Generic;

namespace Shared
{
    public class HexPathfinding
    {
        private HexGrid _grid;

        public HexPathfinding(HexGrid grid)
        {
            _grid = grid;
        }

        public List<HexTile> FindPath(HexTile start, HexTile end)
        {
            List<HexTile> openSet = new List<HexTile>();
            HashSet<HexTile> closedSet = new HashSet<HexTile>();

            openSet.Add(start);

            Dictionary<HexTile, HexTile> cameFrom = new Dictionary<HexTile, HexTile>();

            Dictionary<HexTile, int> gScore = new Dictionary<HexTile, int>();
            gScore[start] = 0;

            Dictionary<HexTile, int> fScore = new Dictionary<HexTile, int>();
            fScore[start] = GetHeuristicCost(start, end);

            while (openSet.Count > 0)
            {
                HexTile current = GetTileWithLowestFScore(openSet, fScore);

                if (current == end)
                {
                    return ReconstructPath(cameFrom, end);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (HexTile neighbor in _grid.GetNeighbors(current))
                {
                    if (closedSet.Contains(neighbor))
                        continue;

                    int tentativeGScore = gScore[current] + GetDistanceBetween(current, neighbor);

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                    else if (tentativeGScore >= gScore[neighbor])
                        continue;

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + GetHeuristicCost(neighbor, end);
                }
            }

            return null;
        }

        private HexTile GetTileWithLowestFScore(List<HexTile> tiles, Dictionary<HexTile, int> fScore)
        {
            HexTile result = null;
            int lowestScore = int.MaxValue;

            foreach (HexTile tile in tiles)
            {
                if (fScore.ContainsKey(tile) && fScore[tile] < lowestScore)
                {
                    result = tile;
                    lowestScore = fScore[tile];
                }
            }

            return result;
        }

        private List<HexTile> ReconstructPath(Dictionary<HexTile, HexTile> cameFrom, HexTile current)
        {
            List<HexTile> path = new List<HexTile>();

            while (cameFrom.ContainsKey(current))
            {
                path.Add(current);
                current = cameFrom[current];
            }

            path.Reverse();
            return path;
        }

        private int GetDistanceBetween(HexTile a, HexTile b)
        {
            // Manhattan distance between two hexes
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return dx + Math.Max(0, (dy - dx) / 2);
        }

        private int GetHeuristicCost(HexTile a, HexTile b)
        {
            // Manhattan distance between two hexes
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return dx + dy;
        }
    }
}