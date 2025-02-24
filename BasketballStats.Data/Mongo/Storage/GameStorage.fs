module BasketballStats.Data.Mongo.GameStorage

open BasketballStats.Data.Mongo.Models
open BasketballStats.Data.Mongo.Mapper
open MongoDB.Driver
open BasketballStats.Data.Storage

let createMongoGameStorage (database: IMongoDatabase) : GameStorage =
    let gamesCollection = database.GetCollection<MongoGame>("games")

    {
        InsertGame = fun game -> async {
            do! gamesCollection.InsertOneAsync(game |> toMongoGame) |> Async.AwaitTask
        }
        
        GetGame = fun gameId -> async {
            let! game = gamesCollection.Find(fun g -> g.Id.Equals(gameId)).FirstOrDefaultAsync() |> Async.AwaitTask
            return game 
                |> Option.ofObj 
                |> Option.map fromMongoGame
        }

        DeleteGame = fun gameId -> async {
            let test = fun g -> g.Id, gameId
            let filter = Builders<MongoGame>.Filter.Eq((fun g -> g.Id), gameId)
            let! deleteResult = gamesCollection.DeleteOneAsync(filter) |> Async.AwaitTask
            return deleteResult.DeletedCount > 0L
        }
    }