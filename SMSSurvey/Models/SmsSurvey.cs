using System;
using System.Collections.Generic;

#nullable disable

namespace SMSSurvey.Models
{
    public partial class SmsSurvey
    {
        public SmsSurvey()
        {
            SmsSurveyAnswers = new HashSet<SmsSurveyAnswer>();
            SmsSurveyPeople = new HashSet<SmsSurveyPerson>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Question { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<SmsSurveyAnswer> SmsSurveyAnswers { get; set; }
        public virtual ICollection<SmsSurveyPerson> SmsSurveyPeople { get; set; }
    }
}
