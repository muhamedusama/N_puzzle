using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp3
{
    public class node
    {
        public int manhattan_cost;
        public int hamming_cost;
        public int level;
        public int Total_F;
        public int F_cost;
        public int F_hamming;
        public int F_manhattan;
        public int[,] matrix;
        public int zero_index_root_i, zero_index_root_j;
        public node parent;
        public int m_or_h1;
        public node(int g, int[,] matrix, int n ,int ham , int man ,int m_or_h)
        {
            manhattan_cost = man ; 
            hamming_cost = ham;
            this.level = g;
            m_or_h1 = m_or_h;
            F_hamming = level + hamming_cost;
            F_manhattan = level + manhattan_cost;
            if (m_or_h == 1)
            {
                Total_F = F_manhattan;
                F_cost = manhattan_cost;
            }
            else if(m_or_h == 2)
            {
                Total_F = F_hamming;
                F_cost = hamming_cost;
            }

            this.matrix = matrix;
            parent = null;
        }
        public void get_child(int n, node node)
        {
           int NEXT_LEVEL=  node.level+1;     
            if (zero_index_root_i + 1 < n)
            {
                if (parent == null || parent.zero_index_root_i != node.zero_index_root_i+1)
                {
                    
                    Swap(node.matrix, n, node.zero_index_root_i, node.zero_index_root_j,
                                   node.zero_index_root_i + 1, node.zero_index_root_j, NEXT_LEVEL,node);
                }
            }
            if (node.zero_index_root_j + 1 < n)
            {
                if (parent == null || parent.zero_index_root_j != node.zero_index_root_j+1 )
                {
                    Swap(node.matrix, n, node.zero_index_root_i, node.zero_index_root_j,
                                   node.zero_index_root_i, node.zero_index_root_j +1, NEXT_LEVEL, node);
                }
            }
            if (node.zero_index_root_i - 1 >= 0)
            {
                if (parent == null || parent.zero_index_root_i !=node.zero_index_root_i-1)
                {
                    Swap(node.matrix, n, node.zero_index_root_i, node.zero_index_root_j,node.zero_index_root_i -1, node.zero_index_root_j, NEXT_LEVEL, node);
                }
            }
            if (zero_index_root_j - 1 >= 0)
            {
                if (parent == null || parent.zero_index_root_j != node.zero_index_root_j - 1)
                {
                    Swap(node.matrix, n, node.zero_index_root_i, node.zero_index_root_j,
                                  node.zero_index_root_i, node.zero_index_root_j - 1, NEXT_LEVEL, node);
                }
            }
        }
        public void Swap(int[,] matrix, int n, int i, int j, int x, int y, int level, node node )
        {
            int[,] swapmatrix = new int[n, n];
            Array.Copy(matrix, swapmatrix, n * n);
            //Swapping:
            int tempswap = swapmatrix[i, j];
            swapmatrix[i, j] = swapmatrix[x, y];
            swapmatrix[x, y] = tempswap;
            
            int new_manhatten=ConsoleApp3.matrices_operations.next_manhatten(i, j, node.manhattan_cost, swapmatrix[i, j], n, x, y);
            int new_hamming=ConsoleApp3.matrices_operations.next_hamming(i, j, node.hamming_cost, swapmatrix[i, j], n ,x,y);
           
            node curr = new node(level, swapmatrix, n, new_hamming, new_manhatten, m_or_h1);
            curr.zero_index_root_i = x;
            curr.zero_index_root_j = y;
            curr.parent = this;
            //Add node to priority Queue:
            ConsoleApp3.A_star_algorithem.nodes_list.enqueue(curr); // O(log V)  where v = number of nodes in the priorityqueue           
        }
    }
}