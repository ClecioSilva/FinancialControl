using MongoDB.Driver;
using FinancialControl.Domain.Entities;
using FinancialControl.Infrastructure.Configurations;


namespace FinancialControl.Infrastructure.Mongo;


public class MongoContext
{
    private readonly IMongoDatabase _database;


    public MongoContext(
        MongoSettings settings)
    {
        var client =
            new MongoClient(
                settings.ConnectionString);


        _database =
            client.GetDatabase(
                settings.DatabaseName);
    }


    public IMongoCollection<Transaction> Transactions
    {
        get
        {
            return _database
                .GetCollection<Transaction>("transactions");
        }
    }
}