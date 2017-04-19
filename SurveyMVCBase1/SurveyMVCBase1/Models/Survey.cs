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

        [Display(Name = "4. 本科院校:")]
        public string S1Q4Answer { get; set; }

        [Display(Name = "5. 本科专业:")]
        public string S1Q5Answer { get; set; }

        [Display(Name = "6. 硕士所在国:")]
        public string S1Q6Answer { get; set; }

        // 得分：S1Q6 0/10
        public int S1Q6Score { get; set; }

        [Display(Name = "7. 硕士院校名称:")]
        public string S1Q7Answer { get; set; }

        [Display(Name = "8. 硕士专业:")]
        public string S1Q8Answer { get; set; }

        [Display(Name = "9. 现/最近工作单位:")]
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

        [Display(Name = "1. 您申请企业家移民的主要目的是？")]
        public string S2Q1Answer { get; set; }

        // 得分：S2Q1 0/10
        public int S2Q1Score { get; set; }

        [Display(Name = "2. 我可以与其它人以合伙人的方式申请签证吗？")]
        public string S2Q2Answer { get; set; }

        // 得分：S2Q2 0/10
        public int S2Q2Score { get; set; }

        [Display(Name = "3. 您的英文水平？")]
        public string S2Q3Answer { get; set; }

        // 得分：S2Q3 0/10
        public int S2Q3Score { get; set; }

        [Display(Name = "4. 企业家移民要求的最低投资金额是多少？(以英镑位单位)")]
        public string S2Q4Answer { get; set; }

        // 得分：S2Q4 0/10
        public int S2Q4Score { get; set; }

        [Display(Name = "5. 企业家移民签证的限制是？")]
        public string S2Q5Answer { get; set; }

        // 得分：S2Q5 0/10
        public int S2Q5Score { get; set; }

        [Display(Name = "6. 我可以带家人来英国吗？")]
        public string S2Q6Answer { get; set; }

        // 得分：S2Q6 0/10
        public int S2Q6Score { get; set; }

        [Display(Name = "7. 您知道2016年有多少来自中国的企业家移民申请被接受吗？")]
        public string S2Q7Answer { get; set; }

        // 得分：S2Q7 0/10
        public int S2Q7Score { get; set; }

        [Display(Name = "8. 我可以加入一家现有的企业吗？")]
        public string S2Q8Answer { get; set; }

        // 得分：S2Q8 0/10
        public int S2Q8Score { get; set; }

        [Display(Name = "9. 3年内需要雇佣多少员工才能符合续签的要求？")]
        public string S2Q9Answer { get; set; }

        // 得分：S2Q10 0/10
        public int S2Q9Score { get; set; }

        [Display(Name = "9. 资金证明的主要要求是什么？")]
        public string S2Q10Answer { get; set; }

        // 得分：S2Q10 0/10
        public int S2Q10Score { get; set; }

        [Display(Name = "1. 英国的 VAT 税率是多少？")]
        public string S3Q1Answer { get; set; }

        // 得分：S3Q1 0/10
        public int S3Q1Score { get; set; }

        [Display(Name = "2. 在英国开公司需要买保险吗？")]
        public string S3Q2Answer { get; set; }

        // 得分：S3Q2 0/10
        public int S3Q2Score { get; set; }

        [Display(Name = "3. 对于一个28岁的员工来说，他的最低薪水是每小时多少钱？")]
        public string S3Q3Answer { get; set; }

        // 得分：S3Q3 0/10
        public int S3Q3Score { get; set; }

        [Display(Name = "4. 聘请一位有3年工作经验的项目开发经理需要支付多少薪水？")]
        public string S3Q4Answer { get; set; }

        // 得分：S3Q4 0/10
        public int S3Q4Score { get; set; }

        [Display(Name = "5. 在伦敦市中心 zone1 范围内可供4人用的办公室一个月的租金是多少钱？")]
        public string S3Q5Answer { get; set; }

        // 得分：S3Q5 0/10
        public int S3Q5Score { get; set; }

        [Display(Name = "6. 员工年收入两万四千英镑需要缴纳的所得税占工资的比例是多少？")]
        public string S3Q6Answer { get; set; }

        // 得分：S3Q6 0/10
        public int S3Q6Score { get; set; }

        [Display(Name = "7. 您是否有独立的金融咨询代表或机构的协助？")]
        public string S3Q7Answer { get; set; }

        // 得分：S3Q7 0/10
        public int S3Q7Score { get; set; }

        [Display(Name = "8. 聘请使用会计服务的普遍价位是多少？")]
        public string S3Q8Answer { get; set; }

        // 得分：S3Q8 0/10
        public int S3Q8Score { get; set; }

        [Display(Name = "9. 每年作为中小企业雇主自由保险费用多少？")]
        public string S3Q9Answer { get; set; }

        // 得分：S3Q9 0/10
        public int S3Q9Score { get; set; }

        [Display(Name = "10. 你理解董事和股东之间的区别吗？")]
        public string S3Q10Answer { get; set; }

        // 得分：S3Q10 0/10
        public int S3Q10Score { get; set; }

    }
}