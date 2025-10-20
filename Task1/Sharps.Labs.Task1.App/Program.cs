using Task1.Generators;

Console.WriteLine("Лабораторная работа 1\n");

Console.WriteLine("Задание 1: Генерация последовательности чисел от 1 до N");
Console.WriteLine("N = 7");
string sequence = SequenceGenerator.GenerateNumberSequence(12);
Console.WriteLine($"Результат: {sequence}\n");

Console.WriteLine("Задание 2: Квадрат из звездочек 7x7 без центральной звездочки");
SquarePrinter.PrintStarSquare(7);

Console.WriteLine("\nНажмите любую клавишу для продолжения...");
Console.ReadKey();
