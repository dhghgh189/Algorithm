namespace Search
{
    public class BinarySearch
    {
        public static int Search(int[] array, int target, int low, int high)
        {
            // 종료 조건
            if (low > high)
                return -1;

            // 중간 값 구하기
            int mid = (low + high) / 2;

            // target을 찾았을 때
            if (array[mid] == target)
            {
                return mid;
            }
            // mid가 target보다 클 때
            else if (array[mid] > target)
            {
                return Search(array, target, low, mid - 1);     // 재귀
            }
            // mid가 target보다 작을 때
            else
            {
                return Search(array, target, mid + 1, high);    // 재귀
            }
        }
    }
}
