using Sharps.Labs.Task2.Lib;

namespace Sharps.Labs.Task2.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 2");


            // Задача 1: Индекс массы тела
            Task1_CalculateBMI();

            Console.WriteLine("\n" + new string('─', 60) + "\n");

            // Задача 2: Операции с массивом
            Task2_ArrayOperations();

            Console.WriteLine("\n" + new string('─', 60) + "\n");

            // Задача 3: Средняя длина слова
            Task3_AverageWordLength();

            Console.WriteLine("\n" + new string('─', 60) + "\n");

            // Задача 4: Struct, ref, out и сборка мусора
            Task4_MemoryDemonstration();

            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Задача 1: Расчет индекса массы тела (ИМТ)
        /// Функция реализована в консольном приложении, как требуется в задании
        /// </summary>
        static void Task1_CalculateBMI()
        {
            Console.WriteLine("=== Задача 1: Расчет индекса массы тела (ИМТ) ===\n");

            try
            {
                // Запрашиваем данные у пользователя
                Console.Write("Введите ваш вес (кг): ");
                string? weightInput = Console.ReadLine();
                double weight = double.Parse(weightInput ?? "0");

                Console.Write("Введите ваш рост (м): ");
                string? heightInput = Console.ReadLine();
                double height = double.Parse(heightInput ?? "0");

                // Расчет ИМТ
                double bmi = CalculateBMI(weight, height);

                // Вывод результата
                Console.WriteLine($"\nРезультат:");
                Console.WriteLine($"Вес: {weight} кг");
                Console.WriteLine($"Рост: {height} м");
                Console.WriteLine($"Индекс массы тела (ИМТ): {bmi:F2}");

                // Интерпретация результата
                string interpretation = GetBMIInterpretation(bmi);
                Console.WriteLine($"Интерпретация: {interpretation}");

                // Дополнительно: демонстрация использования struct PersonData
                Console.WriteLine("\nДополнительно: использование struct PersonData:");
                PersonData person = new PersonData("Пользователь", weight, height, 0);
                double bmiFromStruct = person.CalculateBMI();
                Console.WriteLine($"ИМТ через struct: {bmiFromStruct:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат числа!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Функция расчета ИМТ по формуле: вес / (рост^2)
        /// </summary>
        static double CalculateBMI(double weight, double height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Рост должен быть больше нуля");
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес должен быть больше нуля");
            }

            return weight / (height * height);
        }

        /// <summary>
        /// Интерпретация значения ИМТ
        /// </summary>
        static string GetBMIInterpretation(double bmi)
        {
            if (bmi < 16) return "Выраженный дефицит массы тела";
            if (bmi < 18.5) return "Недостаточная масса тела";
            if (bmi < 25) return "Нормальная масса тела";
            if (bmi < 30) return "Избыточная масса тела (предожирение)";
            if (bmi < 35) return "Ожирение 1 степени";
            if (bmi < 40) return "Ожирение 2 степени";
            return "Ожирение 3 степени";
        }

        /// <summary>
        /// Задача 2: Генерация массива, поиск min/max, сортировка
        /// Без использования LINQ и готовых функций (Sort, Max и т.д.)
        /// </summary>
        static void Task2_ArrayOperations()
        {
            Console.WriteLine("=== Задача 2: Операции с массивом ===\n");

            // Параметры массива
            int arraySize = 15;
            int minValue = 10;
            int maxValue = 100;

            Console.WriteLine($"Генерация массива из {arraySize} элементов (диапазон: {minValue}-{maxValue})...\n");

            // Генерация массива
            int[] array = ArrayOperations.GenerateRandomArray(arraySize, minValue, maxValue);

            // Вывод исходного массива
            ArrayOperations.PrintArray(array, "Исходный массив:");

            // Поиск минимального и максимального значений
            ArrayOperations.FindMinMax(array, out int min, out int max);
            Console.WriteLine($"\nМинимальное значение: {min}");
            Console.WriteLine($"Максимальное значение: {max}");

            // Создаем копию для сортировки (чтобы сохранить исходный массив)
            int[] sortedArray = (int[])array.Clone();

            // Сортировка массива (пузырьковая сортировка)
            Console.WriteLine("\nСортировка массива (метод пузырьковой сортировки)...");
            ArrayOperations.SortArray(sortedArray);

            // Вывод отсортированного массива
            ArrayOperations.PrintArray(sortedArray, "\nОтсортированный массив:");
        }

        /// <summary>
        /// Определение средней длины слова в строке без использования регулярных выражений
        /// </summary>
        static void Task3_AverageWordLength()
        {
            Console.WriteLine("=== Задача 3: Средняя длина слова в тексте ===\n");

            Console.Write("Введите текст для анализа: ");
            string? text = Console.ReadLine();

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Текст не введен!");
                return;
            }

            TextAnalyzer.AnalyzeAndPrint(text);

            // Дополнительные примеры
            Console.WriteLine("\n--- Дополнительные примеры ---");
            
            string[] examples = {
                "Привет, мир!",
                "Это пример текста с различной пунктуацией: точками, запятыми и т.д.",
                "C# - отличный язык программирования!"
            };

            foreach (string example in examples)
            {
                Console.WriteLine();
                TextAnalyzer.AnalyzeAndPrint(example);
            }
        }

        /// <summary>
        /// Задача 4: Демонстрация struct, ref, out и сборки мусора
        /// </summary>
        static void Task4_MemoryDemonstration()
        {
            // Запускаем полную демонстрацию из класса MemoryDemo
            MemoryDemo.RunFullDemo();
        }
    }
}
