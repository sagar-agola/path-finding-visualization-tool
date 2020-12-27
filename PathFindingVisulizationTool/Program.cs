using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFindingVisulizationTool
{
    class Program
    {
        static void Main ()
        {
            List<Node> openList = new List<Node> ();
            HashSet<Node> closedList = new HashSet<Node> ();
            Node startNode, endNode, current;
            Node[,] grid = Helpers.BuildGrid ();

            Console.WriteLine ("Press any key to get started...");
            Console.ReadKey ();

            Console.WriteLine ("Enter start position : ");
            int startX = Convert.ToInt32 (Console.ReadLine ());
            int startY = Convert.ToInt32 (Console.ReadLine ());
            startNode = new Node (startX, startY, false);

            Console.WriteLine ("Enter end position : ");
            int endX = Convert.ToInt32 (Console.ReadLine ());
            int endY = Convert.ToInt32 (Console.ReadLine ());
            endNode = new Node (endX, endY, false);

            Console.Clear ();

            openList.Add (startNode);

            openList = Helpers.CalculateCosts (openList, startNode, endNode);

            while (openList.Count > 0)
            {
                int lowestFCost = openList.Min (x => x.FCost);
                current = openList.First (x => x.FCost == lowestFCost);

                closedList.Add (current);

                Console.SetCursorPosition (current.X, current.Y);
                Console.Write ('.');
                Console.SetCursorPosition (current.X, current.Y);
                //System.Threading.Thread.Sleep (1000);

                if (closedList.FirstOrDefault (x => x.X == endNode.X && x.Y == endNode.Y) != null)
                {
                    break;
                }

                openList.Remove (current);

                openList.AddRange (Helpers.GetSouroundingNodes (current, grid));
                openList = Helpers.CalculateCosts (openList, startNode, endNode);
            }

            Helpers.DrawGrid (grid, startNode, endNode);
        }
    }
}
