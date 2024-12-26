using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketch
{
    class Item
    {
        char[] _itemType;
        int _velocity;
        int _posX;
        int _posY;
        Random random = new Random();

        public char[] ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        public int Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }

        public Item() 
        {
            PosX = random.Next(0, 50);
            PosY = 0;
            ItemType = new char[3] {'★', '♥', '■'};
        }

        //일정 주기마다 아이템을 뉴할당 받음
        //뉴할당 받을때마다 x좌표를 랜덤으로 받기
        //그상태에서 해당 아이템의 y좌표만 증가or감소 시키기 즉. 내려가게 끔
        //기능을 확실히 따로 분리해서 위의 아이템을 업데이트 하는 기능
        //그것을 랜더링(출력) 관리해주는 기능으로 분리시켜야 할 듯?


        //public void DropItems(Player player, Screen screen, Game game)
        //{
        //    Random posRandom = new Random();
        //    itemPos.X = posRandom.Next(0, screen.Width);
        //    int randomType = posRandom.Next(0, 3);

        //    if (game.GameIsPlaying)
        //    {
        //        for (int i = 0; i < screen.Height; i++)
        //        {
        //            Console.SetCursorPosition(itemPos.X, itemPos.Y);
        //            Console.Write(' ');

        //            itemPos.Y++;

        //            if(itemPos.Y < screen.Height - 1)
        //            {
        //                Console.SetCursorPosition(itemPos.X, itemPos.Y);
        //                Console.Write(ItemType[randomType]);
        //            }
        //            else
        //            {
        //                Console.SetCursorPosition(itemPos.X, itemPos.Y);
        //                Console.Write(' ');
        //                break;
        //            }
        //        }
                    

        //    }
        //}
    }
}
