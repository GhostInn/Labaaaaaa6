using Newtonsoft.Json;

namespace Lab6;

public class FileReaderDecorator<T> : IFileReader<T>
{
    private readonly IFileReader<T> _fileReader;

    public FileReaderDecorator(IFileReader<T> fileReader)
    {
        _fileReader = fileReader;
    }

    public List<T> ReadCsv(string filePath)
    {
        return _fileReader.ReadCsv(filePath);
    }

    public List<T> ReadJson(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var records = JsonConvert.DeserializeObject<List<T>>(jsonData);
        return records;
    }
}