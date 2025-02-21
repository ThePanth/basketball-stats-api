open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open BasketballStats.Api.Services
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Server.Kestrel.Core

open Microsoft.Extensions.DependencyInjection

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.WebHost.ConfigureKestrel(fun options ->
        options.ConfigureEndpointDefaults(fun listenOptions ->
            listenOptions.Protocols <- HttpProtocols.Http2
        )
    ) |> ignore

    
    // Register code-first gRPC services using protobuf-net.Grpc
    builder.Services.AddGrpc() |> ignore
    builder.Services.AddGrpcReflection() |> ignore
    
    let app = builder.Build()
    
    // Map the gRPC service endpoint
    app.MapGrpcService<StatisticsService>() |> ignore
    app.MapGrpcService<PlayerService>() |> ignore
    app.MapGrpcService<GameService>() |> ignore

    if app.Environment.IsDevelopment() then
        app.MapGrpcReflectionService() |> ignore

    // Optional endpoint to inform clients about using gRPC
    app.MapGet("/", fun (context: HttpContext) -> context.Response.WriteAsync("This service only supports gRPC calls. Please use a gRPC client.")) |> ignore
    
    app.Run()
    0
