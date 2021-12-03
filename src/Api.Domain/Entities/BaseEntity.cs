using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{   
    public abstract class BaseEntity
    {
        protected string SetId()
        {
            //var id = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10).ToUpper();
            var id = ObjectId.GenerateNewId().ToString();
            return Id = id;
        }
        public void setId(string id) => Id = id;


        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}