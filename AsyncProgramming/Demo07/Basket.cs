using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07
{
    public class Basket
    {
        public long Items { get; private set; }

        public void AddItem()
        {
            var x = Items;
            x++;
            Items = x;
        }
    }
}
