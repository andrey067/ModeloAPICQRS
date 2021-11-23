namespace Api.Infrastructure.Context
{
    public interface IMongoDbConfig
    {
        string DataBase_Name { get; set; }
        string Collection_Name { get; set; }
        string Connection_String { get; set; }
    }
}
