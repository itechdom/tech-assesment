using justice_technical_assestment.Infrastructure.Exceptions;
using Microsoft.Net.Http.Headers;

namespace justice_technical_assestment.Infrastructure.Services
{
    public class IdentityService
    {
        private IHttpContextAccessor _context;
        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string AccessToken
        {
            get
            {
                return _context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            }
        }

        public string CustomerID
        {
            get
            {
                return GetClaim("CustomerID");
            }
        }

        public string AccountID
        {
            get
            {
                return GetClaim("AccountID");
            }
        }

        private string GetClaim(string type)
        {
            try
            {
                return _context.HttpContext.User.FindFirst(type).Value;
            }
            catch (Exception)
            {
                throw new CustomException(MessageCodes.FEAccessForbidden, technicalMessage: $"access_token error: invalid claim \'{type}\'.");
            }
        }
    }
}
