﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebMVCFlashCards.Models
{
    public class FlashCardsContext : IdentityDbContext<User>
    {
        public DbSet<BasicDeck> BasicDecks { get; set; }
        public DbSet<UserDeck> UsersDecks { get; set; }
        public DbSet<UserCard> UsersCards { get; set; }
        public DbSet<BasicCard> BasicCards { get; set; }
        public DbSet<LanguageType> LanguageTypes { get; set; }

        public FlashCardsContext(DbContextOptions<FlashCardsContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BasicDeck>().HasKey(u => new { u.DeckId});
            modelBuilder.Entity<LanguageType>().HasKey(u => new { u.LanguageId, u.LanguageName });
            modelBuilder.Entity<BasicCard>().HasKey(u => new {u.DeckId, u.CardId });
            modelBuilder.Entity<UserDeck>().HasKey(u => new { u.UserId, u.DeckId });
            modelBuilder.Entity<UserCard>().HasKey(u => new { u.UserId, u.DeckId, u.CardId });
            modelBuilder.Entity<UserCard>().Property(u => u.Rating).HasDefaultValue(0.0);
            modelBuilder.Entity<LanguageType>().HasData(new LanguageType { LanguageId = 1, LanguageName = "English" });
            modelBuilder.Entity<LanguageType>().HasData(new LanguageType { LanguageId = 2, LanguageName = "French" });
        }
    }
}
//dotnet ef migrations add AddProductReviews
//dotnet ef database update
