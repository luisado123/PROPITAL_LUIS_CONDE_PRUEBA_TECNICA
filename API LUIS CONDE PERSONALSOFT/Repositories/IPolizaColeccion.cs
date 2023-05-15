using API_LUIS_CONDE_PERSONALSOFT.Models;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public interface IPolizaColeccion
    {

        Task DeletePoliza(string numeroPoliza);
        Task CreatePoliza(PolizaDto poliza);

        Task UpdatePoliza(PolizaDto poliza);

        Task<List<PolizaDto>> GetAllPolizas();

        Task<PolizaDto> GetPolizaByNumero(string numero);

        Task<PolizaDto> GetPolizaByMatriculaAuto(string matricula);
    }
}
