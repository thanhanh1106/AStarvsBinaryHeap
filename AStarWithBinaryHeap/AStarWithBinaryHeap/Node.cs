using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarWithBinaryHeap
{
    internal class Node:IComparable<Node>
    {
        public int X { get; set; } // tọa độ x của node
        public int Y { get; set; } // tọa độ y của node
        public bool IsWall { get; set; }
        public List<Edge> Edges { get; set; } // danh sách kề
        public Node Parent { get; set; }

        public int G { get; set; }//  khoảng cách từ điểm đầu đến node hiện tại
        public int H { get; set; } // khoảng các tính bằng heuristic từ node hiện tại đến node đích
        public int F => G + H; // tổng chi phí của G và H
        public Node(int x, int y, bool isWall = false)
        {
            X = x;
            Y = y;
            IsWall = isWall;
            Edges = new List<Edge>();
            Parent = null;
            G = 0;
            H = 0;
        }

        public int CompareTo(Node other)
        {
            if(this.F.CompareTo(other.F) == 0)
            {
                return this.H.CompareTo(other.H);
            }
            else return this.F.CompareTo(other.F);
        }

    }
}
