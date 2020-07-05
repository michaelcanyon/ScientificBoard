using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_games.Models
{
    public class PostTag
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
