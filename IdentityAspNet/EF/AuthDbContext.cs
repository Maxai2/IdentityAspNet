using IdentityAspNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAspNet.EF
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        // DbSet Table

        public AuthDbContext(DbContextOptions<AuthDbContext> opts) : base(opts)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<User>().Property(u => u.Gender).HasDefaultValue(GenderEnum.Undefined);

        //    base.OnModelCreating(builder);
        //}
    }
}
