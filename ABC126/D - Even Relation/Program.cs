using System;
using System.Collections.Generic;
using System.Linq;

namespace D___Even_Relation
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var nodes = new node[N];
            for(int i = 1 ; i < N+1 ; i++ ) nodes[i] = new node();
            for(int i = 0 ; i < N ; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
                nodes[read[0]].children.Add(read[1]);
                nodes[read[1]].children.Add(read[0]);
                nodes[read[0]].costs.Add(read[2]%2);
                nodes[read[1]].costs.Add(read[2]%2);
            }

            var queue = new Queue<node>();
            nodes[1].isOdd = false;
            queue.Add(nodes[1]);
            while(queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                currentNode.visited = true;
                for(int i = 0 ; i < currentNode.children.Count;i++)
                {
                    var searchNode = nodes[currentNode.children[i]];
                    if(!searchNode.visited)
                    {
                        
                    }
                }
            }
        }
    }
    public class node
    {
        public bool visited{get;set;}
        public bool isOdd{get;set;}

        public List<int> children{get;set;}
        public List<int> costs{get; set;}
        
        node(){
            children = new List<int>();
            costs = new List<int>();
        }
        
    }
}
