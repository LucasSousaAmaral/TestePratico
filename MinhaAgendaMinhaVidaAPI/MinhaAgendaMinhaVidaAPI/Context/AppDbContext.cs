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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>().HasData(
                new Agenda
                {
                    AgendaId = 1,
                    Title = "Agenda Dezembro",
                    Description = "Anotações sobre dezembro",
                    CreationDate = System.DateTime.Now
                }

                );
        }
    }
}
