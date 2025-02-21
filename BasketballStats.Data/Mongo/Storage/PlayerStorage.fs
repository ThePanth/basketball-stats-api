namespace BasketballStats.Data.Storage

open System
open BasketballStats.Data.Models

type PlayerStorage = {
    InsertPlayer: Player -> Async<unit>
    GetPlayer: Guid -> Async<Player option>
    UpdatePlayer: Player -> Async<unit>
    DeletePlayer: Guid -> Async<unit>
}