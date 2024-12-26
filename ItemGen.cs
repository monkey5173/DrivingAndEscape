using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketch
{
    class ItemGen
    {
        List<Item> itemGenerator;
        Player playerInfo;
        Screen screenInfo;
        Game gameInfo;
        Stopwatch stopwatch = new Stopwatch();

        public ItemGen()
        {
            itemGenerator = new List<Item>();
            stopwatch.Start();
        }

        public void PsgInfo(Player player, Screen screen, Game game)
        {
            playerInfo = player;
            screenInfo = screen;
            gameInfo = game;
        }

        public void SetItem()
        {
            if(stopwatch.ElapsedMilliseconds > 3000)
            {
                itemGenerator.Add(new Item());
                stopwatch.Restart();
            }
        }

        public void Rendering()
        {
            for(int i = 0; i < itemGenerator.Count; i++)
            {
                itemGenerator[i].Update(screenInfo, gameInfo);
            }
        }
    }
}
