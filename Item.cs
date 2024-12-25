using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketch
{
    class Item
    {
        Vector2 itemPos;
        char[] _itemType;

        public char[] ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        public Item() 
        { 
            itemPos = new Vector2();
            ItemType = new char[3] {'★', '♥', '■'};
        }

        //아이템을 랜덤으로 떨구기 위해서는 커서포지션으로 랜덤설정을 하는 방법은 해선 안됨
        //이유는 스트링빌더에서 반복문으로 커서 포지션도 초기화 해주면서 계속 출력중임
        //즉! 게임이 돌아가는 상태에서 커서포지션을 랜덤으로 옮기면서 덮어씌워가면서
        //출력하는 방식은 구동되면서 출력되고 있는 벽과 공백에 지장을 주게 됨.
        //막, 어지럽게 출력됨 갑자기 위로 쭈욱 올라가면서 출력되고 게임오버가 된다든가(크아아앜)
        //뭔 생각지도 못한 곳에 막 출력되고 아이템도 같이 난동을 부리기 시작함. 술취한 진상손님인줄..
        //따라서 스트링빌더에 조건문으로 플레이어의 좌표를 정해주고, 출력까지 했듯이
        //아이템도 스트링빌더에 조건을 걸어서 출력하게 해야 함.
        public void DropItems(Player player, Screen screen, Game game)
        {
            Random posRandom = new Random();
            itemPos.X = posRandom.Next(0, screen.Width);
            int randomType = posRandom.Next(0, 3);

            if (game.GameIsPlaying)
            {
                for (int i = 0; i < screen.Height; i++)
                {
                    Console.SetCursorPosition(itemPos.X, itemPos.Y);
                    Console.Write(' ');

                    itemPos.Y++;

                    if(itemPos.Y < screen.Height - 1)
                    {
                        Console.SetCursorPosition(itemPos.X, itemPos.Y);
                        Console.Write(ItemType[randomType]);
                    }
                    else
                    {
                        Console.SetCursorPosition(itemPos.X, itemPos.Y);
                        Console.Write(' ');
                        break;
                    }
                }
                    

            }
        }
    }
}
