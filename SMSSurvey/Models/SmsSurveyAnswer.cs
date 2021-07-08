using System;
using System.Collections.Generic;

#nullable disable

namespace SMSSurvey.Models
{
    public partial class SmsSurveyAnswer
    {
        public int Id { get; set; }
        public int SmsSurveyId { get; set; }
        public string Answer { get; set; }

        public virtual SmsSurvey SmsSurvey { get; set; }
    }
}
