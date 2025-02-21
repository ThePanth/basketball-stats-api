namespace BasketballStats.Api.Services

type GameService() = 
    inherit BasketballStats.Protos.GameService.GameServiceBase()

    override _.CreateGame (request: BasketballStats.Protos.CreateGameRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<BasketballStats.Protos.GameResponse> = 
        base.CreateGame(request, context)

    override _.GetGame (request: BasketballStats.Protos.GetGameRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<BasketballStats.Protos.GameResponse> = 
        base.GetGame(request, context)

    override _.DeleteGame (request: BasketballStats.Protos.DeleteGameRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<Google.Protobuf.WellKnownTypes.Empty> = 
        base.DeleteGame(request, context)

    override _.ListGames (request: BasketballStats.Protos.ListGamesRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<BasketballStats.Protos.ListGamesResponse> = 
        base.ListGames(request, context)

    override _.GetGamesByIds (request: BasketballStats.Protos.GetGamesByIdsRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<BasketballStats.Protos.ListGamesResponse> = 
        base.GetGamesByIds(request, context)

    override _.GetGamesByTime (request: BasketballStats.Protos.GetGamesByTimeRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<BasketballStats.Protos.ListGamesResponse> = 
        base.GetGamesByTime(request, context)