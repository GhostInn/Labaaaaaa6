namespace Lab6;

public interface IFileReader<T>
{
    // Этот метод должен реализовываться в классах, реализующих интерфейс IFileReader<T>.
    // Он предназначен для чтения файла по указанному пути и возврата последовательности объектов типа T.
    IEnumerable<T> Read(string filePath);
}