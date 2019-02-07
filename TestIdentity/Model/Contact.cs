using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestIdentity.Model
{
    public class Contact: IdentityUser<int, ContactLogin, ContactRole, ContactClaim>
    {
        #region properties
        public string Title { get; set; }

        public string First_Name { get; set; }

        public string Mid_Name { get; set; }

        public string Last_Name { get; set; }

        public bool Enable_Account_Flag { get; set; }

     //   public DateTime Expiration_Date { get; set; }

        public string WelcomeFullName
        {
            get { return string.Format("{0}&nbsp;{1}", First_Name, Last_Name); }
        }

        public RoleTypes UserRole;
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ContactManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}
