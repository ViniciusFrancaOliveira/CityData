using CityData.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Infrastructure.Context.Configuration
{
    public class CityConfiguration : BaseEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(city => city.CityID);
            builder.Property(city => city.CityName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(city => city.CityCode)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.HasOne(city => city.State)
                   .WithMany(a => a.Cities)
                   .IsRequired();
        }
    }
}
