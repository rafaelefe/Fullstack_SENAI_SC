﻿// <auto-generated />
using System;
using Bercario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bercario.Migrations
{
    [DbContext(typeof(BercarioContext))]
    [Migration("20230417130325_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bercario.Models.Bebe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Nascimento");

                    b.Property<int>("MaeId")
                        .HasColumnType("int")
                        .HasColumnName("Mae_Id");

                    b.Property<int>("PartoId")
                        .HasColumnType("int")
                        .HasColumnName("Parto_Id");

                    b.Property<decimal>("PesoNascimento")
                        .HasPrecision(4, 3)
                        .HasColumnType("decimal(4,3)")
                        .HasColumnName("Peso_Nascimento");

                    b.HasKey("Id")
                        .HasName("PK_Bebe");

                    b.HasIndex("MaeId");

                    b.HasIndex("PartoId");

                    b.ToTable("Bebes");
                });

            modelBuilder.Entity("Bercario.Models.Mae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Nascimento");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK_Mae");

                    b.ToTable("Maes");
                });

            modelBuilder.Entity("Bercario.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id")
                        .HasName("PK_Medico");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Bercario.Models.Parto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataParto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Parto");

                    b.Property<DateTime>("HorarioParto")
                        .HasColumnType("datetime2")
                        .HasColumnName("Horario_Parto");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int")
                        .HasColumnName("Medico_Id");

                    b.HasKey("Id")
                        .HasName("PK_Parto");

                    b.HasIndex("MedicoId");

                    b.ToTable("Partos");
                });

            modelBuilder.Entity("Bercario.Models.Bebe", b =>
                {
                    b.HasOne("Bercario.Models.Mae", "Mae")
                        .WithMany("Bebes")
                        .HasForeignKey("MaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Bebe_Mae");

                    b.HasOne("Bercario.Models.Parto", "Parto")
                        .WithMany("Bebes")
                        .HasForeignKey("PartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Bebe_Parto");

                    b.Navigation("Mae");

                    b.Navigation("Parto");
                });

            modelBuilder.Entity("Bercario.Models.Parto", b =>
                {
                    b.HasOne("Bercario.Models.Medico", "MedicoParto")
                        .WithMany("Parto")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Parto_Medico");

                    b.Navigation("MedicoParto");
                });

            modelBuilder.Entity("Bercario.Models.Mae", b =>
                {
                    b.Navigation("Bebes");
                });

            modelBuilder.Entity("Bercario.Models.Medico", b =>
                {
                    b.Navigation("Parto");
                });

            modelBuilder.Entity("Bercario.Models.Parto", b =>
                {
                    b.Navigation("Bebes");
                });
#pragma warning restore 612, 618
        }
    }
}
