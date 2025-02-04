﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteBenner.Data;

#nullable disable

namespace TesteBenner.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240708170215_MudandoOFormatoDeSaida")]
    partial class MudandoOFormatoDeSaida
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TesteBenner.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Saida")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
