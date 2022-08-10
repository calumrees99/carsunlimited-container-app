using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarsUnlimited.Shared.Entities
{
    public abstract class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
