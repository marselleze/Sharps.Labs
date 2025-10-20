namespace Sharps.Labs.Task2.Lib
{
    public class MemoryDemo
    {
        /// <summary>
        /// Демонстрирует изменение struct без ref - изменения не сохраняются
        /// (передается копия значения)
        /// </summary>
        public static void ModifyValueType(PersonData person)
        {
            Console.WriteLine("  [ModifyValueType] Получен: " + person);
            person.Age = 100;
            person.Name = "Измененное имя";
            Console.WriteLine("  [ModifyValueType] Изменен на: " + person);
        }

        /// <summary>
        /// Демонстрирует изменение struct с ref - изменения сохраняются
        /// (передается ссылка на исходное значение)
        /// </summary>
        public static void ModifyValueTypeByRef(ref PersonData person)
        {
            Console.WriteLine("  [ModifyValueTypeByRef] Получен: " + person);
            person.Age = 200;
            person.Name = "Измененное имя (ref)";
            Console.WriteLine("  [ModifyValueTypeByRef] Изменен на: " + person);
        }

        /// <summary>
        /// Демонстрирует параметр out - переменная должна быть инициализирована в методе
        /// </summary>
        public static void InitializePersonData(out PersonData person)
        {
            // С out параметром мы ОБЯЗАНЫ инициализировать значение
            person = new PersonData("Новый человек", 75.0, 1.80, 30);
            Console.WriteLine("  [InitializePersonData] Создан: " + person);
        }

        /// <summary>
        /// Демонстрирует изменение класса (reference type) - изменения сохраняются
        /// даже без ref, так как передается ссылка
        /// </summary>
        public static void ModifyReferenceType(PersonClass person)
        {
            Console.WriteLine("  [ModifyReferenceType] Получен: " + person);
            person.Age = 300;
            person.Name = "Измененное имя (class)";
            Console.WriteLine("  [ModifyReferenceType] Изменен на: " + person);
        }

        /// <summary>
        /// Демонстрирует принудительную сборку мусора
        /// </summary>
        public static void DemonstrateGarbageCollection()
        {
            Console.WriteLine("\n=== Демонстрация сборки мусора ===");
            
            // Получаем информацию о памяти до создания объектов
            long memoryBefore = GC.GetTotalMemory(false);
            Console.WriteLine($"Память до создания объектов: {memoryBefore} байт");

            // Создаем много объектов, которые станут мусором
            CreateGarbage();

            long memoryAfterCreation = GC.GetTotalMemory(false);
            Console.WriteLine($"Память после создания объектов: {memoryAfterCreation} байт");
            Console.WriteLine($"Разница: {memoryAfterCreation - memoryBefore} байт");

            // Принудительная сборка мусора
            Console.WriteLine("\nВызов принудительной сборки мусора...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryAfterGC = GC.GetTotalMemory(true);
            Console.WriteLine($"Память после сборки мусора: {memoryAfterGC} байт");
            Console.WriteLine($"Освобождено: {memoryAfterCreation - memoryAfterGC} байт");
            
            Console.WriteLine($"\nПоколение GC: {GC.MaxGeneration}");
        }

        private static void CreateGarbage()
        {
            // Создаем временные объекты в локальной области видимости
            List<PersonClass> tempList = new List<PersonClass>();
            for (int i = 0; i < 10000; i++)
            {
                tempList.Add(new PersonClass($"Temporary{i}", 70.0, 1.75, 25));
            }
            // После выхода из метода tempList становится недостижимым
        }

        /// <summary>
        /// Полная демонстрация всех различий между struct и class, ref и out
        /// </summary>
        public static void RunFullDemo()
        {
            Console.WriteLine("\n=== Задача 4: Демонстрация struct, ref, out и GC ===\n");

            // 1. Демонстрация struct без ref
            Console.WriteLine("1. Struct без ref (передача по значению):");
            PersonData structPerson1 = new PersonData("Иван", 80.0, 1.80, 25);
            Console.WriteLine("До вызова метода: " + structPerson1);
            ModifyValueType(structPerson1);
            Console.WriteLine("После вызова метода: " + structPerson1);
            Console.WriteLine("Вывод: изменения НЕ сохранились (передавалась копия)\n");

            // 2. Демонстрация struct с ref
            Console.WriteLine("2. Struct с ref (передача по ссылке):");
            PersonData structPerson2 = new PersonData("Петр", 75.0, 1.75, 30);
            Console.WriteLine("До вызова метода: " + structPerson2);
            ModifyValueTypeByRef(ref structPerson2);
            Console.WriteLine("После вызова метода: " + structPerson2);
            Console.WriteLine("Вывод: изменения сохранились (передавалась ссылка на оригинал)\n");

            // 3. Демонстрация out параметра
            Console.WriteLine("3. Out параметр (обязательная инициализация в методе):");
            PersonData structPerson3;  // Не инициализирована
            InitializePersonData(out structPerson3);
            Console.WriteLine("После вызова метода: " + structPerson3);
            Console.WriteLine("Вывод: out требует инициализации в методе\n");

            // 4. Демонстрация class (reference type)
            Console.WriteLine("4. Class (reference type) без ref:");
            PersonClass classPerson = new PersonClass("Мария", 65.0, 1.65, 28);
            Console.WriteLine("До вызова метода: " + classPerson);
            ModifyReferenceType(classPerson);
            Console.WriteLine("После вызова метода: " + classPerson);
            Console.WriteLine("Вывод: изменения сохранились (class всегда передается по ссылке)\n");

            // 5. Объяснение типов памяти
            Console.WriteLine("=== Типы памяти ===");
            Console.WriteLine("PersonData (struct):");
            Console.WriteLine("  - Сама структура: Value Type (стек, если локальная переменная)");
            Console.WriteLine("  - Поле Name (string): Reference Type (ссылка в стеке, данные в куче)");
            Console.WriteLine("  - Поля Weight, Height (double): Value Type (стек)");
            Console.WriteLine("  - Поле Age (int): Value Type (стек)");
            Console.WriteLine("\nPersonClass (class):");
            Console.WriteLine("  - Весь объект: Reference Type (ссылка в стеке, данные в куче)");
            Console.WriteLine("  - Все поля хранятся в куче вместе с объектом\n");

            // 6. Демонстрация сборки мусора
            DemonstrateGarbageCollection();
        }
    }
}

