using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class ValidationException:Exception
    {
        public ValidationException(string message):base(message)
        {

        }
        public List<string> Messages { get; set; }
    }
}
