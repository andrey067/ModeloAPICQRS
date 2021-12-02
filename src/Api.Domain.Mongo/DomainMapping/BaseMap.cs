using Api.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Api.Domain.Mongo.DomainMapping
{
    public class BaseMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
            });
        }
    }
}
