using Microsoft.EntityFrameworkCore;
using MinhaAgendaMinhaVidaAPI.Models;
using System.Collections.Generic;

namespace MinhaAgendaMinhaVidaAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Amaral",
                    Login = "LucasAmaral",
                    Password = "Amaral",
                    Role = Role.Admin


                },
                new User
                {
                    UserId = 2,
                    Name = "Mateus",
                    Login = "MateusAmaral",
                    Password = "Mateus",
                    Role = Role.Common
                }

                );

            modelBuilder.Entity<Agenda>().HasData(
                new Agenda
                {
                    AgendaId = 1,
                    Title = "Agenda Dezembro",
                    Description = "Anotações sobre dezembro",
                    Data = System.DateTime.Now,
                    UserId = 1
                }

                );
        }
    }
}
