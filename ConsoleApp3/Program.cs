using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace N_Puzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N Puzzle Problem:\n[1]Sample test cases\n[2] complete testing\n[3]V_large");
            Console.Write("\nEnter your choice [1-2-3]:");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                    bool return_value0=false;
                    Console.WriteLine("\n[1] Solvable\n[2] Unsolvable");
                    Console.Write("\nEnter your choice [1-2]: ");
                    char choice1 = (char)Console.ReadLine()[0];
                    if(choice1 == '1')
                    {
                        Console.WriteLine("\n[1] manhatten\n[2] hamming");
                        Console.Write("\nEnter your choice [1-2]: ");
                        char m_or_h = (char)Console.ReadLine()[0];

                        if (m_or_h == '1')
                            return_value0 = check("Sample Test/Solvable Puzzles/all_test.txt", 1);
                        else if (m_or_h == '2')
                            return_value0 = check("Sample Test/Solvable Puzzles/all_test.txt", 2);
                        else
                            Console.WriteLine("Invalid Choice!");

                    }
                    else if(choice1 == '2') 
                         return_value0 = check("Sample Test/Unsolvable Puzzles/all_test.txt",1); 
                    else
                        Console.WriteLine("Invalid Choice!");
                    
                    break;
                case '2':
                    bool return_value1 = false;
                    Console.WriteLine("N Puzzle Problem:\n[1] Solvable\n[2] Unsolvable");
                    Console.Write("\nEnter your choice [1-2]: ");
                    char choice3 = (char)Console.ReadLine()[0];
                    if (choice3 == '1')
                    {

                        Console.WriteLine("N Puzzle Problem:\n[1]Manhattan&Hamming\n[2]Manhattan Only");
                        Console.Write("\nEnter your choice [1-2]: ");
                        char choice4 = (char)Console.ReadLine()[0];

                        if (choice4 == '1')
                        {
                            Console.WriteLine("\n[1] manhatten\n[2] hamming");
                            Console.Write("\nEnter your choice [1-2]: ");
                            char m_or_h = (char)Console.ReadLine()[0];

                            if (m_or_h == '1')
                                return_value1 = check("Complete TestCases/Solvable puzzles/Manhattan & Hamming/AllTests.txt",1);                       
                            else if (m_or_h == '2')
                                return_value1 = check("Complete TestCases/Solvable puzzles/Manhattan & Hamming/AllTests.txt", 2);
                            else
                                Console.WriteLine("Invalid Choice!");
                        }
                        else if (choice4 == '2')
                           return_value1 = check("Complete TestCases/Solvable puzzles/Manhattan Only/AllTests.txt", 1);
                        
                        else
                           Console.WriteLine("Invalid Choice!");
                            
                    }
                    else if (choice3 == '2') { return_value1 = check("Complete TestCases/Unsolvable puzzles/AllTests.txt",1); }
                    if (return_value1)
                        Console.WriteLine("\nCongratulations\n  ");
                    break;
                case '3':
                    bool return_value2 = check("TEST.txt",1);
                    if (return_value2)
                    {
                        Console.WriteLine("\nCongratulations\n ");
                    }
                    break;
            }
        }
        public static bool check(string fileName , int m_or_h )
        {
            FileStream test_file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader _StreamReader = new StreamReader(test_file);
            int number_cases = int.Parse(_StreamReader.ReadLine());
            int wrongAnswer = 0;
            
            //  O(T * (n^2)) where T = number of test cases, n = size of matrix.
            for (int counter = 0; counter < number_cases; counter++) 
            {
                int matrix_size = int.Parse(_StreamReader.ReadLine());
                int[] matrix_1d = new int[matrix_size * matrix_size];
                int k = 0;
                for (int counter1 = 0; counter1 < matrix_size; counter1++)
                {
                    string new_line = _StreamReader.ReadLine();
                    string[] num_splited = new_line.Split(' ');
                    for (int counter2 = 0; counter2 < matrix_size; counter2++)
                    {
                        int val = Int32.Parse(num_splited[counter2]);
                        matrix_1d[k++] = val;
                    }
                }
                int expectedResult = int.Parse(_StreamReader.ReadLine());
                long timeBefore = System.Environment.TickCount;
                //Complexity time:
                int receivedResult = ConsoleApp3.Solve.SolveNPuzzleAStar(matrix_1d, matrix_size ,  m_or_h);
                long timeAfter = System.Environment.TickCount;
                long time = timeAfter - timeBefore;
                Console.WriteLine("3-the time of program in ms " + time);
                Console.WriteLine("4-the time of program in Seconds " + time/1000);

                Console.WriteLine("\n____________________________________________________________________");
                Console.WriteLine("--------------------------------------------------------------------\n");

                if (receivedResult == expectedResult)
                    _StreamReader.ReadLine();    
                else 
                {
                    wrongAnswer++;
                    Console.WriteLine("wrong answer at case " + (counter + 1));
                }    
            }
            _StreamReader.Close();
            test_file.Close();
            if (wrongAnswer != 0)
            {
                Console.WriteLine(" wrong answer out of " + number_cases);
                return false;
            }
            return true;
        }
    }
}
// The whole class complexity = O(1)