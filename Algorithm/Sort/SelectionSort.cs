namespace Sort
{
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            // 최소값을 저장할 변수
            int minIndex = -1;

            // n-1 회전 수행
            for (int i = 0; i < array.Length-1; i++)
            {
                // 현재 위치를 기준으로 삼는다.
                minIndex = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    // 나머지 위치들과 비교하면서 최소값을 찾는다.
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }

                // 최소값을 찾으면 교체한다.
                if (minIndex != i)
                    Utils.Swap(array, i, minIndex);
            }
        }
    }
}
