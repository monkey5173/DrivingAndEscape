﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sketch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WindowHeight = 30;
            //Console.WindowWidth = 60;
            //Console.WindowHeight = 40;
            //Console.WindowWidth = 80;
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@+..@@@@@@@@@@@@@@@:.....#@...+@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@......%@...@@%......@@@@@#...@@@@@@@@@@@@..@@@@@@@@@@@@@\r\n@......+@@@@@-..@@-:@@..@@@......@@@@......@..%@@@@@@@@@@@@@\r\n@..@@@@-:@@@:...@@@@@.......@@@..%@@..........@@@@@@@@@@@@@@\r\n@@@@.............@@@@...@@+..@@@@@.@....@@:-@@@@.......@@@@@\r\n@@@..@@@@@..@@@...@@@..@@@@@..%@@=..@@@@@@@@@*..@@@@@@@.@@@@\r\n@@@...@@@=..+@@@..@@@@@@@@@@.........@@@@@@@..@@@-...=@@.@@@\r\n@@@@.......@@@@@@@.:.%@@@@@@@..@@@@:..@@@@..@@@--+###=*@..@@\r\n@@@@@@@@@@@@....+@@@%+.....@@@........@@@.#@@#@@@%####-@@.@@\r\n@@@@@@@@@@@..@@@@@#+#@@@@.....@@@@@@@@@@.@@@#+..#@@%##+=@.*@\r\n@@@@@@@@@@@.@@..=+**#%@..+*.*@@..=.......@@%:.+=..@@%##.@:.@\r\n@@@@@@@@@@@..@@@@@@@@@..=*##..@@%@@@@@+.+@@..*++=..-##%-@@.@\r\n@@@@@@@@@@@@*........:@%.:=-..-@@@%%%@@@@...@@%+:@@#=+@@@@.@\r\n@@@@@@@@@@@@#..%@%#@@@@@@..=...=@%%%%%@@@.+:...:@@@@@@.....@\r\n@@@@@@@@@@@@@@..=%+.=@@...@#+@@@@%%%%%@..@........=@@.-#@#.=\r\n@@@@@@@@@@@@@@@@..-+...@@...@@%%%%%%%%@@.@@@@@@@@@...=#%=.@@\r\n@@@@@@@@@@@@@@..@......@.@@.@@@@@%%%%%@@.#@@@@@%@@@...:-.%@@\r\n@@@@@@@@@@@@@%.@@@@@@@==@@@.@@%@@@%%@%@@...@@@@@%@@@#.....@@\r\n@@@@@@@@@@@@@.+@@@@@@#.=.........@@@@@@.@@@-.#@@@@@@@@@@@.@@\r\n@@@@@@@@@@@@@.@@@@@@@..%@@@@@@@@........=........#@@@@@@@.#@\r\n@@@@@@@@@@@@@....@@@@-@@......@@@@@@@@@@@@@@@@@...@#....@=.@\r\n@@@@@@@@@@@@@@@@...@............@@@@@+........@@@..@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@..@.........@@@@@@..........@@=.@..@@@@.@\r\n@@@@@@@@@@@@@@.%@@+.@@@@@@@@@@@.....@@@#=......@..@@@.:@@@.@\r\n@@@@@@@@@@@@@@..@@@.-@.....@@@@..@#.+@@@@@@@@@+.@@@@@-=@@..@\r\n@@@@@@@@@@@@@@@@..@@@.@@@@@..@@@@@@@@@#%@@@@@@.-@@@-.+@..-@@\r\n@@@@@@@@@@@@@@@@..%..@@@@@@@:...............*+..=@@....@@@@@\r\n@@@@@@@@@@@@@@@@@...@...@@@@..#=....#@%..@@%..@+....@@#...@@\r\n@@@@@@@@@@@@@@@@.#@@..+@@=.#@+..@@@%:...@#=@@@@@@*@@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@@@@*...-@#@...@@...@@@@@@@@@@@%.@%%%%@@.@\r\n@@@@@@@@@@@@@@@..+@@@@@@@.@@@@@@@@@@@@@@@@@@@@@...=@@%%%@..+\r\n@@@@@@@@@@@@@@@@@..+===+#..@@@@..*++#=.@@@@@@@@@@@..-===#+..");

            Console.CursorVisible = false;

            Screen screen = new Screen();
            Game game = new Game();
            Player player = new Player();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            screen.Playernfo(player);
            player.GameInfo(game);
            screen.GameInfo(game);
            game.PSInfo(player, screen);

            while (game.KeepPlaying)
            {
                game.GameTitle();
                screen.SetWall();

                while (game.GameIsPlaying)
                {
                    player.HandleOperate();
                    screen.Update(stopwatch);
                    screen.Rendering();
                    Thread.Sleep(TimeSpan.FromMilliseconds(33));                    
                }
                
            }
        }
    }
}
