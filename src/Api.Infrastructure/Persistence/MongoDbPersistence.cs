using Api.Infrastructure.Mappings;
using MongoDB.Bson.Serialization.Conventions;

namespace Api.Infrastructure.Persistence
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            BaseEntityMap.Configure();


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