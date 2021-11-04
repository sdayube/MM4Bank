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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //verificar quais regras de negócio serão necessárias para se criar uma transaction no banco de dados

            //as duas linhas abaixo significam que o Id será a chave primária da tabela e que o nome terá tamanho máximo de 100 e será obrigatória (Not Null)
            builder.HasKey(t => t.Id);
            //builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            //se tivermos propriedades do tipo decimal (temos uma)
            // builder.Property(p => p.nomeDaPropriedadeQueTemDecimal).HasPrecision(10,2)

            //aqui configura-se o relacionamento 1:N e a chave estrangeira
            //builder.HasOne(e => e.Account).WithMany(e => e.Clients).HasForeignKey(e => e.AccountId);
        }
    }
}
