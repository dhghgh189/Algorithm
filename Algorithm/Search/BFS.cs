using System.Diagnostics;

namespace Search
{
    public class BFS
    {
        public static void Search(Graph graph, int start, out bool[] visited, out int[] parent)
        {
            int size = graph.GetSize();

            // 방문 여부를 저장할 배열
            visited = new bool[size];
            // 각 정점을 발견한 노드를 저장할 배열
            parent = new int[size];
            // 방문 예정 정점을 저장하기 위한 큐
            Queue<int> queue = new Queue<int>(size);

            int current = -1;

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            // 시작 정점은 미리 방문 처리
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                // 큐에서 현재 정점 번호를 꺼낸다.
                current = queue.Dequeue();
                Console.WriteLine($"{current}");
                    
                for (int i = 0; i < size; i++)
                {
                    // 인접한 정점이 아직 방문되지 않았다면 방문 예약
                    if (!visited[i] && graph.IsConnected(current, i))
                    {
                        visited[i] = true;
                        parent[i] = current;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
