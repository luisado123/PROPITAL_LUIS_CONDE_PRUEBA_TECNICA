using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Models
{
    public class UserDto
    {

        [BsonId]

        public ObjectId Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string rol { get; set; }
    }
}
