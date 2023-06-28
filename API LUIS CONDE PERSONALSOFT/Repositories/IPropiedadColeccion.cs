using API_LUIS_CONDE_PERSONALSOFT.Models;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public interface IPropiedadColeccion
    {

        Task DeletePropiedad(string idPropiedad);
        Task CreatePropiedad(PropiedadDto propiedad);

        Task UpdatePropiedad(PropiedadDto propiedad);

        Task<List<PropiedadDto>> GetAllPropiedades();

        Task <List<PropiedadDto>> GetPropiedadesByCategoria(string nombreCategoria);

        Task <List<PropiedadDto>> GetPropiedadesByCiudad(string nombreCiudad);





    }
}
