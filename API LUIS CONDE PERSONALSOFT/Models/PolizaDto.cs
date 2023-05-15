
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.IO;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Models
{
    public class PolizaDto
    {

        [BsonId]

        public ObjectId Id { get; set; }
        public string numero_poliza { get; set; }

        public string nombre_cliente { get; set; }

        public string identificacion_cliente { get; set; }

        public DateTime fecha_nacimiento_cliente{ get; set; }

        public DateTime fecha_toma_poliza { get; set; }

        public List<string> coberturas_cubiertas_poliza { get; set; }


        public string valor_maximo_cubierto_poliza { get; set; }

        public string nombre_plan_poliza{ get; set; }

        public string ciudad_residencia_cliente{ get; set; }

        public string direccion_residencia_cliente { get; set; }

        public string placa_automotor { get; set; }
        
        public string modelo_automotor { get; set; }

        public bool? tiene_inspeccion { get; set; }

    }
}
