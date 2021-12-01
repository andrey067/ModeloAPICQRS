using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{   
    public abstract class BaseEntity
    {
        public string SetId()
        {
            var id = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10).ToUpper();
            return _id = id;
        }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; private set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}