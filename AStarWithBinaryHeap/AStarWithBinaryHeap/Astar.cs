using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarWithBinaryHeap
{
    internal class Astar
    {
        public List<List<Node>> Grid;
        BinaryHeap<Node> openList;
        HashSet<Node> closeList;

        public Astar(int width, int height)
        {
            Grid = new List<List<Node>>();
            for (int x = 0; x < width; x++)
            {
                Grid.Add(new List<Node>());
                for (int y = 0; y < height; y++)
                {
                    Grid[x].Add(new Node(x, y));
                }
            }
            openList = new BinaryHeap<Node>();
            closeList = new HashSet<Node>();
            ConnectNodes();
        }
        public void SetWall(Node node)
        {
            node.IsWall = true;
        }
        void AddEdge(Node currentNode,Node destination,int weight)
        {
            currentNode.Edges.Add(new Edge(destination, weight));
        }
        void ConnectNodes()
        {
            // bắt đầu từ bên trái node và chạy vòng theo kim đồng hồ
            int[] directionX = { -1, -1, 0, 1, 1, 1, 0, -1 }; // hướng cạnh x
            int[] directionY = { 0, 1, 1, 1, 0, -1, -1, -1 }; // hướng cạnh y
            int[] weightDirection = { 10, 14, 10, 14, 10, 14, 10, 14 };
            for (int x = 0; x < Grid.Count; x++)
            {
                for (int y = 0; y < Grid[x].Count; y++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int neighborX = x + directionX[i];
                        int neighborY = y + directionY[i];
                        if (neighborX >= 0 && neighborY >= 0 && neighborX < Grid.Count && neighborY < Grid[y].Count)
                        {
                            AddEdge(Grid[x][y], Grid[neighborX][neighborY], weightDirection[i]);
                        }
                    }
                }
            }
        }

        Node GetLowestNode()
        {
            return openList.TakeRoot(); // lấy node gốc của min heap
        }
        int HeuristicH(Node currentNode,Node targetNode)
        {
            int dx = Math.Abs(currentNode.X - targetNode.X);
            int dy = Math.Abs(currentNode.Y - targetNode.Y);
            return 10*(dx + dy);
        }
        void GeneratePath(Node node,ref List<Node> path)
        {
            if(node.Parent == null)
            {
                path.Add(node);
                return;
            }
            GeneratePath(node.Parent,ref path);
            path.Add(node);
        }
        public List<Node> FindPath(Node startNode,Node targetNode)
        {
            int count = 0;
            List<Node> path = new List<Node>();
            openList.Add(startNode);
            while(openList.Count > 0)
            {
                Node currentNode = GetLowestNode();
                // không cần loại bỏ node đã xét tới ở list đang xét nữa vì TakeRoot tự xóa node đấy rồi
                closeList.Add(currentNode);
                if(currentNode == targetNode)
                {
                    GeneratePath(currentNode,ref path);
                    Console.WriteLine( "số node được kiểm tra: " + count);
                    return path;
                }

                foreach (Edge edge in currentNode.Edges)
                {
                    if (closeList.Contains(edge.Destination) || edge.Destination.IsWall) continue;

                    int newDistanceG = currentNode.G + edge.Weight;
                    if (openList.Contains(edge.Destination) && edge.Destination.G < newDistanceG) continue;
                    edge.Destination.G = newDistanceG;
                    edge.Destination.Parent = currentNode;
                    edge.Destination.H = HeuristicH(edge.Destination,targetNode);
                    if (!openList.Contains(edge.Destination)) openList.Add(edge.Destination);
                    count++;
                    
                }
            }
            return null;
        }
    }
}
