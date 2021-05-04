using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVCFlashCards.Models.ForResponses
{
    public class UserCheckOut
    {
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public  string UserId { get; set; }
        
        public string UserName { get; set; }

        public string UserLanguage { get; set; }
        public int UserLanguageId { get; set; }
    }
}
