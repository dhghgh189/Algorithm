namespace Sort
{
    public class BubbleSort
    {
        public static void Sort(int[] array)
        {
            // 마지막 인덱스부터 0까지 반복
            for (int i = array.Length-1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    // 첫번째 데이터부터 바로 앞에 있는(인접한) 데이터와 비교
                    // 앞에 있는 데이터가 더 큰 경우 서로 교체
                    if (array[j] > array[j + 1])
                        Utils.Swap(array, j, j + 1);
                }
            }
        }
    }
}
