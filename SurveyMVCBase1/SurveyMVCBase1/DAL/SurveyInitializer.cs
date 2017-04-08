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
                new Survey{SurveyID="HJS82923SD921",S1Q1Answer="周杰伦",S1Q2Answer=DateTime.Now,S1Q3Answer ="中国",S1Q3Score=0,S1Q4Answer="清华大学",S1Q5Answer="生物化学工程专业",S1Q6Answer="中国",S1Q6Score=0,S1Q7Answer="北京大学",S1Q8Answer="生物化学工程专业"},
                new Survey{SurveyID="HJS82923SD922",S1Q1Answer="成龙",S1Q2Answer=DateTime.Now,S1Q3Answer ="中国",S1Q3Score=0,S1Q4Answer="人民大学",S1Q5Answer="戏剧表演专业",S1Q6Answer="中国",S1Q6Score=0,S1Q7Answer="北京邮电大学",S1Q8Answer="戏剧表演专业"}
            };

            surveys.ForEach(s => context.Surveys.Add(s));
            context.SaveChanges();

            var gates = new List<Gate>
            {
                new Gate{GateID="GATE1234567",SurveyID="HJS82923SD921",Section1Page1=false,Section1Page2=false},
                new Gate{GateID="GATE7654321",SurveyID="HJS82923SD922",Section1Page1=false,Section1Page2=false}
            };

            gates.ForEach(g => context.Gates.Add(g));
            context.SaveChanges();
        }
    }
}