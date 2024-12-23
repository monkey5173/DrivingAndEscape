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
    }
}
