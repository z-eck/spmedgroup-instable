using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmg_webAPI.Domains
{
    public class Localization
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("latitude")]
        [BsonRequired]
        public string lat { get; set; }

        [BsonElement("longitude")]
        [BsonRequired]
        public string lng { get; set; }
    }
}
