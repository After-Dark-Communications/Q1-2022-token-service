using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OneTimeAccess.Models
{
    public class OneTimeAccessTokenContext : DbContext
    {
        public DbSet<OneTimeAccessToken> Tokens { get; set; }

        public string DbPath { get; }

        public OneTimeAccessTokenContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Tokens.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class OneTimeAccessToken
    {
        public int OneTimeAccessTokenId { get; set; }
        public string TokenContent  { get; set; }
    }
}
