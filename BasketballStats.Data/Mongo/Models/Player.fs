namespace BasketballStats.Data.Mongo.Models

open System

type Player = {
    Id: Guid  // Generic ID, not tied to MongoDB
    FirstName: string
    LastName: string
    Icon: string option
}
