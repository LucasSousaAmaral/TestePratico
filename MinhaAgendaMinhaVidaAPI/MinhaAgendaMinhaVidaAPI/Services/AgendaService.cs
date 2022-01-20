using Microsoft.EntityFrameworkCore;
using MinhaAgendaMinhaVidaAPI.Context;
using MinhaAgendaMinhaVidaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaMinhaVidaAPI.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly AppDbContext _context;

        public AgendaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agenda>> GetAgendas()
        {
            return await _context.Agendas.ToListAsync();
        }
        public async Task<Agenda> GetAgenda<T>(int id)
        {
            return await _context.Agendas.FindAsync(id);
        }

        public async Task<IEnumerable<Agenda>> GetAgendaByTitle(string title)
        {
            IEnumerable<Agenda> agendas;

            if (!string.IsNullOrWhiteSpace(title))
            {
                agendas = await _context.Agendas.Where(x => x.Title.Contains(title)).ToListAsync();
            }
            else
            {
                agendas = await GetAgendas();
            }

            return agendas;
        }

        public async Task CreateAgenda(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgenda(Agenda agenda)
        {
            _context.Entry(agenda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgenda(Agenda agenda)
        {
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
        }
    }
}
