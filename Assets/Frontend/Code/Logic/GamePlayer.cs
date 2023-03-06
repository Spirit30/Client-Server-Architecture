using Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend
{
    class GamePlayer : MonoBehaviour
    {
        [SerializeField]
        HexGridRender hexGridRender;

        [SerializeField]
        UIView ui;

        [SerializeField]
        UnitView aUnitPrefab;

        [SerializeField]
        UnitView bUnitPrefab;

        public void Play(GameData data)
        {
            var grid = new HexGrid(data.GridSize, data.GridSize);
            hexGridRender.Create(grid);

            var aUnit = Instantiate(aUnitPrefab);
            aUnit.Init(data.ALife, GetPathView(data.APath), ui.SetALife);

            var bUnit = Instantiate(bUnitPrefab);
            bUnit.Init(data.BLife, GetPathView(data.BPath), ui.SetBLife);

            aUnit.Gun.Init(bUnit);
            bUnit.Gun.Init(aUnit);
        }

        List<HexTileView> GetPathView(List<HexTile> path)
        {
            var pathView = new List<HexTileView>();

            for(int i = 0; i < path.Count; ++i)
            {
                var tile = path[i];
                var tileView = hexGridRender.Map[tile];
                pathView.Add(tileView);
            }

            return pathView;
        }
    }
}