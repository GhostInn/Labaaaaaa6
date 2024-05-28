namespace Lab6;

public class CsvFileReader<T> : IFileReader<T>
{
    // Это поле содержит делегат для преобразования массива строк в объект.
    private readonly Func<string[], T> _mapper;

    // Этот конструктор принимает делегат для преобразования массива строк в объект.
    public CsvFileReader(Func<string[], T> mapper)
    {
        _mapper = mapper;
    }

    // Этот метод реализует интерфейс IFileReader<T> и предназначен для чтения CSV-файла по указанному пути.
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

        // Создаем объект StreamReader для чтения файла.
        using (var reader = new StreamReader(filePath))
        {
            // Пропускаем первую строку, если она содержит заголовки.
            reader.ReadLine();

            // Читаем файл построчно.
            while (!reader.EndOfStream)
            {
                // Разбиваем строку на массив строк, используя запятую в качестве разделителя.
                var values = reader.ReadLine().Split(',');

                // Преобразуем массив строк в объект, используя делегат _mapper.
                yield return _mapper(values);
            }
        }
    }
}