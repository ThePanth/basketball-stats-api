module BasketballStats.Data.Mongo.PlayerStorage

open BasketballStats.Data.Mongo.Models
open BasketballStats.Data.Mongo.Mapper
open MongoDB.Driver
open BasketballStats.Data.Storage

let createMongoPlayerStorage (database: IMongoDatabase) : PlayerStorage =
    let collection = database.GetCollection<MongoPlayer>("players")

    {
        InsertPlayer = fun player -> async {
            let mongoPlayer = toMongoPlayer player
            do! collection.InsertOneAsync(mongoPlayer) |> Async.AwaitTask
            return! collection.Find(fun p -> p.Id = player.Id).FirstOrDefaultAsync() 
            |> Async.AwaitTask
            |> Async.map fromMongoPlayer


        }

        GetPlayer = fun playerId -> async {
            let! player = collection.Find(fun p -> p.Id = playerId).FirstOrDefaultAsync() |> Async.AwaitTask
            return player 
                |> Option.ofObj 
                |> Option.map fromMongoPlayer
        }

        UpdatePlayer = fun player -> async {
            let filter = Builders<MongoPlayer>.Filter.Eq((fun p -> p.Id), player.Id)
            let! replaceResult = collection.ReplaceOneAsync(filter, player |> toMongoPlayer) |> Async.AwaitTask
            return replaceResult.IsAcknowledged
        }

        DeletePlayer = fun playerId -> async {
            let filter = Builders<MongoPlayer>.Filter.Eq((fun p -> p.Id), playerId)
            let! result = collection.DeleteOneAsync(filter) |> Async.AwaitTask
            return result.DeletedCount > 0L
        }

        GetAll = fun unit -> async {
            let! players = collection.Find(FilterDefinition<MongoPlayer>.Empty).ToListAsync() |> Async.AwaitTask
            return players |> Seq.toList |> List.map fromMongoPlayer
        }
    }

