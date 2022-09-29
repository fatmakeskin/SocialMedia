using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailMedia.Data.Entities
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PostId { get; set; }

        [BsonElement("Name")]
        public string PostTitle { get; set; }
        public string PostMessage { get; set; }
        public string PostImage { get; set; }
        public int LikeCount { get; set; }
        public List<string> PostComment { get; set; }
    }
}
