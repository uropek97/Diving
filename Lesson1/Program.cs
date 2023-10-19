namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = CreateMatrix(3,3);
            Console.WriteLine("Созданная матрица: ");
            PrintMatrix(matrix);

            Console.WriteLine("___________________");

            var newMatrix = SortNewMatrix(matrix);
            Console.WriteLine("Отсортирована новая матрица. \nСтарая матрица: ");
            PrintMatrix(matrix);

            Console.WriteLine("___________________");

            Console.WriteLine("Новая отсортированная матрица: ");
            PrintMatrix(newMatrix);

            Console.WriteLine("___________________");

            SortMatrix(matrix);
            Console.WriteLine("Старая отсортировання матрица: ");
            PrintMatrix(matrix);

            //Controller ctrl = new Controller(args);
            //ctrl.Start();
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] CreateMatrix(int length, int height)
        {
            Random rdm = new Random();

            int[,] matrix = new int[length, height];
            for(int i = 0; i < length; i++)
            {
                for( int j = 0; j < height; j++)
                {
                    matrix[i, j] = rdm.Next(1, 10);
                }
            }

            return matrix;
        }

        public static int[,] CreateMatrix()
        {
            Random rdm = new Random();
            return CreateMatrix(rdm.Next(2, 10), rdm.Next(2, 10));
        }

        public static void SortMatrix(int[,] matrix)
        {
            FirstPart(matrix, out int[] arr);

            SecondPart(matrix, arr);
        }

        public static int[,] SortNewMatrix(int[,] matrix)
        {
            FirstPart(matrix,out int[] arr);

            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            SecondPart(newMatrix, arr);
            return newMatrix;
        }

        //Изначально был один метод. Но потом увидел, что у нас возможны два варианта:
        //или отсортировать имеющийся двумерный массив, или создать новый и вернуть отсортированный. 
        //Всё зависило бы от реальной имеющейся задачи. Поэтому имеются два метода,
        //но чтобы не дублировать код выделил две повторяющиеся части.
        private static void FirstPart(int[,] matrix, out int[] arr)
        {
            arr = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr[k] = matrix[i, j];
                    k++;
                }
            }
            Array.Sort (arr);
        }
        private static void SecondPart(int[,] matrix, int[] arr)
        {
            int k = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j =0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[k];
                    k++;
                }
            }
        }
    }
}