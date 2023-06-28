using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace API_LUIS_CONDE_PERSONALSOFT.Models
{
    public class UserDto
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string rol { get; set; }
    }
}
