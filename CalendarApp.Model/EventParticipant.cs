using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class EventParticipant
    {
        public int Id { get; set; }

        public int EventScheduleId { get; set; }
        public virtual EventSchedule EventSchedule { get; set; }

        public int ParticipantId { get; set; }

        public virtual AppUser Participant { get; set; }
    }
}
