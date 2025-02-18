namespace Search
{
    public class Graph
    {
        bool[,] matrix;
        
        public Graph(int size)
        {
            matrix = new bool[size, size];
        }

        public void Connect(int start, int end)
        {
            matrix[start, end] = true;
        }

        public void Remove(int start, int end)
        {
            matrix[start, end] = false;
        }

        public bool IsConnected(int start, int end)
        {
            return matrix[start, end];
        }

        public int GetSize()
        {
            return matrix.GetLength(0);
        }
    }
}
