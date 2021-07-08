using System;
using System.Collections.Generic;

#nullable disable

namespace SMSSurvey.Models
{
    public partial class SmsSurveyPerson
    {
        public string Id { get; set; }
        public int SmsSurveyId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string SmsResult { get; set; }
        public string Answer { get; set; }

        public virtual SmsSurvey SmsSurvey { get; set; }
    }
}
