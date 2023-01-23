
using Application.Contracts.Infrastructure;
using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace AppInfrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv()
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                //using var csvWriter = new CsvWriter(streamWriter);
                //csvWriter.WriteRecords();
            }

            return memoryStream.ToArray();
        }
    }
}
