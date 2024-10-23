using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Contexto : DbContext
    {
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Drogueria> Droguerias { get; set; }
        public DbSet<Monodroga> Monodrogas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Drogueria>()
            //        .ToTable("Droguerias")
            //        .HasKey(d => d.Id);

            //    modelBuilder.Entity<Medicamento>()
            //        .ToTable("Medicamentos")
            //        .HasKey(m => m.Id);

            //    modelBuilder.Entity<Drogueria>()
            //        .HasOne(d => d.Medicamento)
            //        .WithMany(m => m.Droguerias)
            //        .HasForeignKey("MedicamentoId");

            //    modelBuilder.Entity<Medicamento>()
            //        .HasOne(m => m.Monodroga)
            //        .WithMany()
            //        .HasForeignKey("MonodrogaId");

            modelBuilder.Entity<Medicamento>().HasKey(m => m.Id);
            modelBuilder.Entity<Drogueria>().HasKey(m => m.Id);
            modelBuilder.Entity<Monodroga>().HasKey(m => m.Id);

            modelBuilder.Entity<Medicamento>().HasOne(m => m.Monodroga);
            modelBuilder.Entity<Medicamento>().HasMany(m => m.Droguerias).WithMany();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MssqllocalDb;Initial Catalog=ef;Integrated Security=true;");

    }
}
