using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPI.API.Data.Models;

namespace HolaMundoAPI.API.Data
{
    public class HolaMundoDbContext : DbContext
    {
        public HolaMundoDbContext (DbContextOptions<HolaMundoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Office> Offices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Office>().ToTable(nameof(Office));


            base.OnModelCreating(modelBuilder);
        }


        
    }   

}
