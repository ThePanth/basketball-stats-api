namespace BasketballStats.Data.Models

open System

type Player = {
    Id: Guid  // Generic ID, not tied to MongoDB
    FirstName: string
    LastName: string
    BadgeColor: string option
}
