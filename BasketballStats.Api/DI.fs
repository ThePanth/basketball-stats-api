module BasketballStats.Api.DI

open Microsoft.Extensions.DependencyInjection

let addDI (services: IServiceCollection): IServiceCollection = 
    services
    |> BasketballStats.Data.DI.addDI

    

