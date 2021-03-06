﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Songrics.Data.Models;

namespace Songrics.Data
{
    public class SongricsContext : IdentityDbContext<SongricsUser>
    {
        public SongricsContext(DbContextOptions<SongricsContext> options)
            : base(options)
        {
        }

        //public DbSet<Category> Categories { get; set; }

        public DbSet<Lyric> Lyrics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
