namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 2, 11, 97, 34, 55, 21, 69, 52, 9 };
            //int[] array2 = { 2, 9, 11, 21, 34, 52, 55, 69, 97};
            //int target = 21;
            //Console.WriteLine($"Linear Search ({target}) : index {LinearSearch.Search(array, target)}");
            //Console.WriteLine($"Binary Search ({target}) : index {BinarySearch.Search(array2, target, 0, array2.Length-1)}");

            Graph graph = new Graph(7);
            graph.Connect(0, 1);    graph.Connect(0, 3);
            graph.Connect(1, 0);    graph.Connect(1, 2);
            graph.Connect(2, 1);    graph.Connect(2, 3);    graph.Connect(2, 4);    graph.Connect(2, 5);
            graph.Connect(3, 0);    graph.Connect(3, 2);
            graph.Connect(4, 2);    graph.Connect(4, 6);
            graph.Connect(5, 2);
            graph.Connect(6, 4);

            DFS.Search(graph, 0);
            Console.WriteLine("=====================");
            DFS.Search(graph, 0, out bool[] visited, out int[] parent);
        }
    }
}
