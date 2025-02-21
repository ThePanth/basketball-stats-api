namespace BasketballStats.Data.Mongo.Models

open System

type Team = {
    Name: string
    PlayerIds: Guid list  // References Player by generic ID
}

type Game = {
    Id: Guid
    Date: DateTime
    TeamA: Team
    TeamB: Team
    Statistics: Statistic list
}
