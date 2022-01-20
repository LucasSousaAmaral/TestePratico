﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaAgendaMinhaVidaAPI.Context;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AgendaId");

                    b.HasIndex("UserId");

                    b.ToTable("Agendas");

                    b.HasData(
                        new
                        {
                            AgendaId = 1,
                            Data = new DateTime(2022, 1, 19, 22, 47, 4, 971, DateTimeKind.Local).AddTicks(1407),
                            Description = "Anotações sobre dezembro",
                            Title = "Agenda Dezembro"
                        });
                });

            modelBuilder.Entity("MinhaAgendaMinhaVidaAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Login = "LucasAmaral",
                            Name = "Amaral",
                            Password = "Amaral",
                            Role = 0
                        },
                        new
                        {
                            UserId = 2,
                            Login = "MateusAmaral",
                            Name = "Mateus",
                            Password = "Mateus",
                            Role = 1
                        });
                });

            modelBuilder.Entity("MinhaAgendaMinhaVidaAPI.Models.Agenda", b =>
                {
                    b.HasOne("MinhaAgendaMinhaVidaAPI.Models.User", null)
                        .WithMany("Agendas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MinhaAgendaMinhaVidaAPI.Models.User", b =>
                {
                    b.Navigation("Agendas");
                });
#pragma warning restore 612, 618
        }
    }
}
