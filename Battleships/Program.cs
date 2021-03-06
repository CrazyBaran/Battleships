﻿using Battleships.Core;
using Battleships.Core.Model;
using System;

namespace Battleships
{
    class Program
    {
        public const int BattleShipSize = 5;
        public const int DestroyerShipSize = 4;
        static void Main(string[] args)
        {
            Console.WriteLine("In galaxy far far away");
            using (var ui = new StreamUserInteraction(Console.OpenStandardInput(), Console.OpenStandardOutput()))
            {
                var gridManager = new GridManager(new DefaultRandomProvider());
                var grid = gridManager.GetEmptyGrid(10);
                gridManager.PlaceShips(
                    grid,
                    new[]
                    {
                        new Ship(BattleShipSize),
                        new Ship(DestroyerShipSize),
                        new Ship(DestroyerShipSize)
                    });
                var gameLoop = new GameLoop(grid, ui);
                gameLoop.Run();
            }
        }
    }
}
