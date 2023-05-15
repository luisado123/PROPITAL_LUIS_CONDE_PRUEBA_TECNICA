using Amazon.Auth.AccessControlPolicy;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public class UserColeccion : IUserColeccion
    {


        internal MongoConnectionRepository _repository = new MongoConnectionRepository();
        private IMongoCollection<UserDto> Collection;


        #region [Constructor Conexion]

        public UserColeccion()
        {
            Collection = _repository.db.GetCollection<UserDto>("PS_USER");
        }

        #endregion
        public async Task CreateUser(UserDto user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task DeleteUser(string usuario)
        {
            var filter = Builders<UserDto>.Filter.Eq(s => s.username, usuario);
            await Collection.DeleteOneAsync(filter);
        }

        public async  Task<List<UserDto>> GetAllUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task UpdateUser(UserDto user)
        {
            var filter = Builders<UserDto>.Filter.Eq(u => u.Id, user.Id);

            await Collection.ReplaceOneAsync(filter, user);
        }

        public async Task Login(string username, string password)
        {
             await Collection.FindAsync(new BsonDocument { { "username", username }, { "password", password } }).Result.FirstOrDefaultAsync();
        }
    }
}
