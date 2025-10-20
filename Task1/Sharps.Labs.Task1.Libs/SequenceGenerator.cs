namespace Task1.Generators
{
    /// <summary>
    /// Генератор последовательностей.
    /// </summary>
    public class SequenceGenerator
    {
        /// <summary>
        /// Возвращает последовательность из чисел.
        /// </summary>
        /// <param name="n">Длина последовательости.</param>
        /// <returns>Последовательность чисел.</returns>
        /// <exception cref="ArgumentException">При отрицательном числе.</exception>
        public static string GenerateNumberSequence(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("N должно быть положительным числом", nameof(n));
            }

            return string.Join(",", Enumerable.Range(1, n));
        }

    }
}
