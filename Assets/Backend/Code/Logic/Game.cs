using Shared;
using System;

namespace Backend
{
    public class Game
    {
        const int GridSize = 10;
        readonly Random random = new Random();

        public event Action<GameData> OnGameDataResponse = delegate { };

        public void GameDataRequest()
        {
            var _grid = new HexGrid(GridSize, GridSize);
            var _pathFinding = new HexPathfinding(_grid);

            var a1 = _grid.GetRandomTile();
            var a2 = _grid.GetRandomTile();
            var aPath = _pathFinding.FindPath(a1, a2);
            int aLife = random.Next(Config.MinLife, Config.MaxLife);

            var b1 = _grid.GetRandomTile();
            var b2 = _grid.GetRandomTile();
            var bPath = _pathFinding.FindPath(b1, b2);
            int bLife = random.Next(Config.MinLife, Config.MaxLife);

            var data = new GameData
            {
                GridSize = GridSize,
                APath = aPath,
                BPath = bPath,
                ALife = aLife,
                BLife = bLife
            };

            OnGameDataResponse(data);
        }
    }
}