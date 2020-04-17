using CalendarApp.Model;
using CalendarApp.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web.Models
{

    public enum AmPM
    {
        AM,
        PM

    }

    public class AppEventViewModel
    {
        private const string VAL_EVENT_NAME_IS_REQUIRED = "Please enter the Name.";

        public int Id { get; set; }

        [Required(ErrorMessage = VAL_EVENT_NAME_IS_REQUIRED)]
        public string Name { get; set; }

        public EventType EventType { get; set; }


        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateRange(ErrorMessage = "Date is not in range")]
        public DateTime EventDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }

        

        [Required]
        [Range(1,int.MaxValue)]
        public int NoOfParticipantsAllowed { get; set; }

        public bool AutoStartEndEvent { get; set; }

        public bool AllowParticipantsRegistration { get; set; }
    }
}
