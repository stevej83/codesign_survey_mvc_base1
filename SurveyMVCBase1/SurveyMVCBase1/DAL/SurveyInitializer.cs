using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SurveyMVCBase1.Models;

namespace SurveyMVCBase1.DAL
{
    public class SurveyInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<SurveyContext>
    {
        protected override void Seed(SurveyContext context)
        {
            var surveys = new List<Survey>
            {
                new Survey{SurveyID="HJS82923SD921",S1Q1Answer="周杰伦",S1Q2Answer="1985-01-17",S1Q3Answer="China",
                    S1Q3Score=0,S1Q4Answer="清华大学",S1Q5Answer="生物化学工程专业",S1Q6Answer="China",S1Q6Score=0,
                    S1Q7Answer="北京大学",S1Q8Answer="生物化学工程专业",S1Q9Answer="北京市中英文化交流中心",S1Q10Answer="1to3",
                    S1Q10Score=0,S1Q11Answer="Y",S1Q11Score=0,S1Q12Answer="总经理",S1Q13Answer="halfto1",S1Q13Score=0,S1Q14Answer="+86 12312377897",
                    S1Q15Answer="test@gmail.com",S1Q16Answer="wx123test"}

                //,new Survey{SurveyID="HJS82923SD922",S1Q1Answer="成龙",S1Q2Answer=DateTime.Now,S1Q3Answer ="中国",S1Q3Score=0,S1Q4Answer="人民大学",S1Q5Answer="戏剧表演专业",S1Q6Answer="中国",S1Q6Score=0,S1Q7Answer="北京邮电大学",S1Q8Answer="戏剧表演专业"}

                // 更改S1Q2是因为Error信息显示不正确不统一， S1Q2Answer=DateTime.Now
            };

            surveys.ForEach(s => context.Surveys.Add(s));
            context.SaveChanges();
        }
    }
}