using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Solve
    {
        public static int index_column_of_0;
        public static int index_row_of_0;
        static int get_inv_count(int[] arr)
        {
            int inversion_count = 0;
      
             // O(S^2) where S = the puzzle size.
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //compare with the cell after i cell till the last cell 
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == 0)
                        continue;
                    else if (arr[i] > arr[j])
                        inversion_count++;
                }
            }
            return inversion_count;
        }

        // O(S) where S = The size of the matrix 
        static int get_0_loc(int[] arr,int n)
        {
            int index_0 = -1;
            for (int i = 0; i < n * n; i++)
            {
                if (arr[i] == 0)
                {
                    index_0 = i / n;
                    break;
                }
            }
            return index_0;
        }
       
        static bool isSolvable(int n, int[] array)
        {
            int returned_counts = get_inv_count(array);
            int index_0 = get_0_loc( array,  n);
            if (n % 2 == 1 && returned_counts % 2 == 0)
                return true;
            else if (n % 2 == 0 && returned_counts % 2 != 0 && index_0 % 2 == 0)
                return true;
            else if (n % 2 == 0 && returned_counts % 2 == 0 && index_0 % 2 != 0)
                return true;

            return false;     
        }
        public static int SolveNPuzzleAStar(int[] arr, int n ,int m_or_h)
        {
            int[,] arr1 = new int[n, n];
            //Get The space index and to transform from 2d to 1d
            for (int i = 0; i < n; i++)     // O(n^2) where n = The size of the matrix.
            {
                for (int j = 0; j < n; j++)
                {
                    arr1[i, j] = arr[i * n + j];
                    if (arr1[i, j] == 0)
                    {
                        index_column_of_0 = i;
                        index_row_of_0 = j;
                    }
                }
            }
            if (isSolvable(n, arr))
            {
                int level = 0;
                // O(n^2)
                int manhatten= ConsoleApp3.matrices_operations.first_manhatten(arr1, n);
                // O(n^2)
                int hamming= ConsoleApp3.matrices_operations.first_hamming(arr1,n);
                node new_node = new node(level, arr1, n, hamming, manhatten, m_or_h);
                new_node.zero_index_root_i = ConsoleApp3.Solve.index_column_of_0;
                new_node.zero_index_root_j = ConsoleApp3.Solve.index_row_of_0;
                Console.WriteLine("1-Solvable");
                // O(E)
                A_star_algorithem Run_Algo = new A_star_algorithem();
                node x = Run_Algo.A_star(n, new_node);

                if(n == 3)
                   PrintPath(x, 3, new_node);

                Console.WriteLine("2-number of movments :" + " " + x.level);
                return x.level;
            }
            Console.WriteLine("Not Solvable");
            return -1;
        }
        public static void PrintPath(node top, int n, node root)
        {
            // O(M) where m = Total number of nodes in the Shortest Path
            Stack<node> PrintNodes = new Stack<node>();
            while (top.parent != null)
            {
                PrintNodes.Push(top);
                top = top.parent;
            }
            PrintNodes.Push(root);
            while (PrintNodes.Count != 0)
            {
                node NodePrinted = PrintNodes.Pop();
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        Console.Write(NodePrinted.matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
    }
}