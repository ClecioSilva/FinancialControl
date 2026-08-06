using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace FinancialControl.Infrastructure.Mongo;

public static class MongoConfiguration
{
    private static bool _configured = false;

    public static void Configure()
    {
        if (_configured)
            return;


        BsonSerializer.RegisterSerializer(
            new GuidSerializer(
                GuidRepresentation.Standard));


        _configured = true;
    }
}