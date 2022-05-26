namespace SenderClient.EmailMicroservice
{
    public interface IEmailMicroserviceClient
    {
        Task<string> SendEmail(IEmailBase email, Guid userGuid);
    }
}