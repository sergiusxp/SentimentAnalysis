﻿using Microsoft.EntityFrameworkCore;
using PowerFeedback.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedback.Api.Models
{
    public class PfDbContext : DbContext
    {
        public PfDbContext(DbContextOptions<PfDbContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sentiment> Sentiments { get; set; }
        public DbSet<TextEntity> TextEntities { get; set; }
        public DbSet<TextEntityMatch> TextEntitiesMatch { get; set; }
        public DbSet<KeyPhrase> KeyPhrases { get; set; }
    }
}
