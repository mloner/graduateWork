using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReportingFramework.Dto
{
    public interface IReportingGenerator
    {
        Task<IReportGenerator> GenerateAsync(JsonElement reportModelJson, Guid reportGuid);
        Task<CustomFile> GetReportWithDataAsync(Guid reportGuid);
    }
}