namespace PathFindingVisulizationTool
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsWall { get; set; }
        public bool IsFinal { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost
        {
            get
            {
                return GCost + HCost;
            }
        }

        public Node (int x, int y, bool isWall)
        {
            X = x;
            Y = y;
            IsWall = isWall;
        }
    }
}
