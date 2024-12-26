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
            ItemGen itemGen = new ItemGen();
            itemGen.SetItem();
            Console.WriteLine(itemGen);

            //Console.CursorVisible = false;

            //Screen screen = new Screen();
            //Game game = new Game();
            //Player player = new Player();
            //Item items = new Item();
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //screen.IPSinfo(player, game, items);
            //player.GameInfo(game);
            //game.PSInfo(player, screen);

            //while (game.KeepPlaying)
            //{
            //    game.GameTitle();
            //    screen.SetWall();

            //    while (game.GameIsPlaying)
            //    {
            //        player.HandleOperate();
            //        screen.Update(stopwatch);

            //        screen.Rendering();
            //        Thread.Sleep(TimeSpan.FromMilliseconds(33));                    
            //    }
                
            //}
        }
    }
}
