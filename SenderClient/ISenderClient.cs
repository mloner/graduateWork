using SenderClient.EmailMicroservice;
using SenderClient.JsonModels;

namespace SenderClient;

public interface ISenderClient
{
    void Init(SenderClientSettings settings);

    Task SendReport();
    Task SendReportAsync(string filePath, IEmailBase emailBase);
    Task<string?> SendReportAsync(CustomFile file, IEmailBase emailBase);
}