module BasketballStats.Data.Mongo.StatisticsStorage


open BasketballStats.Data.Mongo.Models
open BasketballStats.Data.Mongo.Mapper
open MongoDB.Driver
open BasketballStats.Data.Storage

let createMongoStatisticsStorage (database:IMongoDatabase) : StatisticsStorage = 
    let collection = database.GetCollection<MongoStatistic>("statistics")

    {
        InsertStatistic = fun statistic -> async {
            do! collection.InsertOneAsync(statistic |> toMongoStatistic) |> Async.AwaitTask
        }

        GetStatistic = fun statisticId -> async {
            let! statistic = collection.Find(fun s -> s.Id = statisticId).FirstOrDefaultAsync() |> Async.AwaitTask
            return statistic
                |> Option.ofObj
                |> Option.map fromMongoStatistic
        }

        DeleteStatistic = fun statisticId -> async {
            let filter = Builders<MongoStatistic>.Filter.Eq((fun s -> s.Id), statisticId)
            let! deleteRes = collection.DeleteOneAsync(filter) |> Async.AwaitTask
            return deleteRes.DeletedCount > 0L
        }
    }