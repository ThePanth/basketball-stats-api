namespace BasketballStats.Api.Services

open BasketballStats.Protos

type StatisticsService() =
    inherit BasketballStats.Protos.StatisticsService.StatisticsServiceBase()

    override _.CreateStatisticEntry (request: CreateStatisticEntryRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<StatisticEntryResponse> = 
        base.CreateStatisticEntry(request, context)

    override _.RemoveStatisticEntry (request: RemoveStatisticEntryRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<Google.Protobuf.WellKnownTypes.Empty> = 
        base.RemoveStatisticEntry(request, context)

    override _.GetGameStatistics (request: GetGameStatisticsRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<StatisticsResponse> = 
        base.GetGameStatistics(request, context)

    override _.GetPlayerStatistics (request: GetPlayerStatisticsRequest, context: Grpc.Core.ServerCallContext): System.Threading.Tasks.Task<StatisticsResponse> = 
        base.GetPlayerStatistics(request, context)