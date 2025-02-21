using System.Reflection.Metadata.Ecma335;

namespace Maze
{
    public class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Init(25);

            // 콘솔에서 커서 출력 감추기
            Console.CursorVisible = false;

            // 프레임 지정
            const int FRAME_RATE = 30;
            // 1000 / FRAME_RATE = 한 프레임당 소요 시간 (ms)
            const int MS_PER_FRAME = 1000 / FRAME_RATE;

            int lastTick = 0;
            // Game Loop
            while (true)
            {
                #region 프레임 관리
                // Environment.TickCount :
                //      컴퓨터가 마지막으로 시작된 이후 경과된 시간(ms)을 포함하는
                //      부호 있는 32bit 정수형 (int)
                // 현재 프레임의 시간을 저장
                int currentTick = System.Environment.TickCount;

                // 현재시간 - 이전시간 = 경과한 시간
                // 경과한 시간이 MS_PER_FRAME 보다 작다면 대기
                if (currentTick - lastTick < MS_PER_FRAME)
                    continue;

                // 마지막 프레임 진행 시간 저장
                lastTick = currentTick;
                #endregion

                // Input
                // Update (Logic)
                // Render

                // 커서 위치를 0, 0으로 설정
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
