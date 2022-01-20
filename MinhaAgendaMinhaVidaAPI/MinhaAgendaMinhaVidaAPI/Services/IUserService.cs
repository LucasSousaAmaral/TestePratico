using MinhaAgendaMinhaVidaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAgendaMinhaVidaAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<IEnumerable<User>> GetUserByName(string name);

        Task CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(User user);

    }
}
