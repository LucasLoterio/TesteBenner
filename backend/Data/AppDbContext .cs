using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBenner.Models;

namespace TesteBenner.Data
{
    public class AppDbContext : DbContext
    {
  

        public DbSet<TesteBenner.Models.Veiculo> Veiculo { get; set; } = default!;

        static readonly string connectionString = @"Server=localhost;Database=testebenner;Uid=root;Pwd=admin";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<TesteBenner.Models.Saida> Saida { get; set; } = default!;
    }
}
