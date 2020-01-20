using System;
using System.Collections.Generic;

namespace Puzzle8
{
    class UniformedSearch
    {
        public UniformedSearch()
        {

        }

        public List<Node> BreathFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> CloseList = new List<Node>();
            int dequeue = 0;
            int enqueue = 0;

            OpenList.Add(root);
            bool goalFound = false;

            while(OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList[0];
                CloseList.Add(currentNode);
                OpenList.RemoveAt(0);

                currentNode.ExpandNode();
               // currentNode.PrintPuzzle();

                for(int i = 0; i<currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Goal Found.");
                        goalFound = true;
                        // trace path to root node
                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList, currentChild) && !Contains(CloseList, currentChild))/* OpenList contains currentChild ? && ClosedList contain current child*/
                    {
                        OpenList.Add(currentChild);
                        enqueue++;
                    }
                }

                dequeue++;
            }
            Console.WriteLine("\t ***** BFS Report ****");
            Console.WriteLine("\tDEQUEUE: {0}", dequeue);
            Console.WriteLine("\tENQUEUE: {0}", enqueue);
            Console.WriteLine();
            return PathToSolution;
        }

        public List<Node> DepthFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> CloseList = new List<Node>();
            int dequeue = 0;
            int enqueue = 0;

            OpenList.Add(root);
            bool goalFound = false;

            while (OpenList.Count > 0 && !goalFound)
            {
                
                Node currentNode = OpenList[0];
                CloseList.Add(currentNode);
                OpenList.RemoveAt(0);

                currentNode.ExpandNode();
                // currentNode.PrintPuzzle();

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Goal Found.");
                        goalFound = true;
                        // trace path to root node
                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList, currentChild) && !Contains(CloseList, currentChild))/* OpenList contains currentChild ? && ClosedList contain current child*/
                    {
                        OpenList.Insert(0, currentChild);
                        enqueue++;
                    }
                }
                dequeue++;
            }
            Console.WriteLine("\t **** DFS Report ******");
            Console.WriteLine("\tDEQUEUE: {0}" , dequeue);
            Console.WriteLine("\tENQUEUE: {0}", enqueue);
            Console.WriteLine();
            return PathToSolution;
        }
        public void PathTrace(List<Node> path, Node n)
        {
            //Console.WriteLine("Tracing Path ...");
            Node current = n;
            path.Add(current);

            while(current.parent != null)
            {
                current = current.parent;
                path.Add(current);
            }

        }

        public static bool Contains(List<Node> list, Node c)
        {

            bool contains = false;

            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.puzzle))
                    contains = true;
            }
            return contains;
        }
    }
}
