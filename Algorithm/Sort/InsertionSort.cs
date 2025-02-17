namespace Sort
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            int temp;
            int compare;

            // 첫 번째 데이터를 key값으로 하여 정렬 시작
            for (int key = 1; key < array.Length; key++)
            {
                // key값 백업
                temp = array[key];
                // key의 바로 앞에 있는 데이터 부터 비교 
                compare = key - 1;

                // 비교할 위치가 유효하고 비교한 값이 key 값보다 큰 동안 반복
                while (compare >= 0 && array[compare] > temp )
                {
                    // 비교한 값을 한칸 뒤로 민다.
                    array[compare + 1] = array[compare];
                    // 그 앞의 값과 비교할 수 있도록 -1 한다.
                    compare--;
                }

                // 반복이 종료되면 마지막으로 비교한 값 바로 뒤에 key값을 삽입한다.
                array[compare + 1] = temp;
            }
        }
    }
}
