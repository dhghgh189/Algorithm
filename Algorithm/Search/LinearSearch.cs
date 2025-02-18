namespace Search
{
    public class LinearSearch
    {
        public static int Search(int[] array, int target)
        {
            // 모든 값 순회
            for (int i = 0; i < array.Length; i++)
            {
                // 목표값을 찾으면 index 반환
                if (array[i] == target)
                    return i;
            }

            // 배열에 목표값이 없었던 경우 -1 반환
            return -1;
        }
    }
}
