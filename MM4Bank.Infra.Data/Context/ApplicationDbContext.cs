using Microsoft.EntityFrameworkCore;
using MM4Bank.Domain.Entities;
using MM4Bank.Infra.Data.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        //acho que aqui não precisa mexer em nada, apenas nos arquivos da Entities Configuration
        //construtor onde define as opções do Contexto

        // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        //definir o ORM
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //definição das configurações das entidades usando a Fluent API
        //Essa configuração é necessária por conta da abordagem Code-First, na qual fazemos o código antes do Banco de Dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            new ClientConfiguration().Configure(modelBuilder.Entity<Client>());
            new AccountConfiguration().Configure(modelBuilder.Entity<Account>());
            new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());
        }
    }
}
