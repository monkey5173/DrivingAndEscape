using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketch
{
    class Game
    {
        bool _gameIsPlaying;
        bool _keepPlaying;
        Player playerInfo;
        Screen screenInfo;

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

        public Game()
        {
            KeepPlaying = true;
            GameIsPlaying = false;
        }

        public void GameInfo(Player player, Screen screen)
        {
            playerInfo = player;
            screenInfo = screen;
        }

        public void GameTitle()
        {
            while (true)
            {
                Console.WindowHeight = 35;
                Console.WindowWidth = 60;
                Console.WriteLine("게임을 시작하시겠습니까?");
                Console.WriteLine("시작을 원하시면 Enter를 입력해주세요");
                Console.WriteLine("종료을 원하시면 ESC를 입력해주세요");

                var inputKey = Console.ReadKey(true);

                if(inputKey.Key == ConsoleKey.Enter)
                {
                    GameIsPlaying = true;
                    break;
                }
                else if (inputKey.Key == ConsoleKey.Escape)
                {
                    KeepPlaying = false;
                    break;
                }
            }            
        }

        public void GameOver()
        {
            GameIsPlaying = false;
            Console.SetCursorPosition(0, 0);
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("재시작을 원하시면 Enter키를 입력해주세요");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@+..@@@@@@@@@@@@@@@:.....#@...+@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@......%@...@@%......@@@@@#...@@@@@@@@@@@@..@@@@@@@@@@@@@\r\n@......+@@@@@-..@@-:@@..@@@......@@@@......@..%@@@@@@@@@@@@@\r\n@..@@@@-:@@@:...@@@@@.......@@@..%@@..........@@@@@@@@@@@@@@\r\n@@@@.............@@@@...@@+..@@@@@.@....@@:-@@@@.......@@@@@\r\n@@@..@@@@@..@@@...@@@..@@@@@..%@@=..@@@@@@@@@*..@@@@@@@.@@@@\r\n@@@...@@@=..+@@@..@@@@@@@@@@.........@@@@@@@..@@@-...=@@.@@@\r\n@@@@.......@@@@@@@.:.%@@@@@@@..@@@@:..@@@@..@@@--+###=*@..@@\r\n@@@@@@@@@@@@....+@@@%+.....@@@........@@@.#@@#@@@%####-@@.@@\r\n@@@@@@@@@@@..@@@@@#+#@@@@.....@@@@@@@@@@.@@@#+..#@@%##+=@.*@\r\n@@@@@@@@@@@.@@..=+**#%@..+*.*@@..=.......@@%:.+=..@@%##.@:.@\r\n@@@@@@@@@@@..@@@@@@@@@..=*##..@@%@@@@@+.+@@..*++=..-##%-@@.@\r\n@@@@@@@@@@@@*........:@%.:=-..-@@@%%%@@@@...@@%+:@@#=+@@@@.@\r\n@@@@@@@@@@@@#..%@%#@@@@@@..=...=@%%%%%@@@.+:...:@@@@@@.....@\r\n@@@@@@@@@@@@@@..=%+.=@@...@#+@@@@%%%%%@..@........=@@.-#@#.=\r\n@@@@@@@@@@@@@@@@..-+...@@...@@%%%%%%%%@@.@@@@@@@@@...=#%=.@@\r\n@@@@@@@@@@@@@@..@......@.@@.@@@@@%%%%%@@.#@@@@@%@@@...:-.%@@\r\n@@@@@@@@@@@@@%.@@@@@@@==@@@.@@%@@@%%@%@@...@@@@@%@@@#.....@@\r\n@@@@@@@@@@@@@.+@@@@@@#.=.........@@@@@@.@@@-.#@@@@@@@@@@@.@@\r\n@@@@@@@@@@@@@.@@@@@@@..%@@@@@@@@........=........#@@@@@@@.#@\r\n@@@@@@@@@@@@@....@@@@-@@......@@@@@@@@@@@@@@@@@...@#....@=.@\r\n@@@@@@@@@@@@@@@@...@............@@@@@+........@@@..@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@..@.........@@@@@@..........@@=.@..@@@@.@\r\n@@@@@@@@@@@@@@.%@@+.@@@@@@@@@@@.....@@@#=......@..@@@.:@@@.@\r\n@@@@@@@@@@@@@@..@@@.-@.....@@@@..@#.+@@@@@@@@@+.@@@@@-=@@..@\r\n@@@@@@@@@@@@@@@@..@@@.@@@@@..@@@@@@@@@#%@@@@@@.-@@@-.+@..-@@\r\n@@@@@@@@@@@@@@@@..%..@@@@@@@:...............*+..=@@....@@@@@\r\n@@@@@@@@@@@@@@@@@...@...@@@@..#=....#@%..@@%..@+....@@#...@@\r\n@@@@@@@@@@@@@@@@.#@@..+@@=.#@+..@@@%:...@#=@@@@@@*@@@@@@@@.@\r\n@@@@@@@@@@@@@@@.@@@@@@*...-@#@...@@...@@@@@@@@@@@%.@%%%%@@.@\r\n@@@@@@@@@@@@@@@..+@@@@@@@.@@@@@@@@@@@@@@@@@@@@@...=@@%%%@..+\r\n@@@@@@@@@@@@@@@@@..+===+#..@@@@..*++#=.@@@@@@@@@@@..-===#+..");
            var inputKey = Console.ReadKey();
            if(inputKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return;
            }
        }
    }
}
