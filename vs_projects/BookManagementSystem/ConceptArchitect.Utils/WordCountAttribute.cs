using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public  class WordCountAttribute:ValidationAttribute
    {
        int min, max;
        public WordCountAttribute(int min=1, int max=0)
        {
            this.min = min;
            this.max=max; //0 means no limit
            string _max = max > 0 ? max.ToString() : "unlimited";
            this.ErrorMessage = $"Word count should be in range {min}-{_max}";
        }

        /// <summary>
        /// validates the supplied value
        /// 
        /// </summary>
        /// <param name="value">data to be validated. It is the value of current field</param>
        /// <returns>true for valid, false for invalid</returns>
        public override bool IsValid(object? value)
        {
            var text = value as string;
            if (text != null)
            {
                var words = text.Split(' ');
                if (words.Length < min)
                    return false;
                else if (max > 0 && words.Length > max)
                    return false;
                else
                    return true;
            }
            else
                return true; //this is not my job
        }
    }
}
