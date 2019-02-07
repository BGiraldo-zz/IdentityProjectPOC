using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace IdentityProject.Helpers
{
    public class AuthorizeRole: AuthorizeAttribute
    {
        private List<string> allowedroles = new List<string>();

        public AuthorizeRole(params string[] roles)
        {
            var allRoles = (NameValueCollection)ConfigurationManager.GetSection("CustomRoles");
            foreach (var role in roles)
            {
                allowedroles.AddRange(allRoles[role].Split(new[] { ',' }));
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            var _isAuthorized = false;
            foreach (var role in allowedroles)
            {
                if (HttpContext.Current.User.IsInRole(role.Trim()))
                {
                    _isAuthorized = true;
                    break;
                }
            }
            return _isAuthorized;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }
        /// <summary>
        /// Method to check if the user is Authorized or not
        /// if yes continue to perform the action else redirect to error page
        /// </summary>
        /// <param name="filterContext"></param>
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            // If the Result returns null then the user is Authorized 
            if (filterContext.Result == null)
                return;

            //If the user is Un-Authorized then Navigate to Auth Failed View 
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var data = new ViewDataDictionary
                {
                    { "Message", "Sorry you are not authorized to perform this Action" }
                };
                var view = new ViewResult { ViewName = "Error", ViewData = data };
                filterContext.Result = view;
            }
        }
    }

    public static class RoleBasedEnum
    {
        /// <summary>
        /// Admin, DataAdmin
        /// </summary>
        public const string AdminAccessPermission = "AdminAccessPermission";
        /// <summary>
        /// Admin, DataAdmin, Sponsor
        /// </summary>
        public const string OperatorSponsorAccessPermission = "OperatorSponsorAccessPermission";
        /// <summary>
        /// Admin, DataAdmin, Sponsor, Investigator
        /// </summary>
        public const string OperatorsAccessPermission = "OperatorsAccessPermission";
        public const string GeneralAccessPermission = "GeneralAccessPermission";
        public const string OnlySponsor = "OnlySponsor";
        public const string OnlyAdministrator = "OnlyAdministrator";
        public const string OnlyDataAdministrator = "OnlyDataAdministrator";
        public const string OnlyInvestigator = "OnlyInvestigator";
    }


}
