using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.EntitiesConfiguration
{
    //aqui vão as regras de negócio para nossas categorias entrarem no Banco de Dados
    //vou usar a base do curso e abro a task para vocês adaptarem
    public class ClientConfiguration : EntityConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_CLIENT");
            //as duas linhas abaixo significam que o Id será a chave primária da tabela e que o nome terá tamanho máximo de 100 e será obrigatória (Not Null)

            builder
                .Property(p => p.Name)
                .HasColumnName("NM_NAME")
                .HasMaxLength(100)
                .HasConversion(
                    p => p.FullName,
                    p => new Name(p)
                )
                .IsRequired();

            builder
                .Property(p => p.CPF)
                .HasColumnName("NR_CPF")
                .HasMaxLength(11)
                .HasConversion(
                    p => p.ToString(),
                    p => new CPF(p)
                )
                .IsRequired();

            builder
                .Property(p => p.AccountId)
                .HasColumnName("ID_ACCOUNT")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.Account)
                .WithOne(p => p.Client)
                .HasForeignKey<Account>(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .Property(p => p.Password)
                .HasColumnName("DS_PASSWORD")
                .HasMaxLength(11)
                .HasConversion(
                    p => p._password,
                    p => new Password(p)
                )
                .IsRequired();

            builder
                .Property(p => p.Address)
                .HasColumnName("DS_ADRESS")
                .HasMaxLength(250)
                .HasConversion(
                    p => p.FullAddress,
                    p => new Address(p)
                )
                .IsRequired();

            //se tivermos propriedades do tipo decimal (temos uma)
            // builder.Property(p => p.nomeDaPropriedadeQueTemDecimal).HasPrecision(10,2) 

            //aqui configura-se o relacionamento 1:N e a chave estrangeira
            //builder.HasOne(e => e.Account).WithMany(e => e.Clients).HasForeignKey(e => e.AccountId);
        }
    }
}
