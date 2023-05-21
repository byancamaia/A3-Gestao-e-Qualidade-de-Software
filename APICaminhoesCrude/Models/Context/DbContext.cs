using APICaminhoesCrude.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace APICaminhoesCrude.Models.Context
{
    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Caminhao> Caminhoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caminhao>()
            .Property(p => p.NomeModelo).HasConversion(
            p => p.ToString(),
            p => (MarcaModelo)Enum.Parse(typeof(MarcaModelo), p));

        }


    }
}
