using System;
using System.Collections.Generic;

namespace Puzzle8
{
    class Node
    {
        public List<Node> children = new List<Node>();  // The lsit contains all the children of the node
        public Node parent; // parent of the NOde
        public int[] puzzle = new int[9];   // get the puzzle in one dimension array
        public int col = 3; // number column of puzzle
        int x;

        public Node(int[] p)
        {
            setPuzzle(p);   // set Node with the given of array
        }
        /**
         * Function copy one dimension array into the puzzle list
         **/
        public void setPuzzle(int[] p)  
        {
            for (int i = 0; i < puzzle.Length; i++)
                this.puzzle[i] = p[i];
        }
        
        public void ExpandNode()
        {
            
            for(int i = 0; i<puzzle.Length; i++)
            {
                if(puzzle[i] == 0)
                    x = i;
            }
            MoveToRight(puzzle, x);
            MoveToLeft(puzzle, x);
            MoveToTop(puzzle, x);
            MoveToDown(puzzle, x);
        }

        public void MoveToRight(int[] p, int i)
        {
            if(i % col < col - 1)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 1];
                pc[i + 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToLeft(int[] p, int i)
        {
            if(i % col > 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 1];
                pc[i - 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }
        }
        public void MoveToTop(int[] p, int i)
        {
            if(i - col >= 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 3];
                pc[i - 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }
        }
        public void MoveToDown(int[] p, int i)
        {
            if(i + col < puzzle.Length)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 3];
                pc[i + 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }
        }
        public void PrintPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for(int i = 0; i < col; i++)
            {
                Console.Write("\t");
                for(int j = 0; j < col; j++)
                {
                    Console.Write(puzzle[m] + " ");
                    m++;
                }
                Console.Write("\t");
                Console.WriteLine();
            }
        }

        public bool IsSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for(int i = 0; i < p.Length; i++)
            {
                if(puzzle[i] != p[i])
                {
                    samePuzzle = false;
                }
            }
            return samePuzzle;
        }
        public void CopyPuzzle(int[] a, int[] b)
        {
            for(int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }

        public bool GoalTest()
        {
            bool isGoal = true;
            int[] m = { 1,2,3,
                        8,0,4,
                        7,6,5};
            for(int i = 0; i < puzzle.Length; i++)
            {
                if (m[i] != puzzle[i])
                    isGoal = false;
            }
            return isGoal;
        }
    }
}
