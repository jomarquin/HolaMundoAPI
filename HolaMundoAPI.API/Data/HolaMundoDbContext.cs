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

        public DbSet<HolaMundoAPI.API.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));

            base.OnModelCreating(modelBuilder);
        }
    }   

}
