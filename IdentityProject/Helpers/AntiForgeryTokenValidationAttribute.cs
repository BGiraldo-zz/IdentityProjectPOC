using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace IdentityProject.Helpers
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AntiForgeryTokenValidationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                ValidateRequestHeader(filterContext.HttpContext.Request);
            }
            catch (HttpAntiForgeryException)
            {
                throw new HttpAntiForgeryException("Anti forgery token cookie not found");
            }
        }
        private static void ValidateRequestHeader(HttpRequestBase request)
        {
            var cookieToken = String.Empty;
            var formToken = String.Empty;
            var tokenValue = request.Headers["X_CSRF_TOKEN"];
            if (!String.IsNullOrEmpty(tokenValue))
            {
                var tokens = tokenValue.Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }
            AntiForgery.Validate(cookieToken, formToken);
        }
    }
}