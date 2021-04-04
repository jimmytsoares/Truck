using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Core.Handlers
{
    public class StrictYearAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"The model year must be the same as the current year or next year";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {        

            if ((ushort)value != DateTime.Now.Year && (ushort)value != DateTime.Now.Year + 1)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
