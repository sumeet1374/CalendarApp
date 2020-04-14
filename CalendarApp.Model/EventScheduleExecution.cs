using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class EventScheduleExecution
    {
        public int Id { get; set; }

        public int EventScheduleId { get; set; }
        public virtual EventSchedule Schedule { get; set; }

        public bool Started { get; set; }

        public DateTime StartDateTime { get; set; }

        public bool Finished { get; set; }

        public DateTime FinishDateTime { get; set; }

        public virtual List<Participation> Participations { get; set; }

    }
}
