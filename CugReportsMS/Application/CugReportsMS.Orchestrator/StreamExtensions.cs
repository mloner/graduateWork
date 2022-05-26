using System.IO;
using System.Threading.Tasks;

namespace ReportingOrchestrator;

public static class StreamExtensions
{
    public static async Task<byte[]> ToByteArrayAsync(this Stream input)
    {
        using var ms = new MemoryStream();
        await input.CopyToAsync(ms);
        return ms.ToArray();
    }
}