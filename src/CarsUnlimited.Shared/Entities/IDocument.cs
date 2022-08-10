using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarsUnlimited.Shared.Entities
{
    public interface IDocument
    {
        string Id { get; set; }
    }
}
