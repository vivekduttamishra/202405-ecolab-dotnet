using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo07
{
    public class Basket
    {
        public long Items { get; private set; }
        Random r = new Random();


        public void AddItem()
        {
            lock(this)  //try{Monitor.Enter(this)
            {
                var x = Items;
                x++;
                Items = x;
            }  // finally{ Montior.Exit(this) ;}
            
        }

        public void AddItemV2()
        {
            try
            {
                
                while(!Monitor.TryEnter(this))
                    Console.Write("!"); 
                var x = Items;
                x++;
                Items = x;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}
