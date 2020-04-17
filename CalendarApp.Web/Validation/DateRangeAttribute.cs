using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web.Validation
{
    public class DateRangeAttribute:ValidationAttribute
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool ExcludeRangeValues { get; set; }

      

        private string GetError(ValidationContext context)
        {
            return ErrorMessage ?? $"{context.MemberName} is not in range ";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
         
            var startDate = StartDate ?? DateTime.Now.Date;
            var endDate = EndDate ?? DateTime.MaxValue.Date;
            var dateToValidate = (DateTime)value;

            var validationResult = ExcludeRangeValues ? (dateToValidate > startDate && dateToValidate < endDate) : (dateToValidate >= startDate && dateToValidate <= endDate);

            if (validationResult)
                return ValidationResult.Success;

            return new ValidationResult(GetError(validationContext));
        }
    }
}
