using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebMVCFlashCards.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System;

namespace WebMVCFlashCards.Controllers
{
    [Route("[controller]")]
    public class BasicDecksController : ControllerBase
    {
        FlashCardsContext db;
        public BasicDecksController(FlashCardsContext context)
        {
            db = context;          
        }

        [HttpGet]
        public JsonResult GetAllBasicDecks()
        {
            if ((Int32.TryParse(Request.Query["langid"].ToString(), out int langId) == false) || (langId < 1)) return new JsonResult("Incorrect Deck Id");
            return new JsonResult(db.BasicDecks.Where(basucDeck => basucDeck.LanguageId== langId).ToList());
        }
        /* Пока не нужно
        [HttpGet("{count}")]
        public JsonResult GetAllBasicDecksCount()
        {
            return new JsonResult(db.BasicDecks.Count());
        }
        */

    }
}