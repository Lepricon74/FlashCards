using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVCFlashCards.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
                    
        public string Translation { get; set; }

        public string Rus { get; set; }

        public double Rating { get; set; }
    }
}
