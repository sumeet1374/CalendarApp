using System;

namespace CalendarApp.Model
{
    public class EventSchedule
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EventType EventType { get; set; }

        public string Description { get; set; }

        public virtual AppUser Organizer { get; set; }

        public DateTime StartDateTime { get; set; }


        public DateTime EndDateTime { get; set; }


        public int NoOfParticipantsAllowed { get; set; }

        public bool AutoStartEndEvent { get; set; }

        public bool Active { get; set; }

        public string AllowedParticipationLogs { get; set; }
    }
}
