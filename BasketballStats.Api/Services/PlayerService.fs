namespace BasketballStats.Api.Services

open BasketballStats.Protos

type PlayerService() =
    inherit BasketballStats.Protos.PlayerService.PlayerServiceBase()

    override _.CreatePlayer (request: CreatePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        base.CreatePlayer(request, context)

    override _.GetPlayer (request: GetPlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        base.GetPlayer(request, context)

    override _.UpdatePlayer (request: UpdatePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<PlayerResponse> = 
        base.UpdatePlayer(request, context)

    override _.DeletePlayer (request: DeletePlayerRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<Google.Protobuf.WellKnownTypes.Empty> = 
        base.DeletePlayer(request, context)

    override _.ListPlayers (request: ListPlayersRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<ListPlayersResponse> = 
        base.ListPlayers(request, context)
    

