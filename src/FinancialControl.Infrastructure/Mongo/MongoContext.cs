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
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Mongo Connection: {settings.ConnectionString}");
        Console.WriteLine($"Mongo Database: {settings.DatabaseName}");
        Console.WriteLine("--------------------------------");


        var client =
            new MongoClient(
                settings.ConnectionString);


        // TESTE DE CONEXÃO
        var databases = client
            .ListDatabaseNames()
            .ToList();


        //Console.WriteLine("Mongo conectado com sucesso!");

        foreach(var db in databases)
        {
            Console.WriteLine($"Database encontrado: {db}");
        }


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