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
        char randItems;
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
            PosX = random.Next(1, 49);
            PosY = 0;
            ItemType = new char[3] {'0', 'D', 'Q'};
            randItems = ItemType[random.Next(0, ItemType.Length)];
        }

        //일정 주기마다 아이템을 뉴할당 받음
        //뉴할당 받을때마다 x좌표를 랜덤으로 받기
        //그상태에서 해당 아이템의 y좌표만 증가or감소 시키기 즉. 내려가게 끔
        //기능을 확실히 따로 분리해서 위의 아이템을 업데이트 하는 기능
        //그것을 랜더링(출력) 관리해주는 기능으로 분리시켜야 할 듯?


        //Y좌표가 계속 증가하게만 설정해준다.(아래로 떨어져야 하니까)
        public void Update(Game game)
        {
            if (game.GameIsPlaying == true)
            {
                PosY++;
            }
        }

        //출력은 y축이 최대치와 같아질 때 까지만 증가시켜서
        //랜덤하게 뽑혀진 아이템을 아래로 떨어지게 해준다.
        public void Rendering(Screen screen, Game game)
        {
            if (game.GameIsPlaying == true)
            {
                if(PosY <= screen.Height - 1)
                {
                    Console.SetCursorPosition(PosX, PosY);
                    Console.Write(randItems);
                    PosY++;
                }
            }
        }       
    }
}
