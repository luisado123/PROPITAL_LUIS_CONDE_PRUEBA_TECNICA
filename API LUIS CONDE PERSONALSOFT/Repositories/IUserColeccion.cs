using API_LUIS_CONDE_PERSONALSOFT.Models;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public interface IUserColeccion
    {
        Task DeleteUser(string id);
        Task CreateUser(UserDto user);

        Task UpdateUser(UserDto id);

        Task<List<UserDto>> GetAllUsers();

        Task Login(string username, string password);

    }
}

