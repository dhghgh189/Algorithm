namespace Maze
{
    public class Board
    {
        const char CIRCLE = '\u25cf';

        // 한칸 한칸의 tile
        public TileType[,] tiles;
        public int size;

        public enum TileType { Empty, Wall, }

        public void Init(int size)
        {
            // size는 홀수만 가능
            if (size % 2 == 0)
                return;

            this.size = size;
            tiles = new TileType[size, size];

            // Binary Tree를 통한 미로 생성
            //ExecuteBinaryTree();

            // Side Winder를 통한 미로 생성
            ExecuteSideWinder();
        }

        void ExecuteBinaryTree()
        {
            // 1. 짝수 칸 타일을 모두 벽으로 만든다.
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // x 혹은 y축이 짝수인 칸이면
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        // 벽으로 처리
                        tiles[y, x] = TileType.Wall;
                    }
                    else
                    {
                        // 짝수가 아니면 비워둔다.
                        tiles[y, x] = TileType.Empty;
                    }
                }
            }

            // 난수 생성을 위한 Random 인스턴스
            Random rand = new Random();

            // 2. 홀수 칸을 돌면서 길을 뚫는다.
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // 짝수칸이면 pass
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    // 마지막 위치면 pass
                    if (x == size - 2 && y == size - 2)
                        continue;

                    // 현재 순회 위치가 x축 가장자리인 경우
                    if (x == size - 2)
                    {
                        // 반드시 아래로 뚫는다.
                        tiles[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 현재 순회 위치가 y축 가장자리인 경우
                    if (y == size - 2)
                    {
                        // 반드시 우측으로 뚫는다.
                        tiles[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    // 우측 혹은 아래 중 랜덤으로 길을 뚫는다.
                    if (rand.Next(0, 2) == 0)
                    {
                        tiles[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        tiles[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        void ExecuteSideWinder()
        {
            // 1. 짝수 칸 타일을 모두 벽으로 만든다.
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // x 혹은 y축이 짝수인 칸이면
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        // 벽으로 처리
                        tiles[y, x] = TileType.Wall;
                    }
                    else
                    {
                        // 짝수가 아니면 비워둔다.
                        tiles[y, x] = TileType.Empty;
                    }
                }
            }

            // 난수 생성을 위한 Random 인스턴스
            Random rand = new Random();

            // 2. 홀수 칸을 돌면서 길을 뚫는다.
            for (int y = 0; y < size; y++)
            {
                // 연속으로 지나온 지점의 수를 저장
                int count = 0;

                for (int x = 0; x < size; x++)
                {
                    // 짝수칸이면 pass
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    // 마지막 위치면 pass
                    if (x == size - 2 && y == size - 2)
                    {
                        continue;
                    }

                    // 현재 순회 위치가 x축 가장자리인 경우
                    if (x == size-2)
                    {
                        // 반드시 아래로 뚫는다.
                        tiles[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 현재 순회 위치가 y축 가장자리인 경우
                    if (y == size-2)
                    {
                        // 반드시 우측으로 뚫는다.
                        tiles[y, x + 1] = TileType.Empty;
                        continue;
                    }  

                    // 1. 방향을 랜덤하게 선정한다
                    // 1-1. 수평이면 길을 뚫고 count를 증가시킨다.
                    if (rand.Next(0, 2) == 0)
                    {
                        tiles[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    // 1-2. 수평이 아니라면 연속으로 지나온 지점중 하나를 선택하여
                    // 아래 방향으로 길을 뚫은 다음 count를 초기화 한다.
                    else
                    {
                        // 현재 x위치 - 랜덤한 지점(2 * random) = 선정된 지점
                        // (홀수 지점만 길을 뚫기 때문에 2를 곱하여 짝수칸을 건너띈다.)
                        int selectedPoint = x - (2 * rand.Next(0, count+1));
                        // 선택된 x위치의 바로 아래에 길을 뚫는다.
                        tiles[y + 1, selectedPoint] = TileType.Empty;
                        // 연속적인 수평 진행이 끊겼으므로 count를 초기화 한다.
                        count = 0;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prev = Console.ForegroundColor;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {                  
                    // 색상 설정
                    Console.ForegroundColor = GetTileColor(tiles[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prev;
        }

        public ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
