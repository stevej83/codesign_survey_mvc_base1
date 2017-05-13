﻿using System;
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
                new Survey{SurveyID="HJS82923SD921",StartTime=DateTime.Now.ToString("yyyyMMddHHmmss"),S1Q1Answer="测试员",S1Q2Answer="1985-01-17",S1Q3Answer="",
                    S1Q3Score=0,S1Q4Answer="",S1Q5Answer="",S1Q6Answer="",S1Q6Score=0,
                    S1Q7Answer="",S1Q8Answer="",S1Q9Answer="",S1Q10Answer="",S1Q10Score=0,S1Q11Answer="",S1Q11Score=0,S1Q12Answer="",S1Q13Answer="",S1Q13Score=0,S1Q14Answer="",
                    S1Q15Answer="",S1Q16Answer="",
                    S2Q1Answer="",S2Q1Score=0,S2Q2Answer="",S2Q2Score=0,S2Q3Answer="",S2Q3Score=0,S2Q4Answer="",S2Q4Score=0,S2Q5Answer="",S2Q5Score=0,S2Q6Answer="",S2Q6Score=0,
                    S2Q7Answer ="",S2Q7Score=0,S2Q8Answer="",S2Q8Score=0,S2Q9Answer="",S2Q9Score=0,S2Q10Answer="",S2Q10Score=0,
                    S3Q1Answer="",S3Q1Score=0,S3Q2Answer="",S3Q2Score=0,S3Q3Answer="",S3Q3Score=0,S3Q4Answer="",S3Q4Score=0,S3Q5Answer="",S3Q5Score=0,S3Q6Answer="",S3Q6Score=0,
                    S3Q7Answer="",S3Q7Score=0,S3Q8Answer="",S3Q8Score=0,S3Q9Answer="",S3Q9Score=0,S3Q10Answer="",S3Q10Score=0,
                    S4aQ1Answer="",S4aQ2Answer="",S4aQ3Answer="",S4aQ4Answer="",S4aQ5Answer="",S4aQ6Answer="",S4aQ7Answer="",S4aQ8Answer="",
                    S4aQ9Answer="",S4aQ10Answer="",S4aQ11Answer="",S4aQ12Answer="",S4aQ13Answer="",S4aQ14Answer="",S4aQ15Answer="",S4aQ16Answer="",
                    S4aQ17Answer="",S4aQ18Answer="",S4aQ19Answer="",S4aQ20Answer="",S4aQ21Answer="",S4aQ22Answer="",S4aQ23Answer="",S4aQ24Answer="",
                    S4aQ25Answer="",S4aQ26Answer="",S4aQ27Answer="",S4aQ28Answer="",S4aQ29Answer="",S4aQ30Answer="",S4aQ31Answer="",S4aQ32Answer="",
                    S4aQ33Answer="",S4aQ34Answer="",S4aQ35Answer="",S4aQ36Answer="",S4aQ37Answer="",S4aQ38Answer="",S4aQ39Answer="",S4aQ40Answer="",
                    S4aQ41Answer="",S4aQ42Answer="",S4aQ43Answer="",S4aQ44Answer="",S4aQ45Answer="",S4aQ46Answer="",S4aQ47Answer="",S4aQ48Answer="",
                    S4aQ49Answer="",S4aQ50Answer="",S4aQ51Answer="",S4aQ52Answer="",S4aQ53Answer="",S4aQ54Answer="",S4aQ55Answer="",S4aQ56Answer="",
                    S4aQ57Answer="",
                    S4bQ1Answer ="",S4bQ2Answer="",S4bQ3Answer="",S4bQ4Answer ="",S4bQ5Answer="",S4bQ6Answer="",S4bQ7Answer ="",S4bQ8Answer="",S4bQ9Answer="",
                    S4bQ10Answer ="",S4bQ11Answer="",S4bQ12Answer="",S4bQ13Answer ="",S4bQ14Answer="",S4bQ15Answer="",S4bQ16Answer ="",S4bQ17Answer="",S4bQ18Answer="",
                    S4bQ19Answer ="",S4bQ20Answer="",S4bQ21Answer="",S4bQ22Answer ="",S4bQ23Answer="",S4bQ24Answer="",S4bQ25Answer ="",S4bQ26Answer="",S4bQ27Answer="",
                    S4bQ28Answer ="",S4bQ29Answer="",S4bQ30Answer="",S4bQ31Answer ="",S4bQ32Answer="",S4bQ33Answer="",S4bQ34Answer ="",S4bQ35Answer="",S4bQ36Answer="",
                    S4bQ37Answer ="",S4bQ38Answer="",S4bQ39Answer="",S4bQ40Answer ="",S4bQ41Answer="",S4bQ42Answer="",S4bQ43Answer ="",S4bQ44Answer="",S4bQ45Answer="",
                    S4bQ46Answer ="",S4bQ47Answer="",S4bQ48Answer="",S4bQ49Answer ="",S4bQ50Answer="",S4bQ51Answer="",S4bQ52Answer ="",S4bQ53Answer="",S4bQ54Answer="",
                    S4bQ55Answer ="",S4bQ56Answer="",S4bQ57Answer="",S4bQ58Answer ="",S4bQ59Answer="",S4bQ60Answer="",S4bQ61Answer =""}
            };

            surveys.ForEach(s => context.Surveys.Add(s));
            context.SaveChanges();
        }
    }
}