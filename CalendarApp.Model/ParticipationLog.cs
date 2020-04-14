using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class ParticipationLog
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }

        public int ParticipationId { get; set; }
        public virtual Participation Participation { get; set; }
        public ParticipationLogStatus Status { get; set; }
    }

    public enum ParticipationLogStatus
    {
        started,
        inprogress,
        paused,
        finished,
        suspended,
        terminated

    }
}
