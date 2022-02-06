using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Core
{
    public class User:IdentityUser<string>
    {
        public ICollection<Article> Articles { get; set; }

    }
}
