﻿using Microsoft.EntityFrameworkCore;
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
                .HasMaxLength(100)
                .IsRequired();
            //se tivermos propriedades do tipo decimal (temos uma)
            // builder.Property(p => p.nomeDaPropriedadeQueTemDecimal).HasPrecision(10,2)
            builder
                .Property(p => p.Balance)
                .HasPrecision(10,2)
                .IsRequired();

            //o builder HasData popula a tabela com os dados iniciais quando acontecer a primeira migration
            builder.HasData(
                new Account(Guid.NewGuid(), "Number Account #1"),
                new Account(Guid.NewGuid(), "Number Account #2"),
                new Account(Guid.NewGuid(), "Number Account #3")
                );

        }
    }
}
