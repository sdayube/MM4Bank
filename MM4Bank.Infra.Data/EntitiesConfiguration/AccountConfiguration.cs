using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.EntitiesConfiguration
{
    //aqui vão as regras de negócio para nossas categorias entrarem no Banco de Dados
    //vou usar a base do curso e abro a task para vocês adaptarem
    public class AccountConfiguration : EntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);
            builder.ToTable("TB_ACCOUNT");
            //as duas linhas abaixo significam que o Id será a chave primária da tabela e que o nome terá tamanho máximo de 100 e será obrigatória (Not Null)
            builder
                .Property(p => p.Name)
                .HasColumnName("NM_NAME")
                .HasMaxLength(100)
                .IsRequired();
            //se tivermos propriedades do tipo decimal (temos uma)
            // builder.Property(p => p.nomeDaPropriedadeQueTemDecimal).HasPrecision(10,2)
            builder
                .Property(p => p.Balance)
                .HasColumnName("VL_BALANCE")
                .HasPrecision(10,2)
                .IsRequired();

            builder
                .Property(p => p.ClientId)
                .HasColumnName("ID_CLIENT")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.Client)
                .WithOne(p => p.Account)
                .HasForeignKey<Client>(p => p.AccountId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //o builder HasData popula a tabela com os dados iniciais quando acontecer a primeira migration
            builder.HasData(
                new Account(1),
                new Account(2),
                new Account(3)
                );

        }
    }
}
