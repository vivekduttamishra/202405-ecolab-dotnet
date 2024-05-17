using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests
{
    internal class Bike
    {
        public string brand{get;set;}
        public string model{get;set;}
        public int price  { get; set;}

        public Bike(string brand, string model, int price)
        {
            this.brand = brand;
            this.model = model;
            this.price = price;
        }
    }    
}
