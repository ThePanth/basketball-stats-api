module BasketballStats.Data.Repositories.GameStorage

open BasketballStats.Data.Mongo.Models
open BasketballStats.Data.Storage
open MongoDB.Driver
open System
open MongoDB.Bson

let createMongoGameStorage (connectionString: string) (databaseName: string) : GameStorage =
    let client = MongoClient(connectionString)
    let database = client.GetDatabase(databaseName)
    let gamesCollection = database.GetCollection<Game>("games")

    {
        InsertGame = fun game -> async {
            do! gamesCollection.InsertOneAsync(game) |> Async.AwaitTask
        }
        
        GetGame = fun gameId -> async {
            let! game = gamesCollection.Find(fun g -> g.Id = gameId).FirstOrDefaultAsync() |> Async.AwaitTask
            return if isNull game then None else Some game
        }

        DeleteGame = fun gameId -> async {
            let filter = Builders<Game>.Filter.Eq(fun g -> g.Id, gameId)
            do! gamesCollection.DeleteOneAsync(filter) |> Async.AwaitTask
        }
    }