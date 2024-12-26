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
        int _position;
        int _velocity;
        Game gameInfo;
        Screen screenInfo;
        char[] _shape;

        public int Position
        {
            get { return _position; }
            set { _position = value; }
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
            Position 

            car.Position += car.Velocity; // 플레이어 포지션에 속도(방향)의 값을 업데이트 해준다.

            //충돌 감지 기능
            if (car.Position < 0 || car.Position >= Width || Wall[1, car.Position] != ' ')
            {
                gameInfo.GameOver();
                return;
            }
        }
    }
}
