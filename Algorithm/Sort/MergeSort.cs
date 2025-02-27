namespace Sort
{
    public class MergeSort
    {
        public static void Sort(int[] array, int start, int end)
        {
            // 리스트 요소가 1개면 종료
            if (start == end)
                return;

            // 중간 위치 구하기
            int mid = (start + end) / 2;
            // 왼쪽 부분 리스트 분할
            Sort(array, start, mid);
            // 오른쪽 부분 리스트 분할
            Sort(array, mid+1, end);
            // 분할된 리스트들을 정렬하면서 하나로 병합
            Merge(array, start, mid, end);
        }

        public static void Merge(int[] array, int start, int mid, int end)
        {
            // 병합 결과를 저장할 추가 공간
            List<int> sorted = new List<int>();

            // 왼쪽, 오른쪽 부분리스트의 현재 index를 저장
            // 왼쪽 리스트는 start 부터 mid 까지
            int indexL = start;
            // 오른쪽 리스트는 mid+1 부터 end 까지다.
            int indexR = mid+1;

            // 정렬이 완료된 부분리스트가 없는 동안 반복한다. 
            while (indexL <= mid && indexR <= end)
            {
                // 왼쪽 부분리스트 값이 더 작으면 정렬 리스트에 추가하고
                // 인덱스를 증가한다.
                if (array[indexL] <= array[indexR])
                    sorted.Add(array[indexL++]);
                // 오른쪽 부분리스트 값이 더 작으면 정렬 리스트에 추가하고
                // 인덱스를 증가한다.
                else
                    sorted.Add(array[indexR++]);
            }

            // 한쪽 부분리스트의 정렬이 완료되면 나머지 부분리스트의 값을
            // 바로 정렬리스트에 추가한다.
            // 왼쪽 부분리스트 index가 mid를 넘어섰으면 왼쪽부분리스트가 먼저 정렬된 것이다.
            if (indexL > mid)
            {
                // 오른쪽 부분리스트에 남은 값들을 정렬 리스트에 추가
                // 남은 값 : indexR 부터 end 까지
                for (int i = indexR; i <= end; i++)
                    sorted.Add(array[i]);
            }
            else
            {
                // 왼쪽 부분리스트에 남은 값들을 정렬 리스트에 추가
                // 남은 값 : indexL 부터 mid 까지
                for (int i = indexL; i <= mid; i++)
                    sorted.Add(array[i]);
            }

            // 정렬이 완료되면 전체 list에 반영한다.
            for (int i = 0; i < sorted.Count; i++)
            {
                // start 부터 시작해서 정렬된 갯수만큼 반영
                array[start+i] = sorted[i];
            }
        }
    }
}
