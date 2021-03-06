﻿using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Security.Claims;
using Valour.Server.Users;
using Valour.Server.Users.Identity;
using Valour.Shared.Oauth;
using Valour.Shared.Users;

namespace Valour.Server.Database
{
    public class ValourDB : DbContext
    {

        public static string ConnectionString = $"server={DBConfig.instance.Host};port=3306;database={DBConfig.instance.Database};uid={DBConfig.instance.Username};pwd={DBConfig.instance.Password};SslMode=Required;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(ConnectionString, ServerVersion.FromString("8.0.20-mysql"), options => options.EnableRetryOnFailure().CharSet(CharSet.Utf8Mb4));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // These are the database sets we can access
        //public DbSet<ClientPlanetMessage> Messages { get; set; }

        /// <summary>
        /// This is only here to fulfill the need of the constructor.
        /// It does literally nothing at all.
        /// </summary>
        public static DbContextOptions DBOptions;

        /// <summary>
        /// Table for Valour users
        /// </summary>
        public DbSet<ClientUser> Users { get; set; }

        // USER LOGIN AND PERMISSION STUFF //

        /// <summary>
        /// Table for password and login information
        /// </summary>
        public DbSet<Credential> Credentials { get; set; }

        /// <summary>
        /// Table for authentication tokens
        /// </summary>
        public DbSet<AuthToken> AuthTokens { get; set; }

        /// <summary>
        /// Table for email confirmation codes
        /// </summary>
        public DbSet<EmailConfirmCode> EmailConfirmCodes { get; set; }

        public ValourDB(DbContextOptions options)
        {

        }
    }
}
