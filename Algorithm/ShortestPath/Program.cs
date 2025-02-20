using System.Diagnostics;

namespace ShortestPath
{
    public class Program
    {
        const int INF = 9999;
        static void Main(string[] args)
        {
            int[,] graph =
            {
                { INF, 15, INF, 35, INF, INF },     // 0
                { 15, INF, 05, 10, INF, INF },      // 1
                { INF, 05, INF, INF, INF, INF },    // 2
                { 35, 10, INF, INF, 05, INF },      // 3
                { INF, INF, INF, 05, INF, 05 },     // 4
                { INF, INF, INF, INF, 05, INF },    // 5
            };

            Dijkstra.FindPath(graph, 0, out List<int>[] paths);
            int size = graph.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i} : ");
                for (int j = 0; j < paths[i].Count-1; j++)
                {
                    Console.Write($"{paths[i][j]} -> ");
                }
                Console.WriteLine($"{i}");
            }
        }
    }
}
