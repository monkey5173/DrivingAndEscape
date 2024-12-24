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

        public void HandleOperate()
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
}
