using API_LUIS_CONDE_PERSONALSOFT.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public class PolizaColeccion : IPolizaColeccion
    {

        internal  MongoConnectionRepository _repository=new MongoConnectionRepository();
        private IMongoCollection<PolizaDto> Collection;


        #region [Constructor Conexion]

        public PolizaColeccion()
        {
            Collection = _repository.db.GetCollection<PolizaDto>("PS_POLIZA");
        }

        #endregion

        public async Task DeletePoliza(string numeroPoliza)
        {
            var filter = Builders<PolizaDto>.Filter.Eq(s => s.numero_poliza, numeroPoliza);
                await Collection.DeleteOneAsync(filter);
        }
        public async  Task CreatePoliza(PolizaDto poliza)
        {
            await Collection.InsertOneAsync(poliza);
        }

        public  async Task<List<PolizaDto>> GetAllPolizas()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async  Task<PolizaDto> GetPolizaByMatriculaAuto(string matricula)
        {
            return await  Collection.FindAsync(new BsonDocument { {"placa_automotor", matricula } }).Result.FirstOrDefaultAsync();
        }

        public async Task<PolizaDto> GetPolizaByNumero(string numeroPoliza)
        {
            return await Collection.FindAsync(new BsonDocument { { "numero_poliza",numeroPoliza } }).Result.FirstOrDefaultAsync();
        }

        public async Task UpdatePoliza(PolizaDto poliza)
        {
            var filter = Builders<PolizaDto>.Filter.Eq(u => u.Id, poliza.Id);

            await Collection.ReplaceOneAsync(filter, poliza);
        }
    }
}
