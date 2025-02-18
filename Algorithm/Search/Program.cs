namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 11, 97, 34, 55, 21, 69, 52, 9 };
            int[] array2 = { 2, 9, 11, 21, 34, 52, 55, 69, 97};
            int target = 21;
            Console.WriteLine($"Linear Search ({target}) : index {LinearSearch.Search(array, target)}");
            Console.WriteLine($"Binary Search ({target}) : index {BinarySearch.Search(array2, target, 0, array2.Length-1)}");
        }
    }
}
