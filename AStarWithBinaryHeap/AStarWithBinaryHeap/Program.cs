using System.Diagnostics;

namespace AStarWithBinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("đi từ: ");
            Console.WriteLine("nhập x: ");
            int xStart = int.Parse(Console.ReadLine());
            Console.WriteLine("nhập y");
            int yStart = int.Parse(Console.ReadLine());
            Console.WriteLine("đi đến:");
            Console.WriteLine("nhập x: ");
            int xEnd = int.Parse(Console.ReadLine());
            Console.WriteLine("nhập y: ");
            int yEnd = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = new Stopwatch();
            
            Astar aStar = new Astar(10, 5);
            aStar.SetWall(aStar.Grid[3][1]);
            aStar.SetWall(aStar.Grid[3][2]);
            aStar.SetWall(aStar.Grid[4][2]);
            aStar.SetWall(aStar.Grid[5][2]);
            aStar.SetWall(aStar.Grid[6][2]);
            aStar.SetWall(aStar.Grid[7][2]);
            stopwatch.Start();
            List<Node> path = aStar.FindPath(aStar.Grid[xStart][yStart], aStar.Grid[xEnd][yEnd]);
            stopwatch.Stop();
            if (path != null)
            {
                Console.WriteLine($"đường đi từ {xStart}:{yStart} -> {xEnd}:{yEnd}");
                foreach (Node node in path)
                {
                    Console.Write($"node({node.X}:{node.Y}) ");
                }
            }
            else Console.WriteLine($"không có đường đi từ {xStart}:{yStart} -> {xEnd}:{yEnd}");
            
            TimeSpan elapsedTime = stopwatch.Elapsed;
            double timeTaken = elapsedTime.TotalMilliseconds;

            // In ra thời gian chạy
            Console.WriteLine();
            Console.WriteLine("Thời gian chạy: " + timeTaken + " milliseconds");
        }
    }
}
