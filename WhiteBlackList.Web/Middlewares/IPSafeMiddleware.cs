using Microsoft.Extensions.Options;
using System.Net;

namespace WhiteBlackList.Web.Middlewares
{
    public class IPSafeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPList _ipList;

        public IPSafeMiddleware(RequestDelegate next, IOptions<IPList> ipListoptions)
        {
            _next = next;
            _ipList = ipListoptions.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            IPAddress requestIp = httpContext.Connection.RemoteIpAddress;
            var isWhiteList = _ipList.WhiteList.Where(x => IPAddress.Parse(x).Equals(requestIp)).Any();

            if (!isWhiteList)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            await _next(httpContext);
        }



    }
}
