﻿namespace Api.Infrastructure.Context
{
    public class MongoDbConfig : IMongoDbConfig
    {
        public string DataBase_Name { get; set; }
        public string Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
