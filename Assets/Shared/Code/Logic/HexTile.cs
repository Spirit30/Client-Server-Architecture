namespace Shared
{
    public class HexTile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public HexTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(HexTile t1, HexTile t2)
        {
            if (t1 is null)
                return t2 is null;

            return t1.Equals(t2);
        }

        public static bool operator !=(HexTile t1, HexTile t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return obj is HexTile b2 
                ? (X == b2.X && Y == b2.Y)
                : false;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}