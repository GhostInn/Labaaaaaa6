using System.Globalization;
namespace Lab6;

public static class Program
{
    // Этот метод является точкой входа в приложение.
    public static void Main()
    {
        // Создаем экземпляр класса CsvFileReader<Person> и передаем в него делегат для преобразования массива строк в объект Person.
        var csvReader = new CsvFileReader<Person>(values => new Person
        {
            Name = values[0],
            Age = int.Parse(values[1], CultureInfo.InvariantCulture)
        });

        // Создаем экземпляр класса JsonFileReaderDecorator<Person> и передаем в него созданный ранее экземпляр класса CsvFileReader<Person>.
        var jsonReader = new JsonFileReaderDecorator<Person>(csvReader);

        // Читаем JSON-файл с помощью созданного ранее экземпляра класса JsonFileReaderDecorator<Person> и выводим информацию о каждом человеке на консоль.
        foreach (var person in jsonReader.Read("persons.json"))
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}