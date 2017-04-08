using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyMVCBase1.Models
{
    public class Survey
    {
        public string SurveyID { get; set; }
        public string S1Q1Answer { get; set; }
        public DateTime S1Q2Answer { get; set; }
        public string S1Q3Answer { get; set; }
        public int S1Q3Score { get; set; }
        public string S1Q4Answer { get; set; }
        public string S1Q5Answer { get; set; }
        public string S1Q6Answer { get; set; }
        public int S1Q6Score { get; set; }
        public string S1Q7Answer { get; set; }
        public string S1Q8Answer { get; set; }

        //public virtual Gate Gate { get; set; }
    }
}