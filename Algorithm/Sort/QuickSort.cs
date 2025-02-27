namespace Sort
{
    public class QuickSort
    {
        public static void Sort(int[] array, int start, int end)
        {
            // 리스트 요소가 1개 이하면 종료
            if (start > end)
                return;

            // start ~ end 범위의 요소들을 분할한다.
            int pivot = Partition(array, start, end);

            // 분할 후 pivot을 기준으로 왼쪽을 다시 정렬 
            Sort(array, start, pivot - 1);
            // 분할 후 pivot을 기준으로 오른쪽을 다시 정렬
            Sort(array, pivot + 1, end);
        }

        public static int Partition(int[] array, int start, int end)
        {
            // 시작점이 pivot
            int pivot = start;
            // pivot을 제외한 첫번째 값은 low
            int low = pivot + 1;
            // 마지막 값은 high
            int high = end;

            // low가 high를 넘어서기 전 까지 반복
            while (low <= high)
            {
                // low가 가리키는 값이 pivot보다 작으면 지나간다.
                // 요소가 내림차순으로 정렬되있던 경우 low가 high를 넘어서기 위해서는
                // 배열의 마지막 인덱스 보다 한칸 더 넘어가야 한다. (low <= end)
                //      low가 high를 넘어서면 swap시 low는 사용되지 않으므로 문제없음 
                while (low <= end && array[pivot] >= array[low])
                    low++;
                // high가 가리키는 값이 pivot보다 크면 지나간다.
                // high의 경우 마찬가지로 요소가 오름차순일 때 배열의 첫 위치까지 이동하는데,
                // high는 swap 시 사용되므로 배열의 첫 인덱스보다 작으면 안된다 (high > start)
                while (high > start && array[pivot] <= array[high])
                    high--;

                // low가 high를 넘어서지 않았으면 low와 high를 교환한다.
                if (low < high)
                {
                    Utils.Swap(array, low, high);
                }
            }

            // 여기로 도달했다는 것은 low가 high를 넘어섰다는 것이므로
            // high와 pivot을 교체한다.
            Utils.Swap(array, pivot, high);

            // high와 pivot이 교체된 후에는 high의 위치가 pivot 위치이므로
            // 최종적으로 high 위치를 반환한다.
            return high;
        }
    }
}
