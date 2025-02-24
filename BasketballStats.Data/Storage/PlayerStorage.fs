namespace BasketballStats.Data.Storage

open System
open BasketballStats.Data.Models

type PlayerStorage = {
    InsertPlayer: Player -> Async<Player>
    GetPlayer: Guid -> Async<Player option>
    UpdatePlayer: Player -> Async<bool>
    DeletePlayer: Guid -> Async<bool>
    GetAll: unit -> Async<Player list>
}