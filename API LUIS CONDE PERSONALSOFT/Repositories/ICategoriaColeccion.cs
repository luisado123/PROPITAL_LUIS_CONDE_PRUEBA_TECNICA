using API_LUIS_CONDE_PERSONALSOFT.Models;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public interface ICategoriaColeccion
    {
        Task DeleteCategoria(string idCategoria);
        Task CreateCategoria(CategoriaDto categoria);

        Task UpdateCategoria(CategoriaDto categoria);

        Task<List<CategoriaDto>> GetAllCategoria();

        Task<CategoriaDto> GetCategoriaByNombre(string nombre);

        Task<CategoriaDto> GetCategoriaById(string idMatricula);
    }
}
