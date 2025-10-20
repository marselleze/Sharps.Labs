namespace Task1.Generators
{
    /// <summary>
    /// Выводит квадрат.
    /// </summary>
    public class SquarePrinter
    {
        /// <summary>
        /// Возвращает квадрат из звездочек с пропуском центральной позиции.
        /// </summary>
        /// <param name="n">Квадрат из звездочек с пропуском центральной позиции.</param>
        /// <exception cref="ArgumentException">При отрицательном и/или четном числе.</exception>
        public static void PrintStarSquare(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("N должно быть положительным числом", nameof(n));
            }

            if (n % 2 == 0)
            {
                throw new ArgumentException("N должно быть нечетным числом", nameof(n));
            }

            int center = n / 2;

            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                var delimer = i == center && j == center
                    ? " "
                    : "*";

                Console.WriteLine(delimer);
            }

            Console.WriteLine();
            
        }
    }
}
