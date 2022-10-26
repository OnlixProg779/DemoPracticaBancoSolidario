﻿// <auto-generated />
using System;
using BancoSolidario.InfrastructurePlanAhorro.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoSolidario.InfrastructurePlanAhorro.Migrations
{
    [DbContext(typeof(NuevoPlanAhorroContext))]
    partial class NuevoPlanAhorroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BancoSolidario.NuevoPlanAhorro.Entities.PlanAhorro", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Borrable")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("ClientRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Editable")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MontoDeAhorro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ShowToUserMed")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("TiempoPlanDeAhorroId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TiempoPlanDeAhorroId");

                    b.ToTable("PlanAhorro");
                });

            modelBuilder.Entity("BancoSolidario.NuevoPlanAhorro.Entities.TiempoPlanDeAhorro", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("Borrable")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Editable")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Meses")
                        .HasColumnType("int");

                    b.Property<bool?>("ShowToUserMed")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<float>("TasaDeInteresAnual")
                        .HasColumnType("real");

                    b.Property<string>("TipoDeInteres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiempoPlanDeAhorro");
                });

            modelBuilder.Entity("BancoSolidario.NuevoPlanAhorro.Entities.PlanAhorro", b =>
                {
                    b.HasOne("BancoSolidario.NuevoPlanAhorro.Entities.TiempoPlanDeAhorro", "TiempoPlanDeAhorro")
                        .WithMany("PlanesDeAhorro")
                        .HasForeignKey("TiempoPlanDeAhorroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Ref_PlanesDeAhorro_to_TiempoPlanAhorro");

                    b.Navigation("TiempoPlanDeAhorro");
                });

            modelBuilder.Entity("BancoSolidario.NuevoPlanAhorro.Entities.TiempoPlanDeAhorro", b =>
                {
                    b.Navigation("PlanesDeAhorro");
                });
#pragma warning restore 612, 618
        }
    }
}
