
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.IO;
using MongoDB.Bson;
using System.Security.Cryptography.X509Certificates;

namespace API_LUIS_CONDE_PERSONALSOFT.Models
{
    public class PropiedadDto
    {

        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string nombre { get; set; }

        public double precio { get; set; }

        public  string tipo { get; set; }

        public double superficie { get; set; }

        public string direccion { get; set; }

        public string ubicacion_coordenadas { get; set; }

        public string ciudad { get; set; }
        //[BsonElement("categoriaId")]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string CategoriaId { get; set; }

    }
}
