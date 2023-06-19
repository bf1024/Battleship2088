using Battleship2088.Core;
using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models;
using Battleship2088.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IGrid, Grid>();
        services.AddSingleton<IInputParser, InputParser>();
        services.AddSingleton<IRandomizer, Randomizer>();
        services.AddSingleton<IGame, Game>();
        services.AddSingleton<GameController>();
    })
    .Build();

host.Services.GetService<GameController>()?.RunGame();