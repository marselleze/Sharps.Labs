namespace Sharps.Labs.Task2.Lib
{
    /// <summary>
    /// Структура для хранения данных о человеке.
    /// Struct - value type, хранится в стеке (если не является полем класса).
    /// Содержит поля разных типов для демонстрации.
    /// </summary>
    public struct PersonData
    {
        // Reference type в value type - строка хранится в куче, но ссылка в стеке
        public string Name { get; set; }
        
        // Value types - хранятся в стеке
        public double Weight { get; set; }  // вес в кг
        public double Height { get; set; }  // рост в метрах
        public int Age { get; set; }

        // Конструктор для инициализации
        public PersonData(string name, double weight, double height, int age)
        {
            Name = name;
            Weight = weight;
            Height = height;
            Age = age;
        }

        // Метод для расчета ИМТ
        public double CalculateBMI()
        {
            if (Height <= 0)
            {
                throw new InvalidOperationException("Рост должен быть больше нуля");
            }
            return Weight / (Height * Height);
        }

        // Метод для красивого вывода
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Вес: {Weight} кг, Рост: {Height} м";
        }
    }

    /// <summary>
    /// Класс для сравнения с struct (reference type).
    /// Хранится в куче, передается по ссылке.
    /// </summary>
    public class PersonClass
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }

        public PersonClass(string name, double weight, double height, int age)
        {
            Name = name;
            Weight = weight;
            Height = height;
            Age = age;
        }

        public double CalculateBMI()
        {
            if (Height <= 0)
            {
                throw new InvalidOperationException("Рост должен быть больше нуля");
            }
            return Weight / (Height * Height);
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Вес: {Weight} кг, Рост: {Height} м";
        }
    }
}

