using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarWithBinaryHeap
{
    internal class Edge
    {
        public Node Destination { get; set; }
        public int Weight { get; set; }
        public Edge(Node destination, int weight)
        {
            Destination = destination;
            Weight = weight;
        }
    }
}
