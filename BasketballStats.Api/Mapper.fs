module BasketballStats.Api.Mapper

open BasketballStats
open BasketballStats.Data
open System
open System.Collections.Generic
open Google.Protobuf.Collections

let fromCreatePlayerRequest (req: Protos.CreatePlayerRequest): Models.Player = 
    {Id = Guid.NewGuid(); FirstName = req.FirstName; LastName = req.LastName; BadgeColor = req.BadgeColor |> Option.ofObj }

let toGrpcPlayer (p: Models.Player): Protos.Player = 
    let player = Protos.Player()
    player.Id <- p.Id.ToString()
    player.FirstName <- p.FirstName
    player.LastName <- p.LastName
    match p.BadgeColor with
    | None -> ()
    | Some v -> player.BadgeColor <- v
    
    player

let toGrpcPlayerResponse (p: Models.Player): Protos.PlayerResponse = 
    let resp = Protos.PlayerResponse()
    resp.Player <- p |> toGrpcPlayer
    resp

let toGrpcList (players: Models.Player list): Protos.ListPlayersResponse = 
    let resp = Protos.ListPlayersResponse()
    let grpcPlayers = RepeatedField<Protos.Player>()
    resp.Players.Add(players |> Seq.map toGrpcPlayer)
    resp
