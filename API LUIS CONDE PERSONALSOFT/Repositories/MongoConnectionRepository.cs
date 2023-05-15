using MongoDB.Bson;
using MongoDB.Driver;

namespace API_LUIS_CONDE_PERSONALSOFT.Repositories
{
    public class MongoConnectionRepository
    {

        public MongoClient clienteMongo;


        public IMongoDatabase db;

        public MongoConnectionRepository()
        {


            //const string connectionUri = "mongodb+srv://luisado:Condeeiemlda123@cluster0.abcj6sj.mongodb.net/?retryWrites=true&w=majority";
            //var settings = MongoClientSettings.FromConnectionString(connectionUri);
            //// Set the ServerApi field of the settings object to Stable API version 1
            //settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            //// Create a new client and connect to the server
            //var client = new MongoClient(settings);
            //// Send a ping to confirm a successful connection
            //try
            //{
            //    db = client.GetDatabase("Luisconde").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            //    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            clienteMongo =new MongoClient("mongodb+srv://luisado:Condeeiemlda123@cluster0.abcj6sj.mongodb.net/?retryWrites=true&w=majority");//aca se cambia el cliente 



            db = clienteMongo.GetDatabase("Luisconde");


       


            //try
            //{
            //    var result = clienteMongo.GetDatabase("Luisconde").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            //    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}
