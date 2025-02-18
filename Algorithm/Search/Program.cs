namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 11, 97, 34, 55, 34, 21, 69, 52, 9 };
            int target = 2;
            Console.WriteLine($"Linear Search ({target}) : index {LinearSearch.Search(array, target)}");
        }
    }
}
