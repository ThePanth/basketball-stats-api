namespace BasketballStats.Api.Services

open BasketballStats.Protos
open BasketballStats.Data.Storage
open BasketballStats.Api.Mapper

type PlayerService(storage: PlayerStorage) =
    inherit BasketballStats.Protos.PlayerService.PlayerServiceBase()

    override _.CreatePlayer (request: CreatePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        request
        |> fromCreatePlayerRequest
        |> storage.InsertPlayer
        |> Async.map toGrpcPlayerResponse
        |> Async.StartAsTask

    override _.GetPlayer (request: GetPlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        base.GetPlayer(request, context)

    override _.UpdatePlayer (request: UpdatePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        base.UpdatePlayer(request, context)

    override _.DeletePlayer (request: DeletePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<Google.Protobuf.WellKnownTypes.Empty> = 
        base.DeletePlayer(request, context)

    override _.ListPlayers (request: ListPlayersRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<ListPlayersResponse> = 
        storage.GetAll()
        |> Async.map toGrpcList
        |> Async.StartAsTask
    

