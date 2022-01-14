using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Configuration
{
    internal class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            //Entità Polizza

            builder.ToTable("Polizza");
            builder.HasKey(p => p.PolicyNumber);
            builder.Property(p => p.PolicyNumber).HasColumnName("NumeroPolizza").IsRequired();
            builder.Property(p => p.StipulationDate).HasColumnName("DataStipula").IsRequired();
            builder.Property(p => p.InsuranceAmount).HasColumnName("ImportoAssicurativo")
                                                    .HasColumnType("Decimal")
                                                    .HasPrecision(10,2)
                                                    .IsRequired();
            builder.Property(p => p.MonthlyPayment).HasColumnName("RataMensile")
                                                   .HasColumnType("Decimal")
                                                   .HasPrecision(10, 2)
                                                   .IsRequired();

            //Per gerarchia
            builder.HasDiscriminator<string>("Categoria")
                   .HasValue<RCCar>("RCAuto")
                   .HasValue<Robbery>("Furto")
                   .HasValue<Life>("Vita");

            //Relazione 1 a n tra polizza e cliente
            builder.HasOne(p => p.Client)
                   .WithMany(p => p.Policies)
                   .HasForeignKey(p => p.CF)
                   .HasConstraintName("FK_CodiceFiscale");

        }
    }
}
