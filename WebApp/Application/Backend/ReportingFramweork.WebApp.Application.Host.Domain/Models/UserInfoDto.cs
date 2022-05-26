namespace ReportingFramweork.WebApp.Application.Host.Domain.Models
{
    public class UserInfoDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public int UserLevel { get; set; }
        public string TelegramKey { get; set; }
        public string[] Permissions { get; set; }
        //public SkinBase Skin { get; set; }
        public DateTime? LastSyncTimeStamp { get; set; }
    }

    
}