using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;
using WebApiBank.Models; // Asegúrate de importar las entidades correspondientes.

namespace WebApiBank.Data
{
    public class BankContext : DbContext
    {
        // Constructor que recibe las opciones del DbContext
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }


        // DbSets para cada entidad, que representan las tablas en la base de datos
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }

        // Configuración adicional de las entidades (relaciones, claves primarias, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir las claves primarias para cada entidad
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Deposit>().HasKey(d => d.Id);
            modelBuilder.Entity<Withdrawal>().HasKey(w => w.Id);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Deposits)
            .WithOne(d => d.Account)
                .HasForeignKey(d => d.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Withdrawals)
                .WithOne(w => w.Account)
                .HasForeignKey(w => w.AccountId);
        }
    }
}
