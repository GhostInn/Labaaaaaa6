using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Lab6;

public class CsvFileReader<T> : IFileReader<T>
{
    public List<T> ReadCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
        {
            var records = new List<T>(csv.GetRecords<T>());
            return records;
        }
    }

    public List<T> ReadJson(string filePath)
    {
        // Реализация чтения JSON не нужна для этого класса
        throw new NotImplementedException("JSON reading is not implemented in CsvFileReader");
    }
}