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
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder
                .Property(x => x.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder
                .Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName("DT_UPDATED");

            builder
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("DT_CREATED");

            builder
                .Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("ST_ISACTIVE");

        }
    }
}
