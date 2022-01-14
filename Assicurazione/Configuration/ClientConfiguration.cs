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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //Entità Client

            builder.ToTable("Clienti");
            builder.HasKey(c => c.CF);
            builder.Property(c => c.CF).HasColumnName("Codice_Fiscale").IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("Nome").HasMaxLength(20).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("Cognome").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Address).HasColumnName("Indirizzo").HasMaxLength(50).IsRequired();

            //Relazione 1 a n tra cliente e polizza
            builder.HasMany(c => c.Policies)
                   .WithOne(c => c.Client)
                   .HasForeignKey(c => c.CF);
        }
    }
}
