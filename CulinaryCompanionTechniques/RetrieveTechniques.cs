using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace CulinaryCompanionTechniques
{
    public class RetrieveTechniques
    {
        public RetrieveTechniques() { }

        private readonly string connectionString = "mongodb+srv://Grant:Turtle@cluster0-knqq3.mongodb.net/test?retryWrites=true&w=majority";
        private readonly string databaseName = "CulinaryCompanion";
        private string collectionName = "Techniques";

        public string retrieve(string searchTech)
        {
            MongoClient dbClient = new MongoClient(connectionString);
            var CCDatabase = dbClient.GetDatabase(databaseName);
            var techniques = CCDatabase.GetCollection<BsonDocument>(collectionName);
            searchTech = searchTech.ToLower();

            var filter = Builders<BsonDocument>.Filter.Eq("Tag", searchTech);
            var result = techniques.Find(filter).ToList();
            var endString = "";
            foreach (var doc in result)
            {
                endString += doc.ToString();
            }
            return endString;
        }

    }
}
