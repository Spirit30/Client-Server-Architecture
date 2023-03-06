using System.Collections.Generic;

namespace Shared
{
    public class GameData
    {
        public int GridSize { get; set; }
        public List<HexTile> APath { get; set; }
        public List<HexTile> BPath { get; set; }
        public int ALife { get; set; }
        public int BLife { get; set; }
    }
}