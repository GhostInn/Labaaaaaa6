using System.Globalization;
namespace Lab6;

public static class Program
{
    // Этот метод является точкой входа в приложение.
    public static void Main()
    {
        // Чтение CSV
        IFileReader<MyData> csvReader = new CsvFileReader<MyData>();
        var csvRecords = csvReader.ReadCsv("data.csv");
        Console.WriteLine("CSV Records:");
        foreach (var record in csvRecords)
        {
            Console.WriteLine($"Id: {record.Id}, Name: {record.Name}");
        }

        // Чтение JSON с использованием декоратора
        IFileReader<MyData> fileReader = new FileReaderDecorator<MyData>(csvReader);
        var jsonRecords = fileReader.ReadJson("data.json");
        Console.WriteLine("\nJSON Records:");
        foreach (var record in jsonRecords)
        {
            Console.WriteLine($"Id: {record.Id}, Name: {record.Name}");
        } 
    }
}