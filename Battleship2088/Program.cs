using Battleship2088.Core;
using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models;
using Battleship2088.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services =>
    {
        services.AddSingleton<IGrid, Grid>();
        services.AddSingleton<IInputParser, InputParser>();
        services.AddSingleton<IRandomizer, Randomizer>();
        services.AddSingleton<IGame, Game>();
        services.AddSingleton<GameController>();
    });

var host = builder.Build();


host.Services.GetService<GameController>()?.RunGame();