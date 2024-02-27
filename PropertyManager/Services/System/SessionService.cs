using System.Reflection;
using System.Security.Claims;
using System.Text;
using Interfaces.System;
using Microsoft.AspNetCore.Http;

namespace Services.SystemServices
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            MachineInfo = GetMachineInfoFromHttpContext();
        }


        public string MachineInfo { get; }

        internal string GetMachineInfoFromHttpContext()
        {
            try
            {
                var connectingIP = _httpContextAccessor.HttpContext.Request.Headers["CF-Connecting-IP"];
                StringBuilder ip = new StringBuilder(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());

                if (connectingIP.Count > 0)
                {
                    ip.Append($" | {connectingIP}");
                }

                return ip.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

