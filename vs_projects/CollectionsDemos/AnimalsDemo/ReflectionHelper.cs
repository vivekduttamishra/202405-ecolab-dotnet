using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    public static  class ReflectionHelper
    {
        public static void InvokeAllMethods(this Type type)
        {
            var obj= Activator.CreateInstance(type);
            obj.InvokeAllMethods();
        }
        public static void InvokeAllMethods(this object obj)
        {
            var type = obj.GetType();

            foreach(var method in type.GetMethods())
            {
                if(method.DeclaringType==typeof(object))
                {
                    Console.WriteLine($"Skipping object method {method.Name}");
                    continue;
                }

                if (method.GetParameters().Length > 0)
                {
                    Console.WriteLine($"Skipping parameterized method {method.Name}");
                    continue;
                }
                Console.WriteLine($"Invoking Method {method.Name}");
                object result = null;
                if(method.IsStatic)
                {
                    result = method.Invoke(null, null); // no object, no parameter
                }
                else
                {
                   result = method.Invoke(obj, null); //obj.method()
                }
                Console.WriteLine($"\t\tResult:{result}\n");
            }
        }
   
        public static List<MethodInfo> GetSpecialBehavior(this Type type) 
        {
            var result = new List<MethodInfo>();
            foreach(var method in type.GetMethods())
            {
                var attribute = method.GetCustomAttribute<SpecialBehaviorAttribute>();
                if(attribute != null)
                {
                    result.Add(method);
                }
            }

            return result;
        }

        public static List<MethodInfo> GetSpecialBehaviors(this object obj)
        {
            return obj.GetType().GetSpecialBehavior();
        }
    
    }
}
