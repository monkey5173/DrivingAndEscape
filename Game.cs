﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Sketch
{
    struct Vector2
    {
        int _x;
        int _y;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
    }

    class Game
    {
        bool _gameIsPlaying;
        bool _keepPlaying;
        Player playerInfo;
        Screen screenInfo;
        Vector2 printPos;
        int[] _scoreList;

        public bool GameIsPlaying
        {
            get { return _gameIsPlaying; }
            set { _gameIsPlaying = value; }
        }

        public bool KeepPlaying
        {
            get { return _keepPlaying; }
            set { _keepPlaying = value; }
        }

        public int[] ScoreList
        {
            get { return _scoreList; }
            set { _scoreList = value; }
        }

        public Game()
        {
            KeepPlaying = true;
            GameIsPlaying = false;
            printPos = new Vector2();
            ScoreList = new int[20];
        }

        public void PSInfo(Player player, Screen screen)
        {
            playerInfo = player;
            screenInfo = screen;
        }

        public void GameTitle()
        {
            while (true)
            {
                Console.WindowHeight = 40;
                Console.WindowWidth = 120;
                screenInfo.Score = 0;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(".______        ______        ___       _______   _______  __    _______  __    __  .___________. _______ .______      \r\n|   _  \\      /  __  \\      /   \\     |       \\ |   ____||  |  /  _____||  |  |  | |           ||   ____||   _  \\     \r\n|  |_)  |    |  |  |  |    /  ^  \\    |  .--.  ||  |__   |  | |  |  __  |  |__|  | `---|  |----`|  |__   |  |_)  |    \r\n|      /     |  |  |  |   /  /_\\  \\   |  |  |  ||   __|  |  | |  | |_ | |   __   |     |  |     |   __|  |      /     \r\n|  |\\  \\----.|  `--'  |  /  _____  \\  |  '--'  ||  |     |  | |  |__| | |  |  |  |     |  |     |  |____ |  |\\  \\----.\r\n| _| `._____| \\______/  /__/     \\__\\ |_______/ |__|     |__|  \\______| |__|  |__|     |__|     |_______|| _| `._____|\r\n                                                                                                                      \r\n");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t\t       콘솔 게임 로드파이터에 오신것을 환영합니다\n");
                Console.WriteLine("\t\t\t  -------------------------------------------------------------------\n");
                Console.WriteLine("\t\t\t\t\t역동적으로 움직이는 길을 따라 운전하세요\n");
                Console.WriteLine("\t\t\t\t   버티면서 높은 점수를 획득하는 것을 목표로 해봅시다\n");
                Console.WriteLine("\t\t\t   길을 벗어나 벽에 부딪히거나 떨어지는 물체에 맞으면 게임 오버입니다\n");
                Console.WriteLine("\t\t\t  -------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t\t      [조작 설명]\n");
                Console.WriteLine("\t\t\t\t\t  [방향키 ← or 키 A] : 왼쪽 이동\n");
                Console.WriteLine("\t\t\t\t\t  [방향키 → or 키 D] : 오른쪽 이동\n");
                Console.WriteLine("\t\t\t\t\t  [방향키 ↓ or 키 S] : 중립 (고정)\n");
                Console.WriteLine("\t\t\t  -------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t  시작을 원하시면 Enter를 입력해주세요\n");
                Console.WriteLine("\t\t\t\t\t   종료을 원하시면 ESC를 입력해주세요");

                var inputKey = Console.ReadKey(true);

                if(inputKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    GameIsPlaying = true;
                    break;
                }
                else if (inputKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("게임이 종료됩니다");
                    KeepPlaying = false;
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }            
        }

        public void GameOver()
        {
            GameIsPlaying = false;
            Console.Clear();
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t\t< GAME OVER >");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"\t\t   [획득 점수] : {screenInfo.Score}");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("\t타이틀로 돌아가시려면 Enter 키를 입력해주세요");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("\t    종료를 원하시면 ESC 키를 입력해주세요");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@+..@@@@@@@@@@@@@@@:.....#@...+@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@......%@...@@%......@@@@@#...@@@@@@@@@@@@..@@@@@@@@@@@@@\r\n@......+@@@@@-..@@-:@@..@@@......@@@@......@..%@@@@@@@@@@@@@\r\n@..@@@@-:@@@:...@@@@@.......@@@..%@@..........@@@@@@@@@@@@@@\r\n@@@@.............@@@@...@@+..@@@@@.@....@@:-@@@@.......@@@@@\r\n@@@..@@@@@..@@@...@@@..@@@@@..%@@=..@@@@@@@@@*..@@@@@@@.@@@@\r\n@@@...@@@=..+@@@..@@@@@@@@@@.........@@@@@@@..@@@-...=@@.@@@\r\n@@@@.......@@@@@@@.:.%@@@@@@@..@@@@:..@@@@..@@@--+###=*@..@@\r\n@@@@@@@@@@@@....+@@@%+.....@@@........@@@.#@@#@@@%####-@@.@@\r\n@@@@@@@@@@@..@@@@@#+#@@@@.....@@@@@@@@@@.@@@#+..#@@%##+=@.*@\r\n@@@@@@@@@@@.@@..=+**#%@..+*.*@@..=.......@@%:.+=..@@%##.@:.@\r\n@@@@@@@@@@@..@@@@@@@@@..=*##..@@%@@@@@+.+@@..*++=..-##%-@@.@\r\n@@@@@@@@@@@@*........:@%.:=-..-@@@%%%@@@@...@@%+:@@#=+@@@@.@\r\n@@@@@@@@@@@@#..%@%#@@@@@@..=...=@%%%%%@@@.+:...:@@@@@@.....@\r\n@@@@@@@@@@@@@@..=%+.=@@...@#+@@@@%%%%%@..@........=@@.-#@#.=\r\n@@@@@@@@@@@@@@@@..-+...@@...@@%%%%%%%%@@.@@@@@@@@@...=#%=.@@\r\n@@@@@@@@@@@@@@..@......@.@@.@@@@@%%%%%@@.#@@@@@%@@@...:-.%@@\r\n@@@@@@@@@@@@@%.@@@@@@@==@@@.@@%@@@%%@%@@...@@@@@%@@@#.....@@\r\n@@@@@@@@@@@@@.+@@@@@@#.=.........@@@@@@.@@@-.#@@@@@@@@@@@.@@\r\n@@@@@@@@@@@@@.@@@@@@@..%@@@@@@@@........=........#@@@@@@@.#@\r\n@@@@@@@@@@@@@....@@@@-@@......@@@@@@@@@@@@@@@@@...@#....@=.@\r\n@@@@@@@@@@@@@@@@...@............@@@@@+........@@@..@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@..@.........@@@@@@..........@@=.@..@@@@.@\r\n@@@@@@@@@@@@@@.%@@+.@@@@@@@@@@@.....@@@#=......@..@@@.:@@@.@\r\n@@@@@@@@@@@@@@..@@@.-@.....@@@@..@#.+@@@@@@@@@+.@@@@@-=@@..@\r\n@@@@@@@@@@@@@@@@..@@@.@@@@@..@@@@@@@@@#%@@@@@@.-@@@-.+@..-@@\r\n@@@@@@@@@@@@@@@@..%..@@@@@@@:...............*+..=@@....@@@@@\r\n@@@@@@@@@@@@@@@@@...@...@@@@..#=....#@%..@@%..@+....@@#...@@\r\n@@@@@@@@@@@@@@@@.#@@..+@@=.#@+..@@@%:...@#=@@@@@@*@@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@@@@*...-@#@...@@...@@@@@@@@@@@%.@%%%%@@.@\r\n@@@@@@@@@@@@@@@..+@@@@@@@.@@@@@@@@@@@@@@@@@@@@@...=@@%%%@..+\r\n@@@@@@@@@@@@@@@@@..+===+#..@@@@..*++#=.@@@@@@@@@@@..-===#+..");
            ScoreRanking();
            playerInfo.ResetPlayerInfo();

            while (true)
            {
                var inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    Console.ResetColor();
                    Console.Clear();
                    return;
                }
                else if (inputKey.Key == ConsoleKey.Escape)
                {
                    Console.ResetColor();
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("\t정확한 키를 입력해주세요");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("타이틀 화면으로 돌아가시려면 Enter 키를 입력");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("종료를 원하시면 ESC 키를 입력해주세요");
                    Console.WriteLine("--------------------------------------------");

                }
            }
            
        }

        public void ScoreRanking()
        {            
            printPos.X = 62;
            printPos.Y = 0;

            for (int i = 0; i < ScoreList.Length; i++) 
            {
                if (ScoreList[i] == 0)
                {
                    ScoreList[i] = screenInfo.Score;
                    break;
                }                        
            }

            for (int i = 0; i < ScoreList.Length; i++)
            {
                for (int j = 1; j < ScoreList.Length; j++)
                {
                    if (ScoreList[j - 1] < ScoreList[j])
                    {
                        int temp = ScoreList[j];
                        ScoreList[j] = ScoreList[j - 1];
                        ScoreList[j - 1] = temp;
                    }
                }
            }

            Console.SetCursorPosition(printPos.X, 0);
            Console.Write("  [점수 랭킹]");
            Console.SetCursorPosition(printPos.X, 1);
            Console.Write("---------------");

            for (int i = 0; i < ScoreList.Length / 2; i++)
            {
                Console.SetCursorPosition(printPos.X, i + 2);                                                
                Console.Write($" [{i + 1}등] : {ScoreList[i]}");                
            }
            Console.SetCursorPosition(printPos.X, 12);
            Console.Write("---------------");
            for (int i = 10; i < ScoreList.Length; i++)
            {
                Console.SetCursorPosition(printPos.X, i + 3);
                Console.Write($" [{i + 1}등] : {ScoreList[i]}");
            }
        }
    }
}
