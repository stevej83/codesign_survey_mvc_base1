using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace SurveyMVCBase1.Models
{
    public class Survey
    {
        [Key]
        public string SurveyID { get; set; }

        [Display(Name = "1. 姓名:")]
        public string S1Q1Answer { get; set; }

        [Display(Name = "2. 生日:")]
        public string S1Q2Answer { get; set; }

        [Display(Name = "3. 本科就读国:")]
        public string S1Q3Answer { get; set; }

        // 得分：S1Q3 0/10
        public int S1Q3Score { get; set; }

        //[Required(ErrorMessage = "请填写您的本科院校名称")]
        [Display(Name = "4. 本科院校:")]
        public string S1Q4Answer { get; set; }

        //[Required(ErrorMessage = "请填写您的本科专业")]
        [Display(Name = "5. 本科专业:")]
        public string S1Q5Answer { get; set; }

        //[Required(ErrorMessage = "请选择您的硕士院校所在国家")]
        [Display(Name = "6. 硕士所在国:")]
        public string S1Q6Answer { get; set; }

        // 得分：S1Q6 0/10
        public int S1Q6Score { get; set; }

        //[Required(ErrorMessage = "请填写您的硕士院校名称")]
        [Display(Name = "7. 硕士院校名称:")]
        public string S1Q7Answer { get; set; }

        //[Required(ErrorMessage = "请填写您的本科专业")]
        [Display(Name = "8. 硕士专业:")]
        public string S1Q8Answer { get; set; }

        [Display(Name = "9. 最近一个工作单位:")]
        public string S1Q9Answer { get; set; }

        [Display(Name = "10. 工作时间总长度:")]
        public string S1Q10Answer { get; set; }

        // 得分：S1Q10 0/5/10
        public int S1Q10Score { get; set; }

        [Display(Name = "11. 工作单位是否与英国相关:")]
        public string S1Q11Answer { get; set; }

        // 得分：S1Q11 0/10
        public int S1Q11Score { get; set; }

        [Display(Name = "12. 工作职位:")]
        public string S1Q12Answer { get; set; }

        [Display(Name = "13. 在英国停留累计时间:")]
        public string S1Q13Answer { get; set; }

        // 得分：S1Q13 0/10/20/30
        public int S1Q13Score { get; set; }

        [Display(Name = "14. 电话:")]
        public string S1Q14Answer { get; set; }

        [Display(Name = "15. 邮箱:")]
        public string S1Q15Answer { get; set; }

        [Display(Name = "16. 微信:")]
        public string S1Q16Answer { get; set; }

    }
}