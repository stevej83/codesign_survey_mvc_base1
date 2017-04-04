using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyMVCBase1.Models
{
    public class Gate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string GateID { get; set; }
        public string SurveyID { get; set; }
        public bool LandingPage1 { get; set; }
        public bool LandingPage2 { get; set; }
        public bool Section1Page1 { get; set; }
        public bool Section1Page2 { get; set; }

        //public virtual ICollection<Survey> Surveys { get; set; }
        public virtual Survey Survey { get; set; }
    }
}