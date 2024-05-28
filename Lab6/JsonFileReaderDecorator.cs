using Newtonsoft.Json;
namespace Lab6;

public class JsonFileReaderDecorator<T> : IFileReader<T>
{
    // Это поле содержит объект, который будет декорироваться.
    private readonly IFileReader<T> _decorated;

    // Этот конструктор принимает объект, который будет декорироваться.
    public JsonFileReaderDecorator(IFileReader<T> decorated)
    {
        _decorated = decorated;
    }

    // Этот метод реализует интерфейс IFileReader<T> и предназначен для чтения JSON-файла по указанному пути.
    public IEnumerable<T> Read(string filePath)
    {
        // Проверяем, что путь к файлу не пустой.
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));
        }

        // Проверяем, что файл существует.
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        // Читаем файл целиком.
        var json = File.ReadAllText(filePath);

        // Преобразуем JSON в объект, используя библиотеку Newtonsoft.Json.
        var objects = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

        // Возвращаем преобразованный объект.
        return objects;
    }
}