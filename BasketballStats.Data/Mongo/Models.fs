module BasketballStats.Data.Mongo.Models

open System
open MongoDB.Bson.Serialization.Attributes
open BasketballStats.Data.Models

type MongoPlayer = {
    [<BsonId>] Id: Guid
    FirstName: string
    LastName: string
    BadgeColor: string option
}

type MongoGame = {
    [<BsonId>] Id: Guid
    Date: DateTime
    TeamA: Team
    TeamB: Team
}

type MongoStatistic = {
    [<BsonId>] Id: Guid
    PlayerId: Guid
    GameId: Guid
    Timestamp: DateTime
    StatType: StatisticType
}

