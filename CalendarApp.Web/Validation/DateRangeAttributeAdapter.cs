using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace CalendarApp.Web.Validation
{
    public class DateRangeAttributeAdapter : AttributeAdapterBase<DateRangeAttribute>
    {
        public DateRangeAttributeAdapter(DateRangeAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-daterange", GetErrorMessage(context));

            var startDate = (Attribute.StartDate ?? DateTime.Now.Date).ToString(CultureInfo.InvariantCulture);
            var endDate = (Attribute.EndDate ?? DateTime.MaxValue.Date).ToString(CultureInfo.InvariantCulture);
            var excludeRangeValue = Attribute.ExcludeRangeValues.ToString();
            MergeAttribute(context.Attributes, "data-val-daterange-startdate", startDate);
            MergeAttribute(context.Attributes, "data-val-daterange-enddate", endDate);
            MergeAttribute(context.Attributes, "data-val-daterange-excluderangevalues", excludeRangeValue);
        }   

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return Attribute.ErrorMessage;
        }
    }
}
