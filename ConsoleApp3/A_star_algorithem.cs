using System;

namespace ConsoleApp3
{
    public class A_star_algorithem
    {
        public static priorityqueue nodes_list;
        public node A_star(int N,node start)
        {
            nodes_list = new priorityqueue();
            nodes_list.enqueue(start);
            node top = null;
             // O(E log V) where E = number of moves, V number of nodes
            while (!nodes_list.empty())  // O(E)
            {   
                top = nodes_list.dequeue();   //Log(V)
                if (top.F_cost == 0)
                    return top;
                
                top.get_child(N, top);
            }
            return null;
        }   
    }
}
