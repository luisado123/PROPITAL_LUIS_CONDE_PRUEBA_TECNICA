
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.IO;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Models
{
    public class CategoriaDto
    {

        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        //[BsonElement("nombre")]
        public string nombre { get; set; }
    }
}
