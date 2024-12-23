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

        public bool GameIsPlaying
        {
            get { return _gameIsPlaying; }
            set { _gameIsPlaying = value; }
        }

        public Game()
        {
            GameIsPlaying = false;
        }

        public void GameIsRunning()
        {
            GameIsPlaying = true;
        }
    }
}
