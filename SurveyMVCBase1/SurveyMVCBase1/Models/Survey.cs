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
        public int S1Q1Score { get; set; }
        public string S1Q2Answer { get; set; }
        public int S1Q2Score { get; set; }

        //public virtual Gate Gate { get; set; }
    }
}