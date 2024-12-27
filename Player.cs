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
        char _seletShape;

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

        public char SeletShape
        {
            get { return _seletShape; }
            set { _seletShape = value; }
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
                PosX = screenInfo.Width / 2;
                PosY = screenInfo.Height - 2;

                for (int i = 0; i < screenInfo.Height; i++)
                {
                    for (int j = 0; j < screenInfo.Width; j++)
                    {
                        if (i == PosY && j == PosX)
                        {
                            if (Velocity < 0)
                            {
                                SeletShape = Shape[0];
                            }
                            else if (Velocity > 0)
                            {
                                SeletShape = Shape[1];
                            }
                            else
                            {
                                SeletShape = Shape[2];
                            }
                        }
                    }
                }

                //충돌 감지 기능
                if (PosX < 0 || PosX >= screenInfo.Width || screenInfo.Wall[PosY, PosX] != ' ')
                {
                    gameInfo.GameOver();
                    return;
                }

                PosX += Velocity; // 플레이어 포지션에 속도(방향)의 값을 업데이트 해준다.
            }
        }

        public void Rendering()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                for (int i = 0; i < screenInfo.Height; i++)
                {
                    for (int j = 0; j < screenInfo.Width; j++)
                    {
                        if (i == PosY && j == PosX)
                        {
                            if (Velocity < 0)
                            {
                                Console.Write(SeletShape);
                            }
                            else if (Velocity > 0)
                            {
                                Console.Write(SeletShape);
                            }
                            else
                            {
                                Console.Write(SeletShape);
                            }
                        }
                    }
                }
             
            }
        }
    }
}
