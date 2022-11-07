using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Net;
using WhiteBlackList.Web.Middlewares;

namespace WhiteBlackList.Web.Filters
{
    public class CheckWhiteListFilter : ActionFilterAttribute
    {
        private readonly IPList _ipList;
        public CheckWhiteListFilter(IOptions<IPList> ipListOptions)
        {
            _ipList = ipListOptions.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress requestIp = context.HttpContext.Connection.RemoteIpAddress;
            bool isWhiteList = _ipList.WhiteList.Where(x => IPAddress.Parse(x).Equals(requestIp)).Any();

            if (!isWhiteList)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
