﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AquariumForum.Models;

namespace AquariumForum.Data
{
    public class AquariumForumContext : DbContext
    {
        public AquariumForumContext (DbContextOptions<AquariumForumContext> options)
            : base(options)
        {
        }

        public DbSet<AquariumForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<AquariumForum.Models.Comment> Comment { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discussion>()
                .HasMany(d => d.Comments)
                .WithOne(c => c.Discussion)
                .HasForeignKey(c => c.DiscussionId);
        }

    }
}
