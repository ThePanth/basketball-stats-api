module BasketballStats.Data.DI

open Microsoft.Extensions.DependencyInjection
open MongoDB.Driver
open BasketballStats.Data.Storage
open BasketballStats.Data
open MongoDB.Bson.Serialization
open MongoDB.Bson.Serialization.Serializers
open MongoDB.Bson
open System

let addDI (services: IServiceCollection): IServiceCollection = 
    let mongoConnectionString = "mongodb://host.docker.internal:27017"
    let databaseName = "basketball_stats"

    BsonSerializer.RegisterSerializer(typeof<Guid>, GuidSerializer(GuidRepresentation.Standard))

    services.AddSingleton<IMongoClient>(fun _ -> new MongoClient(mongoConnectionString) :> IMongoClient) |> ignore

     // Register MongoDB Database (Reusable)
    services.AddSingleton<IMongoDatabase>(fun sp -> 
        let client = sp.GetRequiredService<IMongoClient>()
        client.GetDatabase(databaseName)
    ) |> ignore

    services.AddSingleton<PlayerStorage>(fun sp -> 
        sp.GetRequiredService<IMongoDatabase>()
        |> Mongo.PlayerStorage.createMongoPlayerStorage
    ) |> ignore

    services.AddSingleton<StatisticsStorage>(fun sp -> 
        sp.GetRequiredService<IMongoDatabase>()
        |> Mongo.StatisticsStorage.createMongoStatisticsStorage
    ) |> ignore

    services.AddSingleton<GameStorage>(fun sp -> 
        sp.GetRequiredService<IMongoDatabase>()
        |> Mongo.GameStorage.createMongoGameStorage
    ) |> ignore

    services


