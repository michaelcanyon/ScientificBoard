using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_games.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nickname { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
