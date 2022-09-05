using CityData.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Infrastructure.Context.Configuration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(entity => entity.CreatedDate)
                   .IsRequired();
            builder.Property(entity => entity.ModifiedDate);
            builder.Property(entity => entity.DeletedDate);
            builder.Property(entity => entity.IsDeleted)
                   .IsRequired();
        }
    }
}