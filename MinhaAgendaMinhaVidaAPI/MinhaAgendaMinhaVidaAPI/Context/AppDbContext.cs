using Microsoft.EntityFrameworkCore;
using MinhaAgendaMinhaVidaAPI.Models;

namespace MinhaAgendaMinhaVidaAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
