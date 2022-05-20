using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class matrices_operations
    {
        public static int first_manhatten (int [,] matrix,int n) // O(n^2)
        {
            int cost = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    int index_column = 0;
                    if (matrix[i, j] % n != 0) { index_column = matrix[i, j] % n - 1; }
                    else { index_column = n - 1; }
                    double value = Convert.ToDouble(n);
                    double index_row = Math.Ceiling(matrix[i, j] / value) - 1;
                    if (matrix[i, j] == 0)           
                        continue;
                    
                     cost +=Math.Abs(i- Convert.ToInt32(index_row)) + Math.Abs(j - index_column);
                }
            }
            return cost;
        }
        public static int first_hamming(int[,] matrix, int n) // O(n^2)
        {
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)   
                        continue;
                    
                    int index_column = 0;
                    if (matrix[i, j] % n != 0) { index_column = matrix[i, j] % n - 1; }
                    else { index_column = n - 1; }
                    double value = Convert.ToDouble(n);
                    double index_row = Math.Ceiling(matrix[i, j] / value) - 1;
                    if (i != Convert.ToInt32(index_row) || j != index_column) {
                        counter++; 
                    }
                }
            }
            return counter;
        }

       // O(1)
        public static int next_manhatten(int new_i ,int new_j, int p_cost ,int element, int n ,int i_last,int j_last)
        {
            int index_column = 0;
            if (element % n != 0) { index_column = element % n - 1; }
            else { index_column = n - 1; }
            double value = Convert.ToDouble(n);
            double index_row = Math.Ceiling(element / value) - 1;
            p_cost -= Math.Abs(i_last - Convert.ToInt32(index_row)) + Math.Abs(j_last - index_column);
            p_cost += Math.Abs(new_i - Convert.ToInt32(index_row)) + Math.Abs(new_j - index_column);
            return p_cost;
        }
        // O(1)
        public static int next_hamming(int new_i, int new_j, int p_cost, int element, int n ,int i_last, int j_last)
        {
            int index_column = 0;
            if (element % n != 0) 
                index_column = element % n - 1;      
            else 
                index_column = n - 1; 
            double value = Convert.ToDouble(n);
            double index_row = Math.Ceiling(element / value) - 1;

            if(new_i== index_row && new_j== index_column)  
                p_cost--; 
            else if (index_row== i_last&& index_column== j_last)
                p_cost++;
            
            return p_cost;
        }
    }
}
