using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityDataContext :IdentityDbContext<ApplicationUser>
    {

        //aynı veritabanını kullanıcam farklı veritabanıda da kullanabiliriz dataConnection yerine web.configte
        public IdentityDataContext() : base("dataConnection")
        {
            
        }
    }
}