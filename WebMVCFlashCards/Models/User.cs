using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace WebMVCFlashCards.Models
{
    public class User : IdentityUser
    {
        //public string Id { get; set; }
        //public string Login { get; set; }
        //public string Password { get; set; }
        public int LanguageId{ get; set; }

    }
}
