namespace Sharps.Labs.Task2.Lib
{
    public class TextAnalyzer
    {
        /// <summary>
        /// Вычисляет среднюю длину слова в тексте.
        /// Игнорирует знаки пунктуации при подсчете длины слов.
        /// </summary>
        public static double CalculateAverageWordLength(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            int totalLetters = 0;
            int wordCount = 0;
            int currentWordLength = 0;
            bool inWord = false;

            foreach (char c in text)
            {
                // Проверяем, является ли символ буквой (не пунктуация и не пробел)
                if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
                {
                    currentWordLength++;
                    inWord = true;
                }
                else
                {
                    // Если мы были в слове и встретили разделитель
                    if (inWord && currentWordLength > 0)
                    {
                        totalLetters += currentWordLength;
                        wordCount++;
                        currentWordLength = 0;
                        inWord = false;
                    }
                }
            }

            // Проверяем, не закончился ли текст на слове
            if (inWord && currentWordLength > 0)
            {
                totalLetters += currentWordLength;
                wordCount++;
            }

            if (wordCount == 0)
            {
                return 0;
            }

            return (double)totalLetters / wordCount;
        }

        /// <summary>
        /// Демонстрационный метод с подробным выводом информации
        /// </summary>
        public static void AnalyzeAndPrint(string text)
        {
            Console.WriteLine($"Исходный текст: \"{text}\"");
            
            double average = CalculateAverageWordLength(text);
            
            Console.WriteLine($"Средняя длина слова: {average:F2}");
        }
    }
}

