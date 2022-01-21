﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaAgendaMinhaVidaAPI.Context;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220120150751_ChangingFieldName")]
    partial class ChangingFieldName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinhaAgendaMinhaVidaAPI.Models.Agenda", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendaId"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AgendaId");

                    b.ToTable("Agendas");

                    b.HasData(
                        new
                        {
                            AgendaId = 1,
                            CreationDate = new DateTime(2022, 1, 20, 12, 7, 51, 229, DateTimeKind.Local).AddTicks(2184),
                            Description = "Anotações sobre dezembro",
                            Title = "Agenda Dezembro"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
