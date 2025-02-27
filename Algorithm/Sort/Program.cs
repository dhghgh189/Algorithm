namespace Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 6, 7, 5, 3, 1 };
            int[] array3 = { 8, 1, 6, 2, 5 };
            int[] array4 = { 5, 4, 3, 2, 1 };

            //SelectionSort.Sort(array);
            //SelectionSort.Sort(array2);
            //SelectionSort.Sort(array3);

            //InsertionSort.Sort(array);
            //InsertionSort.Sort(array2);
            //InsertionSort.Sort(array3);

            //BubbleSort.Sort(array);
            //BubbleSort.Sort(array2);
            //BubbleSort.Sort(array3);

            MergeSort.Sort(array, 0, array.Length-1);
            MergeSort.Sort(array2, 0, array2.Length-1);
            MergeSort.Sort(array3, 0, array3.Length-1);
            MergeSort.Sort(array4, 0, array4.Length-1);

            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in array2)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in array3)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in array4)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            //Random rand = new Random();
            //int[] array5 = new int[10];
            //for (int i = 0; i < array5.Length; i++)
            //{
            //    int number = rand.Next(1, 101);
            //    Console.Write($"{number} ");
            //    array5[i] = number;
            //}
            //Console.WriteLine("\n");

            //QuickSort.Sort(array5, 0, array5.Length-1);
            //foreach (int i in array5)
            //{
            //    Console.Write($"{i} ");
            //}
            //Console.WriteLine();
        }
    }
}
