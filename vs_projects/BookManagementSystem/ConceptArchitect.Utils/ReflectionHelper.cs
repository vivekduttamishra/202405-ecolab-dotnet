using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public static  class ReflectionHelper
    {
        public static Dictionary<string,Exception> Copy<T>(this T source, object target, params string[] excludedProperty)
        {
            var sourceType= typeof(T);
            var targetType= target.GetType();
            Dictionary<string,Exception> errors= new Dictionary<string, Exception>();

            foreach(var property in sourceType.GetProperties())
            {
                try
                {
                    if(excludedProperty.Contains(property.Name)) { continue; }

                    var targetProperty = targetType.GetProperty(property.Name);
                    if (targetProperty != null)
                        continue;

                    var value = targetProperty.GetValue(target);

                    property.SetValue(source, value);

                }
                catch(Exception ex)
                {
                    errors[property.Name] = ex;
                }
            }

            return errors;
        }


        public static Dictionary<string, Exception> CopyOnly<T>(this T source, object target, params string[] includedProperty)
        {
            var sourceType = typeof(T);
            var targetType = target.GetType();
            Dictionary<string, Exception> errors = new Dictionary<string, Exception>();

            foreach (var property in sourceType.GetProperties())
            {
                try
                {
                    if (!includedProperty.Contains(property.Name)) { continue; }

                    var targetProperty = targetType.GetProperty(property.Name);
                    if (targetProperty != null)
                        continue;

                    var value = targetProperty.GetValue(target);

                    property.SetValue(source, value);

                }
                catch (Exception ex)
                {
                    errors[property.Name] = ex;
                }
            }

            return errors;
        }

    }
}
