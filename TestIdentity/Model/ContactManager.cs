using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace TestIdentity.Model
{
    public class ContactManager : UserManager<Contact, int>
    {
        public ContactManager(IUserStore<Contact, int> store) : base(store)
        {
        }

        public static ContactManager Create(IdentityFactoryOptions<ContactManager> options, IOwinContext context)
        {
            var manager = new ContactManager(new UserStore<Contact, Role, int, ContactLogin, ContactRole, ContactClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Contact, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            /* GRAN-267: Login: Forgot Pasword Function: Reset.
             * Passwords must be minimum of 8 characters in length, 
             * contain at least 1 number and 
             * 1 special character, 
             * and not to include user's first name, 
             * last name or login.*/
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };

          //  manager.PasswordHasher = new PasswordHelper();


            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Contact, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Contact, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Contact, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

    }
}
