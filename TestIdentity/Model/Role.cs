using Microsoft.AspNet.Identity.EntityFramework;

namespace TestIdentity.Model
{
    public class Role : IdentityRole<int, ContactRole>
    {
        public string Index_Url { get; set; }
        public int Role_Level { get; set; }

    }
}
