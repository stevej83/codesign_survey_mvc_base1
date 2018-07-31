using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace SurveyMVCBase1.Models
{
    /* 以下变量如做更改需要事先备份数据库数据，不然数据会全部丢失 ！ */
    public class Survey
    {
        [Key]
        public string SurveyID { get; set; }

        public string StartTime { get; set; }

        [Display(Name = "姓名")]
        public string S1Q1Answer { get; set; }

        [Display(Name = "出生年份")]
        public string S1Q2Answer { get; set; }

        [Display(Name = "取得本科学位的国家")]
        public string S1Q3Answer { get; set; }

        // 得分：S1Q3 0/10
        public int S1Q3Score { get; set; }

        [Display(Name = "本科院校")]
        public string S1Q4Answer { get; set; }

        [Display(Name = "本科专业")]
        public string S1Q5Answer { get; set; }

        [Display(Name = "取得硕士学位的国家")]
        public string S1Q6Answer { get; set; }

        // 得分：S1Q6 0/10
        public int S1Q6Score { get; set; }

        [Display(Name = "硕士院校名称")]
        public string S1Q7Answer { get; set; }

        [Display(Name = "硕士专业")]
        public string S1Q8Answer { get; set; }

        [Display(Name = "取得博士学位的国家")]
        public string S1Q9Answer { get; set; }

        // 得分：S1Q6 0/10
        public int S1Q9Score { get; set; }

        [Display(Name = "博士院校名称")]
        public string S1Q10Answer { get; set; }

        [Display(Name = "博士专业")]
        public string S1Q11Answer { get; set; }

        [Display(Name = "现/最近工作单位")]
        public string S1Q12Answer { get; set; }

        [Display(Name = "工作经验")]
        public string S1Q13Answer { get; set; }

        // 得分：S1Q10 0/5/10
        public int S1Q13Score { get; set; }

        [Display(Name = "工作是否与英国相关")]
        public string S1Q14Answer { get; set; }

        // 得分：S1Q11 0/10
        public int S1Q14Score { get; set; }

        [Display(Name = "工作职位")]
        public string S1Q15Answer { get; set; }

        [Display(Name = "在英国停留累计时间")]
        public string S1Q16Answer { get; set; }

        // 得分：S1Q13 0/10/20/30
        public int S1Q16Score { get; set; }

        [Display(Name = "电话")]
        public string S1Q17Answer { get; set; }

        [Display(Name = "邮箱")]
        public string S1Q18Answer { get; set; }

        [Display(Name = "微信号")]
        public string S1Q19Answer { get; set; }

        [Display(Name = "申请人取得英国企业家签证的主要目的是？")]
        public string S2Q1Answer { get; set; }

        // 得分：S2Q1 0/10
        public int S2Q1Score { get; set; }

        [Display(Name = "企业家签证对申请人的英语水平有要求，以下哪一项是移民局认可的？")]
        public string S2Q2Answer { get; set; }

        // 得分：S2Q2 0/10
        public int S2Q2Score { get; set; }

        [Display(Name = "申请企业家签证（不包括毕业生企业家和基金风投等资助类），申请人需准备的投资金额需不少于多少英镑？")]
        public string S2Q3Answer { get; set; }

        // 得分：S2Q3 0/10
        public int S2Q3Score { get; set; }

        [Display(Name = "在英国境外出具的资金证明信最主要的要求是什么？")]
        public string S2Q4Answer { get; set; }

        // 得分：S2Q4 0/10
        public int S2Q4Score { get; set; }

        [Display(Name = "在英国境外提交的企业家签证申请，主申请人需提供的生活费存款连续90天不少于多少英镑？")]
        public string S2Q5Answer { get; set; }

        // 得分：S2Q5 0/10
        public int S2Q5Score { get; set; }

        [Display(Name = "持有企业家签证的主申请人是否可以为他人工作？")]
        public string S2Q6Answer { get; set; }

        // 得分：S2Q6 0/10
        public int S2Q6Score { get; set; }

        [Display(Name = "企业家签证主申请人的家属（配偶，未成年子女）是否可以申请家属类签证？")]
        public string S2Q7Answer { get; set; }

        // 得分：S2Q7 0/10
        public int S2Q7Score { get; set; }

        [Display(Name = "申请人是否可以加入一家现有的英国企业？")]
        public string S2Q8Answer { get; set; }

        // 得分：S2Q8 0/10
        public int S2Q8Score { get; set; }

        [Display(Name = "申请企业家签证的成年人是否需要提供无犯罪记录证明？")]
        public string S2Q9Answer { get; set; }

        // 得分：S2Q10 0/10
        public int S2Q9Score { get; set; }

        [Display(Name = "请问在2017年，约有多少在中国的企业家签证申请得到批准？")]
        public string S2Q10Answer { get; set; }

        // 得分：S2Q10 0/10
        public int S2Q10Score { get; set; }

        [Display(Name = "英国的 VAT 税率是多少？")]
        public string S3Q1Answer { get; set; }

        // 得分：S3Q1 0/10
        public int S3Q1Score { get; set; }

        [Display(Name = "在英国开公司需要买保险吗？")]
        public string S3Q2Answer { get; set; }

        // 得分：S3Q2 0/10
        public int S3Q2Score { get; set; }

        [Display(Name = "在英国，雇主支付给一位30岁员工的每小时工资，下面哪一个数据是符合目前法律要求的？")]
        public string S3Q3Answer { get; set; }

        // 得分：S3Q3 0/10
        public int S3Q3Score { get; set; }

        [Display(Name = "聘请一位有3年工作经验的项目开发经理需要支付的年薪是多少英镑？")]
        public string S3Q4Answer { get; set; }

        // 得分：S3Q4 0/10
        public int S3Q4Score { get; set; }

        [Display(Name = "在伦敦市 zone2 范围内可供4人用的办公室一个月的租金是多少英镑？")]
        public string S3Q5Answer { get; set; }

        // 得分：S3Q5 0/10
        public int S3Q5Score { get; set; }

        [Display(Name = "一名英国公司员工在2016/2017财年的税前工资收入为24,000英镑，在扣除个人免税额后的应纳税工资部分，需缴纳的个人所得税适用税率是多少？")]
        public string S3Q6Answer { get; set; }

        // 得分：S3Q6 0/10
        public int S3Q6Score { get; set; }

        [Display(Name = "申请人是否咨询过移民律师或类似的企业家签证持有人？")]
        public string S3Q7Answer { get; set; }

        // 得分：S3Q7 0/10
        public int S3Q7Score { get; set; }

        [Display(Name = "英国的普通微型企业聘请会计的服务费约多少英镑？")]
        public string S3Q8Answer { get; set; }

        // 得分：S3Q8 0/10
        public int S3Q8Score { get; set; }

        [Display(Name = "一家英国电商公司有5个雇员，该公司购买雇主责任险的保险费是多少英镑？")]
        public string S3Q9Answer { get; set; }

        // 得分：S3Q9 0/10
        public int S3Q9Score { get; set; }

        [Display(Name = "申请人是否理解在英国董事和股东之间的区别？")]
        public string S3Q10Answer { get; set; }

        // 得分：S3Q10 0/10
        public int S3Q10Score { get; set; }

        // 英国创业项目测试 - 独立创业
        [DataType(DataType.MultilineText)]
        [Display(Name = "1. 提交什么签证？")]
        public string S4aQ1Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "2. 为什么提交这个签证？")]
        public string S4aQ2Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "3. 为什么在英国创业？是否考虑过其他国家市场？")]
        public string S4aQ3Answer { get; set; }

        [Display(Name = "4. 是否在英国已经注册了公司？")]
        public string S4aQ4Answer { get; set; }

        [Display(Name = "5. 经营场所的邮政编码是什么？")]
        public string S4aQ5Answer { get; set; }

        [Display(Name = "6. 经营场所租金一年多少钱？")]
        public string S4aQ6Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "7. 商业模式是什么？(最多三句话，限制字数50字以内)")]
        public string S4aQ7Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "8. 商业短期，中期，长期的发展规划，目标是什么？")]
        public string S4aQ8Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "9. 有没有做过市场调查？调查方式是什么？")]
        public string S4aQ9Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "10. 市场调查的结果是什么？")]
        public string S4aQ10Answer { get; set; }

        [Display(Name = "11. 是否打算雇佣员工？")]
        public string S4aQ11Answer { get; set; }

        [Display(Name = "12. 什么时候雇佣员工？")]
        public string S4aQ12Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "13. 雇佣的员工职位是什么？")]
        public string S4aQ13Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "14. 聘请的标准是什么？")]
        public string S4aQ14Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "15. 招聘方法是什么？从哪里招聘？")]
        public string S4aQ15Answer { get; set; }

        [Display(Name = "16. 招聘成本是多少钱？")]
        public string S4aQ16Answer { get; set; }

        [Display(Name = "17. 雇佣员工的工资是多少？")]
        public string S4aQ17Answer { get; set; }

        [Display(Name = "18. 有无潜在客户？")]
        public string S4aQ18Answer { get; set; }

        [Display(Name = "19. 有无已开始或进行中的项目？")]
        public string S4aQ19Answer { get; set; }

        [Display(Name = "20. 第一年盈利预计是多少？")]
        public string S4aQ20Answer { get; set; }

        [Display(Name = "21. 第一年预计成本是多少？")]
        public string S4aQ21Answer { get; set; }

        [Display(Name = "22. 第一年营销成本是多少？")]
        public string S4aQ22Answer { get; set; }

        [Display(Name = "23. 第一年客户数是多少？")]
        public string S4aQ23Answer { get; set; }

        [Display(Name = "24. 第二年盈利预计是多少？")]
        public string S4aQ24Answer { get; set; }

        [Display(Name = "25. 第二年预计成本是多少？")]
        public string S4aQ25Answer { get; set; }

        [Display(Name = "26. 第二年营销成本是多少？")]
        public string S4aQ26Answer { get; set; }

        [Display(Name = "27. 第二年客户数是多少？")]
        public string S4aQ27Answer { get; set; }

        [Display(Name = "28. 第三年盈利预计是多少？")]
        public string S4aQ28Answer { get; set; }

        [Display(Name = "29. 第三年预计成本是多少？")]
        public string S4aQ29Answer { get; set; }

        [Display(Name = "30. 第三年营销成本是多少？")]
        public string S4aQ30Answer { get; set; }

        [Display(Name = "31. 第三年客户数是多少？")]
        public string S4aQ31Answer { get; set; }

        [Display(Name = "32. 如果是贸易类，平均毛利率是多少？")]
        public string S4aQ32Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "33. 税前利润是多少？税后利润是多少？ （3年数据）")]
        public string S4aQ33Answer { get; set; }

        [Display(Name = "34. 竞争对手有多少？")]
        public string S4aQ34Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "35. 竞争对手的核心优势是什么？")]
        public string S4aQ35Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "36. 申请人的商业核心竞争优势是什么？")]
        public string S4aQ36Answer { get; set; }

        [Display(Name = "37. 申请人有没有合伙人？")]
        public string S4aQ37Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "38. 合伙人背景是什么？有没有商业经验？")]
        public string S4aQ38Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "39. 打算投资多少钱？ 投资计划花在那些方面？")]
        public string S4aQ39Answer { get; set; }

        [Display(Name = "40. 投资资金是否已经以现金存款的形式存在申请人的名下？")]
        public string S4aQ40Answer { get; set; }

        [Display(Name = "41. 什么时候公司总体盈利？")]
        public string S4aQ41Answer { get; set; }

        [Display(Name = "42. 申请人是否给公司购买了商业保险？")]
        public string S4aQ42Answer { get; set; }

        [Display(Name = "43. 申请人购买了什么类型的商业保险？")]
        public string S4aQ43Answer { get; set; }

        [Display(Name = "44. 商业保险一年多少钱？")]
        public string S4aQ44Answer { get; set; }

        [Display(Name = "45. 公司是否注册了VAT？")]
        public string S4aQ45Answer { get; set; }

        [Display(Name = "46. VAT 的FULL NAME是什么？")]
        public string S4aQ46Answer { get; set; }

        [Display(Name = "47. VAT税率是多少？")]
        public string S4aQ47Answer { get; set; }

        [Display(Name = "48. 营业税的税率是多少？")]
        public string S4aQ48Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "49. 会计公司的名字，联系人的名字？")]
        public string S4aQ49Answer { get; set; }

        [Display(Name = "50. 会计服务一年多少钱？")]
        public string S4aQ50Answer { get; set; }

        [Display(Name = "51. 申请人的最高学历是什么？")]
        public string S4aQ51Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "52. 所学专业是否和创业思路相关联或者有帮助？简单阐述，如果有")]
        public string S4aQ52Answer { get; set; }

        [Display(Name = "53. 上一次进入英国是什么时候？")]
        public string S4aQ53Answer { get; set; }

        [Display(Name = "54. 是否在在英国有过工作经验？")]
        public string S4aQ54Answer { get; set; }

        [Display(Name = "55. 最近三年是否常驻英国或来过英国多少次？")]
        public string S4aQ55Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "56. 资金来源是什么？")]
        public string S4aQ56Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "57. 如果是赠与，赠与人的工作单位是什么？年薪多少？")]
        public string S4aQ57Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "58. 如果商业失败怎么办？")]
        public string S4aQ58Answer { get; set; }

        [Display(Name = "59. 申请人打算居住在哪里？")]
        public string S4aQ59Answer { get; set; }

        [Display(Name = "60. 一年的生活成本是多少？")]
        public string S4aQ60Answer { get; set; }

        [Display(Name = "61. 有没有家属同行？")]
        public string S4aQ61Answer { get; set; }

        [Display(Name = "62. 配偶是否打算来英国工作？")]
        public string S4aQ62Answer { get; set; }

        [Display(Name = "63. 未满18岁子女是否来英国上学？")]
        public string S4aQ63Answer { get; set; }

        [Display(Name = "1. 本测试涉及的英国签证类型是什么？")]
        public string S4bQ1Answer { get; set; }

        [Display(Name = "2. 提交的什么签证？")]
        public string S4bQ2Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "3. 为什么提交这个签证？")]
        public string S4bQ3Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "4. 为什么在英国创业？是否考虑过其他国家市场？")]
        public string S4bQ4Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "5. 现有企业的商业模式是什么？（最多三句话，限制字数50字以内）")]
        public string S4bQ5Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "6. 商业短期，中期，长期的发展规划，目标是什么？")]
        public string S4bQ6Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "7. 有没有做过市场调查？调查方式是什么？")]
        public string S4bQ7Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "8. 市场调查的结果是什么？")]
        public string S4bQ8Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "9. 为什么要加入一个企业创业？")]
        public string S4bQ9Answer { get; set; }

        [Display(Name = "10. 加入的企业叫什么名字？")]
        public string S4bQ10Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "11. 如何找到的加入企业？")]
        public string S4bQ11Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "12. 加入企业现有股东几个？董事几个？持股比例分别是多少？")]
        public string S4bQ12Answer { get; set; }

        [Display(Name = "13. 经营场所的邮政编码是什么？")]
        public string S4bQ13Answer { get; set; }

        [Display(Name = "14. 经营场所租金一年多少钱？")]
        public string S4bQ14Answer { get; set; }

        [Display(Name = "15. 是否去过要加入的企业？")]
        public string S4bQ15Answer { get; set; }

        [Display(Name = "16. 招聘成本是多少钱？")]
        public string S4bQ16Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "17. 加入的企业负责人的基本背景是什么？")]
        public string S4bQ17Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "18. 是否见过负责人，上一次见是什么时候？交谈内容主要是什么？")]
        public string S4bQ18Answer { get; set; }

        [Display(Name = "19. 企业目前现有员工多少人？")]
        public string S4bQ19Answer { get; set; }

        [Display(Name = "20. 企业成立年份？")]
        public string S4bQ20Answer { get; set; }

        [Display(Name = "21. 企业过去两年的营业额及利润率是多少？")]
        public string S4bQ21Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "22. 如果亏损，为什么要投资一个现在亏损的企业？")]
        public string S4bQ22Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "23. 如果盈利，企业为什么吸收申请人的20万英镑投资？")]
        public string S4bQ23Answer { get; set; }

        [Display(Name = "24. 投资20万英镑，申请人占有的股份比例是多少？")]
        public string S4bQ24Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "25. 如果是董事借款，借款的条款是什么？")]
        public string S4bQ25Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "26. 如果是股份比例，为什么占有这个比例？")]
        public string S4bQ26Answer { get; set; }

        [Display(Name = "27. 企业的估值方法是什么？")]
        public string S4bQ27Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "28. 申请人加入企业后，主要负责什么，主要职位是什么？")]
        public string S4bQ28Answer { get; set; }

        [Display(Name = "29. 加入企业后，申请人是否有工资？如果有，多少钱？")]
        public string S4bQ29Answer { get; set; }

        [Display(Name = "30. 是否打算新增雇佣员工？")]
        public string S4bQ30Answer { get; set; }

        [Display(Name = "31. 什么时候计划雇佣新员工？")]
        public string S4bQ31Answer { get; set; }

        [Display(Name = "32. 雇佣的员工职位是什么？")]
        public string S4bQ32Answer { get; set; }

        [Display(Name = "33. 招聘的标准是什么？")]
        public string S4bQ33Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "34. 招聘方法是什么？从哪里招聘？")]
        public string S4bQ34Answer { get; set; }

        [Display(Name = "35. 招聘成本是多少钱？")]
        public string S4bQ35Answer { get; set; }

        [Display(Name = "36. 雇佣员工的工资是多少？")]
        public string S4bQ36Answer { get; set; }

        [Display(Name = "37. 如果是贸易类，平均毛利率是多少？")]
        public string S4bQ37Answer { get; set; }

        [Display(Name = "38. 税前利润是多少？税后利润是多少？ （3年数据）")]
        public string S4bQ38Answer { get; set; }

        [Display(Name = "39. 竞争对手有多少？")]
        public string S4bQ39Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "40. 竞争对手的核心优势是什么？")]
        public string S4bQ40Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "41. 你的商业核心竞争优势是什么？")]
        public string S4bQ41Answer { get; set; }

        [Display(Name = "42. 企业是否购买了保险？")]
        public string S4bQ42Answer { get; set; }

        [Display(Name = "43. 企业购买了什么类型的保险？")]
        public string S4bQ43Answer { get; set; }

        [Display(Name = "44. 保险一年多少钱？")]
        public string S4bQ44Answer { get; set; }

        [Display(Name = "45. 公司是否注册了 VAT？")]
        public string S4bQ45Answer { get; set; }

        [Display(Name = "46. VAT 的 FULL NAME 是什么？")]
        public string S4bQ46Answer { get; set; }

        [Display(Name = "47. VAT 税率是多少？")]
        public string S4bQ47Answer { get; set; }

        [Display(Name = "48. 营业税的税率是多少？")]
        public string S4bQ48Answer { get; set; }

        [Display(Name = "49. 会计公司的名字，联系人的名字？")]
        public string S4bQ49Answer { get; set; }

        [Display(Name = "50. 会计服务一年多少钱？")]
        public string S4bQ50Answer { get; set; }

        [Display(Name = "51. 申请人的最高学历是什么？")]
        public string S4bQ51Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "52. 所学专业是否和创业思路相关联或者有帮助？ 简单阐述，如果有")]
        public string S4bQ52Answer { get; set; }

        [Display(Name = "53. 上一次进入英国是什么时候？")]
        public string S4bQ53Answer { get; set; }

        [Display(Name = "54. 是否在英国有过工作经验？")]
        public string S4bQ54Answer { get; set; }

        [Display(Name = "55. 是否此工作经验与申请加入企业相关？")]
        public string S4bQ55Answer { get; set; }

        [Display(Name = "56. 资金来源是什么？")]
        public string S4bQ56Answer { get; set; }

        [Display(Name = "57. 如果是父母赠与，父母的工作单位是什么，年薪多少？")]
        public string S4bQ57Answer { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "58. 如果商业失败怎么办？")]
        public string S4bQ58Answer { get; set; }

        [Display(Name = "59. 申请人打算居住在哪里？")]
        public string S4bQ59Answer { get; set; }

        [Display(Name = "60. 一年的生活成本是多少？")]
        public string S4bQ60Answer { get; set; }

        [Display(Name = "61. 有没有家属同行？")]
        public string S4bQ61Answer { get; set; }

        [Display(Name = "62. 配偶是否打算来英国工作？")]
        public string S4bQ62Answer { get; set; }

        [Display(Name = "63. 未满18岁子女是否来英国上学？")]
        public string S4bQ63Answer { get; set; }
    }
}