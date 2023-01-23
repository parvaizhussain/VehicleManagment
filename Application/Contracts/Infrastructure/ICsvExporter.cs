
using System.Collections.Generic;

namespace Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv();
    }
}
