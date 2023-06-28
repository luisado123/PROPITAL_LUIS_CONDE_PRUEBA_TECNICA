using API_LUIS_CONDE_PERSONALSOFT.Models;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public interface IUserColeccion
    {
        Task DeleteUser(string idUsuario);
        Task CreateUser(UserDto user);

        Task UpdateUser(UserDto id);

        Task<List<UserDto>> GetAllUsers();

        Task <UserDto> Login(string username, string password);

    }
}

