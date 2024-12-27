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
            if (gameInfo.GameIsPlaying == true)
            {
                if (stopwatch.ElapsedMilliseconds > 300)
                {
                    itemGenerator.Add(new Item());
                    stopwatch.Restart();
                }
            }
        }

        public void Update()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                for (int i = 0; i < itemGenerator.Count; i++)
                {
                    itemGenerator[i].Update(gameInfo);

                    if (itemGenerator[i].PosY > screenInfo.Height - 1)
                    {
                        itemGenerator.RemoveAt(i);
                    }

                    else if (itemGenerator[i].PosY == playerInfo.PosY && itemGenerator[i].PosX == playerInfo.PosX)
                    {
                        gameInfo.GameOver();
                    }
                }

            }
        }

        public void Rendering()
        {
            if (gameInfo.GameIsPlaying == true)
            {
                for (int i = 0; i < itemGenerator.Count; i++)
                {
                    itemGenerator[i].Rendering(screenInfo, gameInfo);
                }
            }
        }
    }
}
