
namespace PdfReportTemplaterClient;

public interface IPdfReportTemplaterClient
{
    Task<string> CreateReportAsync(object data, int templateId);
    Task<string> GetEditorLinkAsync(string token);
}