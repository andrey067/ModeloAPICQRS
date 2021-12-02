using Api.Domain.Mongo.DomainMapping;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Api.Domain.Mongo
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            BaseMap.Configure();
            
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
