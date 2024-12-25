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
