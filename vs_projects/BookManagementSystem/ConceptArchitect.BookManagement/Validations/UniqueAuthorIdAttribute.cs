using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class UniqueAuthorIdAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string id= value as string;
            if (string.IsNullOrEmpty(id))
                return ValidationResult.Success; //not my job. Its the job of required validation

            //we need to access our service here
            var authorService = (IAuthorService) validationContext.GetService(typeof(IAuthorService));
            try
            {
                var author = authorService.GetAuthorById(id).Result; //async not allowed here
                //We got an author. Means validation failed.
                return new ValidationResult($"Duplicate Id '{id}'. Associated with '{author.Name}'");
            }
            catch(InvalidEntityException ex)
            {
                return ValidationResult.Success; //good news search by id failed. author is unique
            }



            return base.IsValid(value, validationContext);
        }
    }
}
