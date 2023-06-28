using API_LUIS_CONDE_PERSONALSOFT.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public class PropiedadColeccion : IPropiedadColeccion
    {

        internal MongoConnectionRepository _repository = new MongoConnectionRepository();
        private IMongoCollection<PropiedadDto> Collection;


        #region [Constructor Conexion]

        public PropiedadColeccion()
        {
            Collection = _repository.db.GetCollection<PropiedadDto>("PS_PROPIEDAD");
        }
        #endregion
        public async Task CreatePropiedad(PropiedadDto propiedad)
        {
            await Collection.InsertOneAsync(propiedad);
        }

        public async Task DeletePropiedad(string idPropiedad)
        {

            var filter = Builders<PropiedadDto>.Filter.Eq(s => s.Id, idPropiedad);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<PropiedadDto>> GetAllPropiedades()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();

        }
        public async Task<List<PropiedadDto>> GetPropiedadesByCiudad(string nombreCiudad)
        {
            return await Collection.FindAsync(new BsonDocument { { "ciudad", nombreCiudad } }).Result.ToListAsync();
        }

        public async  Task<List<PropiedadDto>> GetPropiedadesByCategoria(string nombreCategoria)
        {
            CategoriaColeccion coleccionData=new CategoriaColeccion();
            var categoria = await coleccionData.GetCategoriaByNombre(nombreCategoria);


            if (categoria != null)
            {
                return await Collection.FindAsync(new BsonDocument { { "CategoriaId", categoria.Id } }).Result.ToListAsync();
            }
            else
            {
                return new List<PropiedadDto>(); // Devuelve una lista vacía
            }
        }

     
        public  async Task UpdatePropiedad(PropiedadDto propiedad)
        {
            var filter = Builders<PropiedadDto>.Filter.Eq(u => u.Id, propiedad.Id);

            await Collection.ReplaceOneAsync(filter, propiedad);
        }
    }
}
