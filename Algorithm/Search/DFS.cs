using System.ComponentModel;

namespace Search
{
    public class DFS
    {
        // 스택 기반 구현
        public static void Search(Graph graph, int start)
        {
            int size = graph.GetSize();
            int current = -1;

            // 방문한 정점을 기록할 배열
            bool[] visited = new bool[size];

            // 방문해야 하는 정점을 기록할 스택
            Stack<int> stack = new Stack<int>(size);
            stack.Push(start);

            // 스택에 정점이 있는 동안 반복
            while (stack.Count > 0)
            {
                // 현재 방문할 정점을 pop
                current = stack.Pop();

                // 방문 기록
                if (!visited[current])
                {
                    visited[current] = true;
                    Console.WriteLine(current);
                }

                for (int i = 0; i < size; i++)
                {
                    // 인접한 정점 중 방문하지 않은 정점을 stack에 저장
                    if (!visited[i] && graph.IsConnected(current, i))
                    {
                        stack.Push(i);
                    }
                }
            }
        }

        // 재귀 기반 구현
        public static void Search(Graph graph, int start, out bool[] visited, out int[] parent)
        {
            int size = graph.GetSize();
            // 방문한 정점을 기록할 배열
            visited = new bool[size];
            // 각 정점이 어디를 거쳐 방문되었는지 저장할 배열
            parent = new int[size];
            // 초기화
            for (int i = 0; i < size; i++)
            {
                parent[i] = -1;
            }
            // DFS 시작
            DFSFunc(graph, start, visited, parent);
        }

        // 재귀 호출 하는 함수
        static void DFSFunc(Graph graph, int vertex, bool[] visited, int[] parent)
        {
            int size = graph.GetSize();
            // 방문 기록
            visited[vertex] = true;

            Console.WriteLine(vertex);

            for (int i = 0; i < size; i++)
            {
                // 인접한 정점 중 아직 방문하지 않은 정점을 출발점으로 하여 재귀호출
                if (!visited[i] && graph.IsConnected(vertex, i))
                {
                    parent[i] = vertex;
                    DFSFunc(graph, i, visited, parent);
                }
            }
        }
    }
}
