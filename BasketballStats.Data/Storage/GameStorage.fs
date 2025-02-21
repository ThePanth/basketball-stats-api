namespace BasketballStats.Data.Repositories

open System
open BasketballStats.Data.Models

type GameStorage = {
    InsertGame: Game -> Async<unit>
    GetGame: Guid -> Async<Game option>
    DeleteGame: Guid -> Async<unit>
}