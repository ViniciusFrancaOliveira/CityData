using CityData.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Infrastructure.Context.Configuration
{
    public class StateConfiguration : BaseEntityConfiguration<State>
    {
        public override void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(state => state.StateID);
            builder.Property(state => state.StateName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(state => state.UF)
                   .IsRequired();
            builder.Property(state => state.StateCode)
                   .IsRequired();
            builder.HasMany(state => state.Cities);
        }
    }
}
