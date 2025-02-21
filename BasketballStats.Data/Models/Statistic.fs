namespace BasketballStats.Data.Models

open System

type StatisticType =
    | TwoPointSuccess
    | TwoPointMiss
    | ThreePointSuccess
    | ThreePointMiss
    | Assist
    | Rebound

type Statistic = {
    Id: Guid
    PlayerId: Guid  // References Player
    GameId: Guid    // References Game
    Timestamp: DateTime
    StatType: StatisticType
}
