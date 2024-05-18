using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{

    [AttributeUsage(AttributeTargets.Method)]
    public class SpecialBehaviorAttribute:Attribute
    {
    }
}
