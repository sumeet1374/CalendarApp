using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Web.Validation
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider baseProvider =   new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if(attribute is DateRangeAttribute)
            {
                return new DateRangeAttributeAdapter(attribute as DateRangeAttribute, stringLocalizer);
            }
            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
