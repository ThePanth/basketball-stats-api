namespace BasketballStats.Data.Storage

open System
open BasketballStats.Data.Models

type StatisticsStorage = {
    InsertStatistic: Statistic -> Async<unit>
    GetStatistic: Guid -> Async<Statistic option>
    DeleteStatistic: Guid -> Async<unit>
}