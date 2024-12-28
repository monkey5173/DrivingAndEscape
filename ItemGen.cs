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
        Stopwatch stopwatch;

        public ItemGen()
        {
            itemGenerator = new List<Item>();
            stopwatch = new Stopwatch();
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

                    // 만약에 아이템의 Y좌표가 28즉 플레이어하고 같은 위치까지 오면
                    // 해당 리스트의 값을 제거한다. 다 내려온 아이템은 화면에서 삭제
                    if (itemGenerator[i].PosY > screenInfo.Height - 1)
                    {
                        itemGenerator.RemoveAt(i);
                    }

                    // 만약에 플레이어의 좌표와 떨어지는 아이템의 좌표가 같다면 즉, 아이템에 맞았다면 게임오버.
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
                //아이템 리스트의 수 만큼 반복하면서 해당 리스트의 값을 랜더링 해준다.
                for (int i = 0; i < itemGenerator.Count; i++)
                {
                    itemGenerator[i].Rendering(screenInfo, gameInfo);
                }
            }
        }
    }
}
