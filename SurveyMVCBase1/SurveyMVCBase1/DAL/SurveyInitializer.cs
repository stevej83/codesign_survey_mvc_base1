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
                new Survey{SurveyID="HJS82923SD921",S1Q1Answer="Seed1 Answer 1 blaab bla bla",S1Q1Score=10,S1Q2Answer="Seed1 Answer 2 Blah blah blaaaah",S1Q2Score=0},
                new Survey{SurveyID="HJS82923SD922",S1Q1Answer="Seed2 Answer 1 blaab bla bla",S1Q1Score=10,S1Q2Answer="Seed2 Answer 2 Blah blah blaaaah",S1Q2Score=0}
            };

            surveys.ForEach(s => context.Surveys.Add(s));
            context.SaveChanges();

            var gates = new List<Gate>
            {
                new Gate{GateID="GATE1234567",SurveyID="HJS82923SD921",LandingPage1=true,LandingPage2=false,Section1Page1=false,Section1Page2=false},
                new Gate{GateID="GATE7654321",SurveyID="HJS82923SD922",LandingPage1=true,LandingPage2=false,Section1Page1=false,Section1Page2=false}
            };

            gates.ForEach(g => context.Gates.Add(g));
            context.SaveChanges();
        }
    }
}