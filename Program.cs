using System;
using System.Collections.Generic;

namespace Puzzle8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] puzzle =
            {
                1, 2, 4,
                3, 0, 5,
                7, 6, 8
            };
            int[] puzzle1=
            {
                        1,2,3,
                        8,0,4,
                        7,6,5
            };
            int[] puzzle2 =
            {
                        2,8,3,
                        1,6,4,
                        7,0,5
            };
            int[] puzzle3 =
            {
                        2,8,3,
                        1,6,4,
                        0,7,5
            };
            int[] puzzle4 =
            {
                        1,2,3,
                        7,0,4,
                        6,8,5
            };
            int[] puzzle5 =
            {
                        2,0,8,
                        1,6,3,
                        7,5,4
            };
            
            Node root = new Node(puzzle4);
            Console.Write("\t Root is: \t");
            root.PrintPuzzle();

            UniformedSearch ui = new UniformedSearch();
            List<Node> solutionForBFS = ui.BreathFirstSearch(root);
            List<Node> solutionForDFS = ui.DepthFirstSearch(root);
            if (solutionForBFS.Count > 0)
            {
                Console.WriteLine("BFS Result");
                for(int i = solutionForBFS.Count - 1; i > 0; i--)
                {
                    solutionForBFS[i].PrintPuzzle();
                    
                }
            }
            if (solutionForDFS.Count > 0)
            {
                Console.WriteLine("DFS Result");
                for (int i = solutionForDFS.Count - 1; i > 0; i--)
                {                   
                    solutionForDFS[i].PrintPuzzle();
                    
                }
            }
            else
            {
                Console.WriteLine("No path solution is found");
            }
            
        }
    }
}
