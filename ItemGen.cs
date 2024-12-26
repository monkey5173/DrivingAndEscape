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
        Stopwatch stopwatch = new Stopwatch();

        public ItemGen()
        {
            itemGenerator = new List<Item>();
        }

        public void SetItem()
        {
            stopwatch.Start();
            if(stopwatch.ElapsedMilliseconds > 3000)
            {
                itemGenerator.Add(new Item());
            }
            stopwatch.Reset();
        }

        public void Rendering()
        {
            
        }
    }
}
