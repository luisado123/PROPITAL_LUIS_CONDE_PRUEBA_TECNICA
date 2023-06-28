using API_LUIS_CONDE_PERSONALSOFT.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public class CategoriaColeccion : ICategoriaColeccion
    {
        internal MongoConnectionRepository _repository = new MongoConnectionRepository();
        private IMongoCollection<CategoriaDto> Collection;


        #region [Constructor Conexion]

        public CategoriaColeccion()
        {
            Collection = _repository.db.GetCollection<CategoriaDto>("PS_CATEGORIA");
        }

        #endregion
        public  async Task CreateCategoria(CategoriaDto categoria)
        {
            await Collection.InsertOneAsync(categoria);
        }

        public  async  Task DeleteCategoria(string idCategoria)
        {

            var filter = Builders<CategoriaDto>.Filter.Eq(s => s.Id, idCategoria);
            await Collection.DeleteOneAsync(filter);
        }

        public async  Task<List<CategoriaDto>> GetAllCategoria()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<CategoriaDto> GetCategoriaById(string id)
        {
            var filter = Builders<CategoriaDto>.Filter.Eq("_id", ObjectId.Parse(id));
            var propiedad = await Collection.Find(filter).FirstOrDefaultAsync();
            return propiedad;
        }

        public async Task<CategoriaDto> GetCategoriaByNombre(string nombre)
        {
            return await Collection.FindAsync(new BsonDocument { { "nombre", nombre } }).Result.FirstOrDefaultAsync();
        }

        public async  Task UpdateCategoria(CategoriaDto categoria)
        {
            var filter = Builders<CategoriaDto>.Filter.Eq(u => u.Id, categoria.Id);

            await Collection.ReplaceOneAsync(filter, categoria);
        }
    }
}
