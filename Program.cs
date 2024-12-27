using System;
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
            Console.CursorVisible = false;

            Screen screen = new Screen();
            Game game = new Game();
            Player player = new Player();
            Item items = new Item();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            screen.IPSinfo(player, game, items);
            player.SGinfo(screen, game);
            game.PSInfo(player, screen);
            ItemGen itemgenerator = new ItemGen();
            itemgenerator.PsgInfo(player, screen, game);

            while (game.KeepPlaying)
            {
                game.GameTitle();
                screen.SetWall();

                while (game.GameIsPlaying)
                {
                    player.HandleOperate();
                    screen.Update(stopwatch);
                    player.Update();
                    itemgenerator.SetItem();
                    itemgenerator.Update();

                    screen.Rendering();
                    player.Rendering();
                    itemgenerator.Rendering();
                    Thread.Sleep(TimeSpan.FromMilliseconds(33));
                }

            }
        }
    }
}
