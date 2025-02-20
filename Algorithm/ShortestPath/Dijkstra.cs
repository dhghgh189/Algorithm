namespace ShortestPath
{
    public class Dijkstra
    {
        public static void FindPath(int[,] graph, int start, out List<int>[] paths)
        {
            int size = graph.GetLength(0);
            // 각 정점들의 최단거리를 저장할 배열
            int[] distance = new int[size];
            // 각 정점들의 방문여부를 저장할 배열
            bool[] visited = new bool[size];
            // 각 정점이 어디에서 발견됬는지 저장할 배열
            int[] parent = new int[size];

            // distance는 큰값으로 초기화한다.
            Array.Fill(distance, 9999);
            Array.Fill(parent, -1);

            // 시작지점의 distance는 0이다.
            distance[start] = 0;
            // 시작지점의 부모는 자신과 동일하게 설정한다.
            parent[start] = start;

            while (true)
            {
                // 현재 최단거리를 저장하기 위한 변수
                int minCost = 9999;
                // 방문할 정점 번호를 저장하기 위한 변수
                int now = -1;

                // 모든 정점 확인
                for (int i = 0; i < size; i++)
                {
                    // 이미 방문한 정점은 pass
                    if (visited[i])
                        continue;

                    // 최단 거리를 가지는 정점이 아니면 pass
                    if (distance[i] >= minCost)
                        continue;

                    // 아직 방문하지 않았으면서 최단 거리인 정점을 저장
                    now = i;
                    minCost = distance[i];
                }

                // 조건에 맞는 정점이 하나도 없었다면 전체 탐색 종료
                if (now == -1)
                    break;

                // 최단 거리로 선정된 정점을 방문
                visited[now] = true;

                for (int next = 0; next < size; next++)
                {
                    // 선정된 정점 now로부터 다른 정점으로 향하는 모든 거리를 계산
                    // (now 까지의 거리) + (now 에서 다른 정점으로 향하는 거리)
                    int nextDist = distance[now] + graph[now, next];

                    if (distance[next] > nextDist)
                    {
                        // 새로 계산된 거리가 기존 거리보다 가까우면 교체
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }

            // 경로를 저장하기 위한 배열
            paths = new List<int>[size];

            for (int i = 0; i < size; i++)
            {
                // 정점 i 부터 시작
                int now = i;
                // 정점 i 까지의 경로를 저장할 list 초기화
                paths[i] = new List<int>();
                // i로 향하는 첫 정점 전까지 반복
                // now의 parent가 now와 같으면 첫 정점인 것이다.
                while (now != parent[now])
                {
                    // 정점 저장
                    paths[i].Add(now);
                    // 저장한 정점의 부모를 저장
                    now = parent[now];
                }

                // 첫 정점이 저장 안 된 상태라 수동으로 저장
                paths[i].Add(now);
                // 역추적 했기 때문에 순서를 뒤집는다.
                paths[i].Reverse();
            }
        }
    }
}
