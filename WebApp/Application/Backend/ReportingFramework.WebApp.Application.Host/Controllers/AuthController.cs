using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReportingFramweork.WebApp.Application.Host.Domain.Models;

namespace ReportingFramweork.WebApp.Backend.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }
        
        
        [Route("user-info")]
        public async Task<UserInfoDto> GetUserInfo()
        {
            var result = new UserInfoDto()
            {
                Username = User.FindFirstValue(ClaimTypes.Name),
                Role = User.FindFirstValue(ClaimTypes.Role),
            };
            
            return result;
        }
    }
}