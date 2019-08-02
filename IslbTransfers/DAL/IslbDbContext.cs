using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using Model.Models;

namespace DAL
{
    public class IslbDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ISLB_DB;Trusted_Connection=True;");

            /* FOR REMOTE */
            builder.UseSqlServer("Server=db0.islb.one,1443;Database=islb_pay;User Id=islb_pay;Password=xJMGf88big;"); 
            base.OnConfiguring(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserExternalLogin> UserExternalLogins { get; set; }
        public DbSet<UserIdentityKyc> UserIdentityKycs { get; set; }
    }
}
