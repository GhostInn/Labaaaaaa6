namespace Lab6;

public interface IFileReader<T>
{
    List<T> ReadCsv(string filePath);
    List<T> ReadJson(string filePath);
}