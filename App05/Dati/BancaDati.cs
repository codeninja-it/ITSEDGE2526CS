using App05.Dati.Strutture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Dati
{
    public class BancaDati : DbContext
    {
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Gruppo> Gruppi { get; set; }
        public DbSet<Tipo> Tipi { get; set; }

        protected override void OnModelCreating(ModelBuilder modello)
        {
            modello.Entity<Contatto>()
                .HasMany(c => c.Gruppi)
                .WithMany(g => g.Contatti);

            modello.Entity<Contatto>()
                .HasOne(c => c.Tipo)
                .WithMany(t => t.Contatti)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modello);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opzioni)
        {
            opzioni.UseSqlite("Data Source=Contatti.sqlite");
            base.OnConfiguring(opzioni);
        }

    }
}
