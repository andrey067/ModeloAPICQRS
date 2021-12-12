using Api.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Api.Infrastructure.Mappings
{
    public class BaseEntityMap
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
