using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyMVCBase1.Models
{
    public class Survey
    {
        public string SurveyID { get; set; }
        [Display(Name = "1. 姓名:")]
        public string S1Q1Answer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "2. 生日:")]
        [StringLength(200, ErrorMessage = "您还没有dian生日")]
        public DateTime S1Q2Answer { get; set; }
        [Display(Name = "3. 本科就读国:")]
        public string S1Q3Answer { get; set; }
        public int S1Q3Score { get; set; }
        [Display(Name = "4. 本科院校:")]
        public string S1Q4Answer { get; set; }
        [Display(Name = "5. 本科专业:")]
        public string S1Q5Answer { get; set; }
        [Display(Name = "6. 硕士所在国:")]
        public string S1Q6Answer { get; set; }
        public int S1Q6Score { get; set; }
        [Display(Name = "7. 硕士院校名称:")]
        public string S1Q7Answer { get; set; }
        [Display(Name = "8. 硕士专业:")]
        public string S1Q8Answer { get; set; }

        //public virtual Gate Gate { get; set; }
    }
}