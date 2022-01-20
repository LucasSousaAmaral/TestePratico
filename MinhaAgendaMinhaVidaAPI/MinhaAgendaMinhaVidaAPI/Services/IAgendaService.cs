using MinhaAgendaMinhaVidaAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAgendaMinhaVidaAPI.Services
{
    public interface IAgendaService
    {
        Task<IEnumerable<Agenda>> GetAgendas();

        Task<Agenda> GetAgenda(int id);

        Task<IEnumerable<Agenda>> GetAgendaByTitle(string title);

        Task CreateAgenda(Agenda agenda);

        Task UpdateAgenda(Agenda agenda);

        Task DeleteAgenda(Agenda agenda);
    }
}
