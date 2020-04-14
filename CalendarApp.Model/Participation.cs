using System;
using System.Collections.Generic;

namespace CalendarApp.Model
{
    public class Participation
    {
        public int Id { get; set; }

        public int EventScheduleExecutionId { get; set; }
        public virtual EventScheduleExecution EventScheduleExecution { get; set; }

        public int ParticipantId { get; set; }
        public virtual AppUser Participant { get; set; }

        public DateTime StartTime { get; set; }

        public bool Started { get; set; }

        public DateTime FinishTime { get; set; }

        public bool Finished { get; set; }

        public string Feedback { get; set; }

        public int Rating { get; set; }

        public virtual List<ParticipationLog> ParticipationLogs { get; set; }
    }
}
