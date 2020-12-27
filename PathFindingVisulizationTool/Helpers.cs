using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFindingVisulizationTool
{
    public static class Helpers
    {
        public static Node[,] BuildGrid ()
        {
            Node[,] grid = new Node[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = new Node (i, j, false);
                }
            }

            grid[1, 4].IsWall = true;
            grid[2, 4].IsWall = true;
            grid[3, 4].IsWall = true;
            grid[4, 4].IsWall = true;
            grid[5, 4].IsWall = true;
            grid[6, 4].IsWall = true;

            return grid;
        }

        public static List<Node> CalculateCosts (List<Node> nodes, Node startNode, Node endNode)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].GCost = Math.Abs (nodes[i].X - startNode.X) + Math.Abs (nodes[i].Y - startNode.Y);
                nodes[i].HCost = Math.Abs (endNode.X - nodes[i].X) + Math.Abs (endNode.Y - nodes[i].Y);
            }

            return nodes;
        }

        public static List<Node> GetSouroundingNodes (Node node, Node[,] grid)
        {
            List<Node> nodes = new List<Node>
            {
                grid[node.X - 1, node.Y],
                grid[node.X + 1, node.Y],
                grid[node.X, node.Y - 1],
                grid[node.X, node.Y + 1]
            };

            return nodes.Where (x => !grid[x.X, x.Y].IsWall).ToList ();
        }

        public static void DrawGrid (Node[,] grid, Node startNode, Node endNode)
        {
            for (int i = 0; i < grid.GetLength (0); i++)
            {
                for (int j = 0; j < grid.GetLength (1); j++)
                {
                    if (grid[i, j].X == startNode.X && grid[i, j].Y == startNode.Y)
                    {
                        Console.Write (" S");
                        continue;
                    }

                    if (grid[i, j].X == endNode.Y && grid[i, j].Y == endNode.Y)
                    {
                        Console.Write (" E");
                        continue;
                    }

                    if (grid[i, j].IsWall)
                    {
                        Console.Write (" *");
                    }
                    else
                    {
                        Console.Write ("__");
                    }
                }

                Console.WriteLine ();
            }
        }
    }
}
