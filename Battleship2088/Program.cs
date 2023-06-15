﻿using Battleship2088.Core;
using Battleship2088.Core.Models;
using Battleship2088.Core.Models.Enums;
using Battleship2088.Utils;

Console.WriteLine("Welcome to Battleship 2088!");

DrawLogo();

var game = new Game(new Grid(), new InputParser(), new Randomizer());

// Main game loop
while (!game.IsGameOver())
{
    Console.WriteLine("Please enter coordinates to shoot (in example, A5), enter 'draw' to cheat and draw grid:");

    string input = Console.ReadLine()!;
    try
    {
        if (input == "draw")
        {
            game.DrawGrid();
        }
        else
        {
            var result = game.PlayTurn(input!);

            switch (result)
            {
                case HitResult.Miss:
                    Console.WriteLine("Miss!");
                    break;
                case HitResult.Hit:
                    Console.WriteLine("Hit!");
                    break;
                case HitResult.AlreadyHit:
                    Console.WriteLine("Already hit at this coordinate!");
                    break;
                case HitResult.Sunk:
                    Console.WriteLine("You have sunk a ship!");
                    break;
            }
        }
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine("Congratulations! You sunk all the ships.");
Console.ReadLine();

void DrawLogo()
{
    Console.WriteLine("  ______       _   _   _           _     _         _____  _____ _____  _____ ");
    Console.WriteLine("  | ___ \\     | | | | | |         | |   (_)       / __  \\|  _  |  _  ||  _  |");
    Console.WriteLine("  | |_/ / __ _| |_| |_| | ___  ___| |__  _ _ __   `' / /'| |/' |\\ V /  \\ V / ");
    Console.WriteLine("  | ___ \\/ _` | __| __| |/ _ \\/ __| '_ \\| | '_ \\    / /  |  /| |/ _ \\  / _ \\ ");
    Console.WriteLine("  | |_/ / (_| | |_| |_| |  __/\\__ \\ | | | | |_) | ./ /___\\ |_/ / |_| || |_| |");
    Console.WriteLine("  \\____/ \\__,_|\\__|\\__|_|\\___||___/_| |_|_| .__/  \\_____/ \\___/\\_____/\\_____/");
    Console.WriteLine("                                          | |                                ");
    Console.WriteLine("                                          |_|                                ");
}