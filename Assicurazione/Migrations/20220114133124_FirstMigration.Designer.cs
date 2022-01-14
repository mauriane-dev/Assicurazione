﻿// <auto-generated />
using System;
using Assicurazione;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assicurazione.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220114133124_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assicurazione.Models.Client", b =>
                {
                    b.Property<string>("CF")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("Codice_Fiscale");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Indirizzo");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Nome");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Cognome");

                    b.HasKey("CF");

                    b.ToTable("Clienti", (string)null);
                });

            modelBuilder.Entity("Assicurazione.Models.Policy", b =>
                {
                    b.Property<int>("PolicyNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NumeroPolizza");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyNumber"), 1L, 1);

                    b.Property<string>("CF")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InsuranceAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("Decimal(10,2)")
                        .HasColumnName("ImportoAssicurativo");

                    b.Property<decimal>("MonthlyPayment")
                        .HasPrecision(10, 2)
                        .HasColumnType("Decimal(10,2)")
                        .HasColumnName("RataMensile");

                    b.Property<DateTime>("StipulationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataStipula");

                    b.HasKey("PolicyNumber");

                    b.HasIndex("CF");

                    b.ToTable("Polizza", (string)null);

                    b.HasDiscriminator<string>("Categoria").HasValue("Policy");
                });

            modelBuilder.Entity("Assicurazione.Models.Life", b =>
                {
                    b.HasBaseType("Assicurazione.Models.Policy");

                    b.Property<int>("InsuredYears")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Vita");
                });

            modelBuilder.Entity("Assicurazione.Models.RCCar", b =>
                {
                    b.HasBaseType("Assicurazione.Models.Policy");

                    b.Property<int>("Displacement")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasDiscriminator().HasValue("RCAuto");
                });

            modelBuilder.Entity("Assicurazione.Models.Robbery", b =>
                {
                    b.HasBaseType("Assicurazione.Models.Policy");

                    b.Property<int>("CoveredPercentage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Furto");
                });

            modelBuilder.Entity("Assicurazione.Models.Policy", b =>
                {
                    b.HasOne("Assicurazione.Models.Client", "Client")
                        .WithMany("Policies")
                        .HasForeignKey("CF")
                        .HasConstraintName("FK_CodiceFiscale");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Assicurazione.Models.Client", b =>
                {
                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
