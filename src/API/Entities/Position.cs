namespace API.Entities
{
    public class Position
    {
        public int NorthSouthPosition { get; }

        public int WestEastPosition { get; }

        public Orientation Orientation { get; set; }

        public Position(int northSouthPosition, int westEastPosition, Orientation orientation)
        {
            NorthSouthPosition = northSouthPosition;
            WestEastPosition = westEastPosition;
            Orientation = orientation;
        }
    }

    public enum Orientation
    {
        N,
        E,
        S,
        W,
    }
}