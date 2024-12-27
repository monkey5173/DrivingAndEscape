using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Sketch
{
           
    class Player
    {
        int _posX;
        int _posY;
        int _velocity;
        Game gameInfo;
        Screen screenInfo;
        char[] _shape;

        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }

        public int Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public char[] Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public Player()
        {
            Shape = new char[3] {'<', '>', '^' };
            Velocity = 0;
        }

        public void SGinfo(Screen screen, Game game)
        {
            screenInfo = screen;
            gameInfo = game;
            PosX = screenInfo.Width / 2;
            PosY = screenInfo.Height - 2;
        }

        public void ResetPlayerInfo()
        {
            PosX = screenInfo.Width / 2;
            PosY = screenInfo .Height - 2;
            Velocity = 0;
        }

        public void HandleOperate()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                while (Console.KeyAvailable)
                {
                    var inputkey = Console.ReadKey(true);

                    if (inputkey.Key == ConsoleKey.A || inputkey.Key == ConsoleKey.LeftArrow)
                    {
                        Velocity = -1;
                    }
                    else if (inputkey.Key == ConsoleKey.D || inputkey.Key == ConsoleKey.RightArrow)
                    {
                        Velocity = +1;
                    }
                    else if (inputkey.Key == ConsoleKey.S || inputkey.Key == ConsoleKey.DownArrow)
                    {
                        Velocity = 0;
                    }
                }
            }
        }

        public void Update()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                PosX += Velocity; // 플레이어 포지션에 속도(방향)의 값을 업데이트 해준다.
               
                //충돌 감지 기능
                if (PosX < 0 || PosX >= screenInfo.Width || screenInfo.Wall[1, PosX] != ' ')
                {
                    gameInfo.GameOver();
                }
            }
        }

        public void Rendering()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                Console.SetCursorPosition(PosX, PosY);

                if (Velocity < 0)
                {
                    Console.Write(Shape[0]);
                }
                else if (Velocity > 0)
                {
                    Console.Write(Shape[1]);
                }
                else
                {
                    Console.Write(Shape[2]);
                }
            }
        }
    }
}
