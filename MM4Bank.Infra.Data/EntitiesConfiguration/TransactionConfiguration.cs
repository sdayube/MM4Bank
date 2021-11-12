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
    //tentei rodar a migration e deu erro, pesquisando eu vi que o erro é pq falta implementar aqui os arquivos de configuration
    public class TransactionConfiguration : EntityConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //verificar quais regras de negócio serão necessárias para se criar uma transaction no banco de dados

            //as duas linhas abaixo significam que o Id será a chave primária da tabela e que o nome terá tamanho máximo de 100 e será obrigatória (Not Null)
            base.Configure(builder);
            builder.ToTable("TB_TRANSACTION");

            builder
                .Property(p => p.Value)
                .HasColumnName("VL_VALUE")
                .HasPrecision(10,2)
                .IsRequired();

            builder
                .Property(p => p.SourceAccountId)
                .HasColumnName("ID_SOURCE_ACCOUNT")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.SourceAccount)
                .WithMany(p => p.Withdrawals)
                .HasForeignKey(p => p.SourceAccountId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .Property(p => p.TargetAccountId)
                .HasColumnName("ID_TARGET_ACCOUNT")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.TargetAccount)
                .WithMany(p => p.Deposits)
                .HasForeignKey(p => p.TargetAccountId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .Property(p => p.Type)
                .HasColumnName("DS_TYPE")
                .IsRequired();

            //builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            //se tivermos propriedades do tipo decimal (temos uma)
            // builder.Property(p => p.nomeDaPropriedadeQueTemDecimal).HasPrecision(10,2)

            //aqui configura-se o relacionamento 1:N e a chave estrangeira
            //builder.HasOne(e => e.Account).WithMany(e => e.Clients).HasForeignKey(e => e.AccountId);
        }
    }
}
