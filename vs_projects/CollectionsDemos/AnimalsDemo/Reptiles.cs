using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    public  abstract class Reptile : Animal
    {
        public override string Breed()
        {
            return "Egg Laying";
        }

        public override string Eat()
        {
            return "Flesh Eater";
        }

        public override string Move()
        {
            return "Crawls";
        }

       
        public abstract string Hunt();
    }


    public class Crocodile : Reptile
    {
        public override string Hunt()
        {
            return "Underwater Hunter";
        }
    }

    public class Snake : Reptile
    {
        public override string Hunt()
        {
            return "Poisonous Hunter";
        }
    }
}
