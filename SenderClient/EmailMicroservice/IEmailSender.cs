namespace SenderClient.EmailMicroservice
{
    public interface IEmailSender
    {
        Task SendReportAsync(string filePath, IEmailBase emailBase);
    }
}