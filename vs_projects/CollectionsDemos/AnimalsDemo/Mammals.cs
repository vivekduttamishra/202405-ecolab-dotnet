using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    public abstract class Mammal : Animal
    {
        public override string Breed()
        {
            return "Child Brith";
        }
        public override string Move()
        {
            return "Moves on Land";
        }
    }

    public class Cat : Mammal
    {
        public override string Eat()
        {
            return "Eats Flesh";
        }

        [SpecialBehavior]
        public virtual string Hunt()
        {
            return "Hunts its prey";
        }
       
    }


    class Tiger : Cat { }
    class Leopard : Cat { }

   // [SpecialBehavior]
    public class Horse : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }

        [SpecialBehavior]
        public string Ride()
        {
            return "Great Ride";
        }
    }

    public class Camel : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }

        public string Ride()
        {
            return "Desert Ride";
        }
    }

    public class Cow : Mammal
    {
        public override string Eat()
        {
            return "Grass Eater";
        }

        public string ProvidesMilk()
        {
            return "Milk Provider";
        }
    }
}
