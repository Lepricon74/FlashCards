using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVCFlashCards.Models;
using Microsoft.AspNetCore.Identity;

namespace WebMVCFlashCards.ViewModels
{
    public class IndexViewModel
    {
        public List<User> Users { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public List<LanguageType> Langs { get; set; }

        public IList<User> AdminUsers { get; set; }
    }
}
