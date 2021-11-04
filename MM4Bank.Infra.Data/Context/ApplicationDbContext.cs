using Microsoft.EntityFrameworkCore;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        //construtor onde define as opções do Contexto
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        //definir o ORM
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //definição das configurações das entidades usando a Fluent API
        //Essa configuração é necessária por conta da abordagem Code-First, na qual fazemos o código antes do Banco de Dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }



    }
}
