namespace Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 7, 6, 5, 4, 3 };
            int[] array2 = { 6, 7, 5, 3, 1 };
            int[] array3 = { 8, 1, 6, 2, 5 };

            //SelectionSort.Sort(array);
            //SelectionSort.Sort(array2);
            //SelectionSort.Sort(array3);

            InsertionSort.Sort(array);
            InsertionSort.Sort(array2);
            InsertionSort.Sort(array3);

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
        }
    }
}
