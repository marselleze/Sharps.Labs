namespace Sharps.Labs.Task2.Lib
{
    public class ArrayOperations
    {
        /// <summary>
        /// Генерирует массив случайных целых чисел
        /// </summary>
        public static int[] GenerateRandomArray(int size, int minValue = 0, int maxValue = 100)
        {
            Random random = new Random();
            int[] array = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
            
            return array;
        }

        /// <summary>
        /// Находит минимальное и максимальное значения в массиве без использования готовых функций
        /// </summary>
        public static void FindMinMax(int[] array, out int min, out int max)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пустым");
            }

            min = array[0];
            max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
        }

        /// <summary>
        /// Сортирует массив методом пузырьковой сортировки (без использования Array.Sort)
        /// </summary>
        public static void SortArray(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Обмен элементов
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        
        public static void PrintArray(int[] array, string label = "")
        {
            if (!string.IsNullOrEmpty(label))
            {
                Console.WriteLine(label);
            }

            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}

