module BasketballStats.Data.Mongo.Mapper

open BasketballStats.Data.Models
open BasketballStats.Data.Mongo.Models

let toMongoPlayer (p: Player) : MongoPlayer =
    { Id = p.Id; FirstName = p.FirstName; LastName = p.LastName; BadgeColor = p.BadgeColor }

let fromMongoPlayer (p: MongoPlayer) : Player =
    { Id = p.Id; FirstName = p.FirstName; LastName = p.LastName; BadgeColor = p.BadgeColor }

let toMongoGame (g: Game) : MongoGame =
    { Id = g.Id; Date = g.Date; TeamA = g.TeamA; TeamB = g.TeamB }

let fromMongoGame (g: MongoGame) : Game =
    { Id = g.Id; Date = g.Date; TeamA = g.TeamA; TeamB = g.TeamB }

let toMongoStatistic (s: Statistic) : MongoStatistic =
    { Id = s.Id; PlayerId = s.PlayerId; GameId = s.GameId; Timestamp = s.Timestamp; StatType = s.StatType }

let fromMongoStatistic (s: MongoStatistic) : Statistic =
    { Id = s.Id; PlayerId = s.PlayerId; GameId = s.GameId; Timestamp = s.Timestamp; StatType = s.StatType }
