using SurveyMVCBase1.DAL;
using SurveyMVCBase1.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SurveyMVCBase1.Controllers
{
    public class SurveysController : Controller
    {
        private DataContext db = new DataContext();

        public int Section1TotalScore = 0;
        public int Section2TotalScore = 0;
        public int Section3TotalScore = 0;

        // GET: Surveys
        public ActionResult Index()
        {
            return View();
        }

        // direct to page - Workflow
        public ActionResult Workflow()
        {
            //Survey survyCreate = new Survey();
            //survyCreate.SurveyID = Guid.NewGuid().ToString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Workflow([Bind(
            Include = "SurveyID,StartTime,S1Q1Answer,S1Q2Answer,S1Q3Answer,S1Q3Score,S1Q4Answer,S1Q5Answer,S1Q6Answer,S1Q6Score,S1Q7Answer,S1Q8Answer," +
            "S1Q9Answer,S1Q10Answer,S1Q10Score,S1Q11Answer,S1Q11Score,S1Q12Answer,S1Q13Answer,S1Q13Score,S1Q14Answer,S1Q15Answer,S1Q16Answer," +
            "S2Q1Answer,S2Q1Score,S2Q2Answer,S2Q2Score,S2Q3Answer,S2Q3Score,S2Q4Answer,S2Q4Score,S2Q5Answer,S2Q5Score,S2Q6Answer,S2Q6Score," +
            "S2Q7Answer,S2Q7Score,S2Q8Answer,S2Q8Score,S2Q9Answer,S2Q9Score,S2Q10Answer,S2Q10Score," +
            "S3Q1Answer,S3Q1Score,S3Q2Answer,S3Q2Score,S3Q3Answer,S3Q3Score,S3Q4Answer,S3Q4Score,S3Q5Answer,S3Q5Score,S3Q6Answer,S3Q6Score," +
            "S3Q7Answer,S3Q7Score,S3Q8Answer,S3Q8Score,S3Q9Answer,S3Q9Score,S3Q10Answer,S3Q10Score," +
            "S4aQ1Answer,S4aQ2Answer,S4aQ3Answer,S4aQ4Answer,S4aQ5Answer,S4aQ6Answer,S4aQ7Answer,S4aQ8Answer,S4aQ9Answer,S4aQ10Answer," +
            "S4aQ11Answer,S4aQ12Answer,S4aQ13Answer,S4aQ14Answer,S4aQ15Answer,S4aQ16Answer,S4aQ17Answer,S4aQ18Answer,S4aQ19Answer,S4aQ20Answer," +
            "S4aQ21Answer,S4aQ22Answer,S4aQ23Answer,S4aQ24Answer,S4aQ25Answer,S4aQ26Answer,S4aQ27Answer,S4aQ28Answer,S4aQ29Answer,S4aQ30Answer," +
            "S4aQ31Answer,S4aQ32Answer,S4aQ33Answer,S4aQ34Answer,S4aQ35Answer,S4aQ36Answer,S4aQ37Answer,S4aQ38Answer,S4aQ39Answer,S4aQ40Answer," +
            "S4aQ41Answer,S4aQ42Answer,S4aQ43Answer,S4aQ44Answer,S4aQ45Answer,S4aQ46Answer,S4aQ47Answer,S4aQ48Answer,S4aQ49Answer,S4aQ50Answer," +
            "S4aQ51Answer,S4aQ52Answer,S4aQ53Answer,S4aQ54Answer,S4aQ55Answer,S4aQ56Answer,S4aQ57Answer," +
            "S4bQ1Answer,S4bQ2Answer,S4bQ3Answer,S4bQ4Answer,S4bQ5Answer,S4bQ6Answer,S4bQ7Answer,S4bQ8Answer,S4bQ9Answer,S4bQ10Answer," +
            "S4bQ11Answer,S4bQ12Answer,S4bQ13Answer,S4bQ14Answer,S4bQ15Answer,S4bQ16Answer,S4bQ17Answer,S4bQ18Answer,S4bQ19Answer,S4bQ20Answer," +
            "S4bQ21Answer,S4bQ22Answer,S4bQ23Answer,S4bQ24Answer,S4bQ25Answer,S4bQ26Answer,S4bQ27Answer,S4bQ28Answer,S4bQ29Answer,S4bQ30Answer," +
            "S4bQ31Answer,S4bQ32Answer,S4bQ33Answer,S4bQ34Answer,S4bQ35Answer,S4bQ36Answer,S4bQ37Answer,S4bQ38Answer,S4bQ39Answer,S4bQ40Answer," +
            "S4bQ41Answer,S4bQ42Answer,S4bQ43Answer,S4bQ44Answer,S4bQ45Answer,S4bQ46Answer,S4bQ47Answer,S4bQ48Answer,S4bQ49Answer,S4bQ50Answer," +
            "S4bQ51Answer,S4bQ52Answer,S4bQ53Answer,S4bQ54Answer,S4bQ55Answer,S4bQ56Answer,S4bQ57Answer,S4bQ58Answer,S4bQ59Answer,S4bQ60Answer," +
            "S4bQ61Answer")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                Survey surveyCreate = new Survey()
                {
                    SurveyID = Guid.NewGuid().ToString(),
                    StartTime = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    S1Q1Answer = "",
                    S1Q2Answer = "",
                    S1Q3Answer = "",
                    S1Q3Score = 0,
                    S1Q4Answer = "",
                    S1Q5Answer = "",
                    S1Q6Answer = "",
                    S1Q6Score = 0,
                    S1Q7Answer = "",
                    S1Q8Answer = "",
                    S1Q9Answer = "",
                    S1Q10Answer = "",
                    S1Q10Score = 0,
                    S1Q11Answer = "",
                    S1Q11Score = 0,
                    S1Q12Answer = "",
                    S1Q13Answer = "",
                    S1Q13Score = 0,
                    S1Q14Answer = "",
                    S1Q15Answer = "",
                    S1Q16Answer = "",
                    S2Q1Answer = "",
                    S2Q1Score = 0,
                    S2Q2Answer = "",
                    S2Q2Score = 0,
                    S2Q3Answer = "",
                    S2Q3Score = 0,
                    S2Q4Answer = "",
                    S2Q4Score = 0,
                    S2Q5Answer = "",
                    S2Q5Score = 0,
                    S2Q6Answer = "",
                    S2Q6Score = 0,
                    S2Q7Answer = "",
                    S2Q7Score = 0,
                    S2Q8Answer = "",
                    S2Q8Score = 0,
                    S2Q9Answer = "",
                    S2Q9Score = 0,
                    S2Q10Answer = "",
                    S2Q10Score = 0,
                    S3Q1Answer = "",
                    S3Q1Score = 0,
                    S3Q2Answer = "",
                    S3Q2Score = 0,
                    S3Q3Answer = "",
                    S3Q3Score = 0,
                    S3Q4Answer = "",
                    S3Q4Score = 0,
                    S3Q5Answer = "",
                    S3Q5Score = 0,
                    S3Q6Answer = "",
                    S3Q6Score = 0,
                    S3Q7Answer = "",
                    S3Q7Score = 0,
                    S3Q8Answer = "",
                    S3Q8Score = 0,
                    S3Q9Answer = "",
                    S3Q9Score = 0,
                    S3Q10Answer = "",
                    S3Q10Score = 0,
                    S4aQ1Answer = "",
                    S4aQ2Answer = "",
                    S4aQ3Answer = "",
                    S4aQ4Answer = "",
                    S4aQ5Answer = "",
                    S4aQ6Answer = "",
                    S4aQ7Answer = "",
                    S4aQ8Answer = "",
                    S4aQ9Answer = "",
                    S4aQ10Answer = "",
                    S4aQ11Answer = "",
                    S4aQ12Answer = "",
                    S4aQ13Answer = "",
                    S4aQ14Answer = "",
                    S4aQ15Answer = "",
                    S4aQ16Answer = "",
                    S4aQ17Answer = "",
                    S4aQ18Answer = "",
                    S4aQ19Answer = "",
                    S4aQ20Answer = "",
                    S4aQ21Answer = "",
                    S4aQ22Answer = "",
                    S4aQ23Answer = "",
                    S4aQ24Answer = "",
                    S4aQ25Answer = "",
                    S4aQ26Answer = "",
                    S4aQ27Answer = "",
                    S4aQ28Answer = "",
                    S4aQ29Answer = "",
                    S4aQ30Answer = "",
                    S4aQ31Answer = "",
                    S4aQ32Answer = "",
                    S4aQ33Answer = "",
                    S4aQ34Answer = "",
                    S4aQ35Answer = "",
                    S4aQ36Answer = "",
                    S4aQ37Answer = "",
                    S4aQ38Answer = "",
                    S4aQ39Answer = "",
                    S4aQ40Answer = "",
                    S4aQ41Answer = "",
                    S4aQ42Answer = "",
                    S4aQ43Answer = "",
                    S4aQ44Answer = "",
                    S4aQ45Answer = "",
                    S4aQ46Answer = "",
                    S4aQ47Answer = "",
                    S4aQ48Answer = "",
                    S4aQ49Answer = "",
                    S4aQ50Answer = "",
                    S4aQ51Answer = "",
                    S4aQ52Answer = "",
                    S4aQ53Answer = "",
                    S4aQ54Answer = "",
                    S4aQ55Answer = "",
                    S4aQ56Answer = "",
                    S4aQ57Answer = "",
                    S4bQ1Answer = "",
                    S4bQ2Answer = "",
                    S4bQ3Answer = "",
                    S4bQ4Answer = "",
                    S4bQ5Answer = "",
                    S4bQ6Answer = "",
                    S4bQ7Answer = "",
                    S4bQ8Answer = "",
                    S4bQ9Answer = "",
                    S4bQ10Answer = "",
                    S4bQ11Answer = "",
                    S4bQ12Answer = "",
                    S4bQ13Answer = "",
                    S4bQ14Answer = "",
                    S4bQ15Answer = "",
                    S4bQ16Answer = "",
                    S4bQ17Answer = "",
                    S4bQ18Answer = "",
                    S4bQ19Answer = "",
                    S4bQ20Answer = "",
                    S4bQ21Answer = "",
                    S4bQ22Answer = "",
                    S4bQ23Answer = "",
                    S4bQ24Answer = "",
                    S4bQ25Answer = "",
                    S4bQ26Answer = "",
                    S4bQ27Answer = "",
                    S4bQ28Answer = "",
                    S4bQ29Answer = "",
                    S4bQ30Answer = "",
                    S4bQ31Answer = "",
                    S4bQ32Answer = "",
                    S4bQ33Answer = "",
                    S4bQ34Answer = "",
                    S4bQ35Answer = "",
                    S4bQ36Answer = "",
                    S4bQ37Answer = "",
                    S4bQ38Answer = "",
                    S4bQ39Answer = "",
                    S4bQ40Answer = "",
                    S4bQ41Answer = "",
                    S4bQ42Answer = "",
                    S4bQ43Answer = "",
                    S4bQ44Answer = "",
                    S4bQ45Answer = "",
                    S4bQ46Answer = "",
                    S4bQ47Answer = "",
                    S4bQ48Answer = "",
                    S4bQ49Answer = "",
                    S4bQ50Answer = "",
                    S4bQ51Answer = "",
                    S4bQ52Answer = "",
                    S4bQ53Answer = "",
                    S4bQ54Answer = "",
                    S4bQ55Answer = "",
                    S4bQ56Answer = "",
                    S4bQ57Answer = "",
                    S4bQ58Answer = "",
                    S4bQ59Answer = "",
                    S4bQ60Answer = "",
                    S4bQ61Answer = ""
                };
                db.Surveys.Add(surveyCreate);
                db.SaveChanges();
                Session["viewKey"] = surveyCreate.SurveyID;
                Session["error"] = "null";
                Session["s1mark"] = 0;

                return RedirectToAction("S1Page1");
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(x => x.Errors);
                Session["error"] = "Model state is invalid" + allErrors.ToString();
                return View("Error");
            }
        }

        // Get: ErrorSessionOut
        public ActionResult ErrorSessionOut()
        {
            return View();
        }

        // Get: S1Page1
        public ActionResult S1Page1()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section1/S1Page1");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S1Page1
        [HttpPost, ActionName("S1Page1")]
        [ValidateAntiForgeryToken]
        public ActionResult S1Page1Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S1Q1Answer", "S1Q2Answer", "S1Q3Answer", "S1Q4Answer", "S1Q5Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S1Page2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S1Page2
        public ActionResult S1Page2()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S1Q3ScoreLocal = 0;
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S1Q3Answer))
                    {
                        if (survey.S1Q3Answer == "UK")
                        {
                            S1Q3ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q3ScoreLocal = 0;
                        }

                        if (TryUpdateModel(survey, "", new string[] { "S1Q3Score" }))
                        {
                            try
                            {
                                survey.S1Q3Score = S1Q3ScoreLocal;
                                db.SaveChanges();
                                return View("Section1/S1Page2");
                            }
                            catch (RetryLimitExceededException)
                            {
                                ModelState.AddModelError("", "Unable to save changes for S1Page1. Try again, and if the problem persists, see your system administrator.");
                            }
                        }
                    }

                    Session["s1mark"] = Section1TotalScore + S1Q3ScoreLocal;
                    return View("Section1/S1Page2");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S1Page2
        [HttpPost, ActionName("S1Page2")]
        [ValidateAntiForgeryToken]
        public ActionResult S1Page2Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S1Q6Answer", "S1Q7Answer", "S1Q8Answer", "S1Q9Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S1Page3");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Model state is invalid";
                return View("Error");
            }
        }

        // Get: S1Page3
        public ActionResult S1Page3()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S1Q6ScoreLocal = 0;

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S1Q6Answer))
                    {
                        if (survey.S1Q6Answer == "UK")
                        {
                            S1Q6ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q6ScoreLocal = 0;
                        }

                        if (TryUpdateModel(survey, "", new string[] { "S1Q6Score" }))
                        {
                            try
                            {
                                survey.S1Q6Score = S1Q6ScoreLocal;
                                db.SaveChanges();
                                return View("Section1/S1Page3");
                            }
                            catch (RetryLimitExceededException)
                            {
                                ModelState.AddModelError("", "Unable to save changes for S1Page1. Try again, and if the problem persists, see your system administrator.");
                            }
                        }
                    }

                    Session["s1mark"] = ((int)Session["s1mark"]) + S1Q6ScoreLocal;

                    return View("Section1/S1Page3");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S1Page3
        [HttpPost, ActionName("S1Page3")]
        [ValidateAntiForgeryToken]
        public ActionResult S1Page3Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S1Q10Answer", "S1Q11Answer", "S1Q12Answer", "S1Q13Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S1Page4");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page3. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(x => x.Errors);
                Session["error"] = "Model state is invalid" + allErrors.ToString();
                return View("Error");
            }
        }

        // Get: S1Page4
        public ActionResult S1Page4()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S1Q10ScoreLocal = 0;
            int S1Q11ScoreLocal = 0;
            int S1Q13ScoreLocal = 0;

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S1Q10Answer))
                    {
                        if (survey.S1Q10Answer == "exp3")
                        {
                            S1Q10ScoreLocal = 10;
                        }
                        else if (survey.S1Q10Answer == "exp2")
                        {
                            S1Q10ScoreLocal = 5;
                        }
                        else
                        {
                            S1Q10ScoreLocal = 0;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q11Answer))
                    {
                        if (survey.S1Q11Answer == "yes")
                        {
                            S1Q11ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q11ScoreLocal = 0;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q13Answer))
                    {
                        if (survey.S1Q13Answer == "time4")
                        {
                            S1Q13ScoreLocal = 30;
                        }
                        else if (survey.S1Q13Answer == "time3")
                        {
                            S1Q13ScoreLocal = 20;
                        }
                        else if (survey.S1Q13Answer == "time2")
                        {
                            S1Q13ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q13ScoreLocal = 0;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S1Q10Score", "S1Q11Score", "S1Q13Score" }))
                    {
                        try
                        {
                            survey.S1Q10Score = S1Q10ScoreLocal;
                            survey.S1Q11Score = S1Q11ScoreLocal;
                            survey.S1Q13Score = S1Q13ScoreLocal;
                            db.SaveChanges();
                            return View("Section1/S1Page4");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }

                Session["s1mark"] = ((int)Session["s1mark"]) + S1Q10ScoreLocal + S1Q11ScoreLocal + S1Q13ScoreLocal;

                return View("Section1/S1Page4");
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S1Page4
        [HttpPost, ActionName("S1Page4")]
        [ValidateAntiForgeryToken]
        public ActionResult S1Page4Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S1Q14Answer", "S1Q15Answer", "S1Q16Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S1PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page4. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Model start is invalid";
                return View("Error");
            }
        }

        // Get: S1PageSum
        public ActionResult S1PageSum()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S1Score = 0;
            string S1ScoreMsg = "";

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;

                    if (S1Score > 50)
                    {
                        S1ScoreMsg = "基本符合英国移民局关于企业家移民要求，可以进入下一步评测。";
                    }
                    else if (S1Score >= 30 && S1Score <= 50)
                    {
                        S1ScoreMsg = "有可能符合英国移民局关于企业家移民要求，可以进入下一步评测。";
                    }
                    else if (S1Score < 30)
                    {
                        S1ScoreMsg = "您的个人背景在现阶段达不到英国对企业家的要求， 请选择其它移民类别。";
                        return RedirectToAction("S1PageEnd");
                    }

                    ViewBag.Section1Score = S1Score;
                    ViewBag.Section1Message = S1ScoreMsg;

                    return View("Section1/S1PageSum");
                }
                else
                {
                    Session["error"] = "database is empty!";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S1PageSum
        [HttpPost, ActionName("S1PageSum")]
        [ValidateAntiForgeryToken]
        public ActionResult S1PageSumPost()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            return RedirectToAction("S2Page1");
        }

        // Get: S1PageEnd
        public ActionResult S1PageEnd()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View("Section1/S1PageEnd");
        }

        // Get: S2Page1
        public ActionResult S2Page1()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section2/S2Page1");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S2Page1
        [HttpPost, ActionName("S2Page1")]
        [ValidateAntiForgeryToken]
        public ActionResult S2Page1Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S2Q1Answer", "S2Q2Answer", "S2Q3Answer", "S2Q4Answer", "S2Q5Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S2Page2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S2Page1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S2Page2
        public ActionResult S2Page2()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S2Q1ScoreLocal = 0;
            int S2Q2ScoreLocal = 0;
            int S2Q3ScoreLocal = 0;
            int S2Q4ScoreLocal = 0;
            int S2Q5ScoreLocal = 0;

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S2Q1Answer))
                    {
                        if (survey.S2Q1Answer == "business")
                        {
                            S2Q1ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q2Answer))
                    {
                        if (survey.S2Q2Answer == "yes")
                        {
                            S2Q2ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q3Answer))
                    {
                        if (survey.S2Q3Answer == "ielts5")
                        {
                            S2Q3ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q4Answer))
                    {
                        if (survey.S2Q4Answer == "200K")
                        {
                            S2Q4ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q5Answer))
                    {
                        if (survey.S2Q5Answer == "canwork")
                        {
                            S2Q5ScoreLocal = 10;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S2Q1Score", "S2Q2Score", "S2Q3Score", "S2Q4Score", "S2Q5Score" }))
                    {
                        try
                        {
                            survey.S2Q1Score = S2Q1ScoreLocal;
                            survey.S2Q2Score = S2Q2ScoreLocal;
                            survey.S2Q3Score = S2Q3ScoreLocal;
                            survey.S2Q4Score = S2Q4ScoreLocal;
                            survey.S2Q5Score = S2Q5ScoreLocal;
                            db.SaveChanges();
                            return View("Section2/S2Page2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1Page1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                return View("Section1/S2Page2");
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S2Page2
        [HttpPost, ActionName("S2Page2")]
        [ValidateAntiForgeryToken]
        public ActionResult S2Page2Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S2Q6Answer", "S2Q7Answer", "S2Q8Answer", "S2Q9Answer", "S2Q10Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S2PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S2Page2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S2PageSum
        public ActionResult S2PageSum()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S2Q6ScoreLocal = 0;
            int S2Q7ScoreLocal = 0;
            int S2Q8ScoreLocal = 0;
            int S2Q9ScoreLocal = 0;
            int S2Q10ScoreLocal = 0;

            int S1ScoreTest = 0;
            int S2Score = 0;
            string S2ScoreMsg = "";

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S2Q6Answer))
                    {
                        if (survey.S2Q6Answer == "can")
                        {
                            S2Q6ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q7Answer))
                    {
                        if (survey.S2Q7Answer == "100")
                        {
                            S2Q7ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q8Answer))
                    {
                        if (survey.S2Q3Answer == "can")
                        {
                            S2Q8ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q9Answer))
                    {
                        if (survey.S2Q9Answer == "2emp")
                        {
                            S2Q9ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q10Answer))
                    {
                        if (survey.S2Q10Answer == "freedom")
                        {
                            S2Q10ScoreLocal = 10;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S2Q6Score", "S2Q7Score", "S2Q8Score", "S2Q9Score", "S2Q10Score" }))
                    {
                        try
                        {
                            survey.S2Q6Score = S2Q6ScoreLocal;
                            survey.S2Q7Score = S2Q7ScoreLocal;
                            survey.S2Q8Score = S2Q8ScoreLocal;
                            survey.S2Q9Score = S2Q9ScoreLocal;
                            survey.S2Q10Score = S2Q10ScoreLocal;
                            db.SaveChanges();

                            S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                            S1ScoreTest = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;

                            if (S2Score == 100)
                            {
                                S2ScoreMsg = "您对英国企业家移民签证政策充分了解，可以进入下一步评测。";
                            }
                            else if (S2Score >= 60 && S2Score < 100)
                            {
                                S2ScoreMsg = "您对英国企业家移民签证政策基本了解，可以进入下一步评测。";
                            }
                            else if (S2Score < 60)
                            {
                                // 退出测试按键？
                                S2ScoreMsg = "您对英国企业家移民签证政策不够了解，建议您充分了解政策后再进入下一步评测。";
                            }

                            ViewBag.Section1ScoreTest = S1ScoreTest;
                            ViewBag.Section2Score = S2Score;
                            ViewBag.Section2Message = S2ScoreMsg;

                            return View("Section2/S2PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S2PageSum. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                return View("Section2/S2PageSum");
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S2PageSum
        [HttpPost, ActionName("S2PageSum")]
        [ValidateAntiForgeryToken]
        public ActionResult S2PageSumPost()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            return RedirectToAction("S3Page1");
        }

        // Get: S3Page1
        public ActionResult S3Page1()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section3/S3Page1");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S3Page1
        [HttpPost, ActionName("S3Page1")]
        [ValidateAntiForgeryToken]
        public ActionResult S3Page1Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S3Q1Answer", "S3Q2Answer", "S3Q3Answer", "S3Q4Answer", "S3Q5Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S3Page2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S2Page1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S3Page2
        public ActionResult S3Page2()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S3Q1ScoreLocal = 0;
            int S3Q2ScoreLocal = 0;
            int S3Q3ScoreLocal = 0;
            int S3Q4ScoreLocal = 0;
            int S3Q5ScoreLocal = 0;

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S3Q1Answer))
                    {
                        if (survey.S3Q1Answer == "20pct")
                        {
                            S3Q1ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q2Answer))
                    {
                        if (survey.S3Q2Answer == "yes")
                        {
                            S3Q2ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q3Answer))
                    {
                        if (survey.S3Q3Answer == "7.50")
                        {
                            S3Q3ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q4Answer))
                    {
                        if (survey.S3Q4Answer == "25k")
                        {
                            S3Q4ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q5Answer))
                    {
                        if (survey.S3Q5Answer == "2k")
                        {
                            S3Q5ScoreLocal = 10;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S3Q1Score", "S3Q2Score", "S3Q3Score", "S3Q4Score", "S3Q5Score" }))
                    {
                        try
                        {
                            survey.S3Q1Score = S3Q1ScoreLocal;
                            survey.S3Q2Score = S3Q2ScoreLocal;
                            survey.S3Q3Score = S3Q3ScoreLocal;
                            survey.S3Q4Score = S3Q4ScoreLocal;
                            survey.S3Q5Score = S3Q5ScoreLocal;
                            db.SaveChanges();
                            return View("Section3/S3Page2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S3Page2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                return View("Section3/S3Page2");
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S3Page2
        [HttpPost, ActionName("S3Page2")]
        [ValidateAntiForgeryToken]
        public ActionResult S3Page2Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S3Q6Answer", "S3Q7Answer", "S3Q8Answer", "S3Q9Answer", "S3Q10Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S3PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S3Page2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S3PageSum
        public ActionResult S3PageSum()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            int S3Q6ScoreLocal = 0;
            int S3Q7ScoreLocal = 0;
            int S3Q8ScoreLocal = 0;
            int S3Q9ScoreLocal = 0;
            int S3Q10ScoreLocal = 0;

            int S3Score = 0;
            string S3ScoreMsg = "";

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S3Q6Answer))
                    {
                        if (survey.S3Q6Answer == "20pct")
                        {
                            S3Q6ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q7Answer))
                    {
                        if (survey.S3Q7Answer == "yes")
                        {
                            S3Q7ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q8Answer))
                    {
                        if (survey.S3Q3Answer == "2000")
                        {
                            S3Q8ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q9Answer))
                    {
                        if (survey.S3Q9Answer == "500")
                        {
                            S3Q9ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S3Q10Answer))
                    {
                        if (survey.S3Q10Answer == "yes")
                        {
                            S3Q10ScoreLocal = 10;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S3Q6Score", "S3Q7Score", "S3Q8Score", "S3Q9Score", "S3Q10Score" }))
                    {
                        try
                        {
                            survey.S3Q6Score = S3Q6ScoreLocal;
                            survey.S3Q7Score = S3Q7ScoreLocal;
                            survey.S3Q8Score = S3Q8ScoreLocal;
                            survey.S3Q9Score = S3Q9ScoreLocal;
                            survey.S3Q10Score = S3Q10ScoreLocal;
                            db.SaveChanges();

                            S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;

                            if (S3Score == 100)
                            {
                                S3ScoreMsg = "您对英国基本商业知识比较了解，可以进入下一步评测。";
                            }
                            else if (S3Score >= 60 && S3Score < 100)
                            {
                                S3ScoreMsg = "您对英国基本商业知识有一定了解，可以进入下一步评测。";
                            }
                            else if (S3Score < 60)
                            {
                                // 退出测试按键？
                                S3ScoreMsg = "您对英国基本商业知识不够了解，建议您充分了解政策后再进入下一步评测。";
                            }

                            ViewBag.Section3Score = S3Score;
                            ViewBag.Section3Message = S3ScoreMsg;

                            return View("Section3/S3PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S2PageSum. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                return View("Section3/S3PageSum");
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Post: S3PageSum - to S4a or S4b
        [HttpPost, ActionName("S3PageSum")]
        [ValidateAntiForgeryToken]
        public ActionResult S3PageSumPost(string Section4)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (Section4 == "英国创业项目测试 - 独立测试")
            {
                return RedirectToAction("S4aPage1");
            }
            else if (Section4 == "英国创业项目测试 - 加入创业")
            {
                return RedirectToAction("S4bPage1");
            }
            else
            {
                Session["error"] = "Section4 interaction error, please contact admin";
                return View("Error");
            }
        }

        // Get: S4aPage1
        public ActionResult S4aPage1()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage1");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage1
        [HttpPost, ActionName("S4aPage1")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage1Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ1Answer", "S4aQ2Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage2
        public ActionResult S4aPage2()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage2");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage2
        [HttpPost, ActionName("S4aPage2")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage2Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ3Answer", "S4aQ4Answer", "S4aQ5Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage3");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage3
        public ActionResult S4aPage3()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage3");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage3
        [HttpPost, ActionName("S4aPage3")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage3Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ6Answer", "S4aQ7Answer", "S4aQ8Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage4");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage3. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage4
        public ActionResult S4aPage4()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage4");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage4
        [HttpPost, ActionName("S4aPage4")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage4Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ9Answer", "S4aQ10Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage5");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage4. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage5
        public ActionResult S4aPage5()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage5");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage5
        [HttpPost, ActionName("S4aPage5")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage5Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ11Answer", "S4aQ12Answer", "S4aQ13Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage6");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage5. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage6
        public ActionResult S4aPage6()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage6");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage6
        [HttpPost, ActionName("S4aPage6")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage6Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ14Answer", "S4aQ15Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage7");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage6. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage7
        public ActionResult S4aPage7()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage7");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage7
        [HttpPost, ActionName("S4aPage7")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage7Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ16Answer", "S4aQ17Answer", "S4aQ18Answer", "S4aQ19Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage8");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage7. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage8
        public ActionResult S4aPage8()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage8");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage8
        [HttpPost, ActionName("S4aPage8")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage8Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ20Answer", "S4aQ21Answer", "S4aQ22Answer", "S4aQ23Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage9");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage8. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage9
        public ActionResult S4aPage9()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage9");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage9
        [HttpPost, ActionName("S4aPage9")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage9Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ24Answer", "S4aQ25Answer", "S4aQ26Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage10");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage9. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage10
        public ActionResult S4aPage10()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage10");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage10
        [HttpPost, ActionName("S4aPage10")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage10Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ27Answer", "S4aQ28Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage11");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage10. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage11
        public ActionResult S4aPage11()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage11");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage11
        [HttpPost, ActionName("S4aPage11")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage11Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ29Answer", "S4aQ30Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage12");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage11. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage12
        public ActionResult S4aPage12()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage12");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage12
        [HttpPost, ActionName("S4aPage12")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage12Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ31Answer", "S4aQ32Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage13");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage12. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage13
        public ActionResult S4aPage13()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage13");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage13
        [HttpPost, ActionName("S4aPage13")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage13Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ33Answer", "S4aQ34Answer", "S4aQ35Answer", "S4aQ36Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage14");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage13. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage14
        public ActionResult S4aPage14()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage14");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage14
        [HttpPost, ActionName("S4aPage14")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage14Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ37Answer", "S4aQ38Answer", "S4aQ39Answer", "S4aQ40Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage15");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage14. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage15
        public ActionResult S4aPage15()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage15");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage15
        [HttpPost, ActionName("S4aPage15")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage15Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ41Answer", "S4aQ42Answer", "S4aQ43Answer", "S4aQ44Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage16");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage15. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage16
        public ActionResult S4aPage16()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage16");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage16
        [HttpPost, ActionName("S4aPage16")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage16Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ45Answer", "S4aQ46Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage17");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage16. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage17
        public ActionResult S4aPage17()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage17");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage17
        [HttpPost, ActionName("S4aPage17")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage17Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ47Answer", "S4aQ48Answer", "S4aQ49Answer", "S4aQ50Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage18");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage17. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage18
        public ActionResult S4aPage18()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage18");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage18
        [HttpPost, ActionName("S4aPage18")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage18Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ51Answer", "S4aQ52Answer", "S4aQ53Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPage19");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage18. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPage19
        public ActionResult S4aPage19()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4a/S4aPage19");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4aPage19
        [HttpPost, ActionName("S4aPage19")]
        [ValidateAntiForgeryToken]
        public ActionResult S4aPage19Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ54Answer", "S4aQ55Answer", "S4aQ56Answer", "S4aQ57Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4aPage19. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4aPageSum
        public ActionResult S4aPageSum()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);

            int S1ScoreTest = 0;
            string S1ScoreTestMsg = "";

            if (survey != null)
            {
                S1ScoreTest = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                if (S1ScoreTest > 60)
                {
                    S1ScoreTestMsg = "第一部得分大于60分：您对英国企业家移民签证政策充分了解，可以进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }
                else if (S1ScoreTest >= 30 && S1ScoreTest < 60)
                {
                    S1ScoreTestMsg = "第一部分得分在30-60分之间：您对英国企业家移民签证政策基本了解，可以进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }
                else if (S1ScoreTest < 30)
                {
                    S1ScoreTestMsg = "第一部分得分在30分以下：您对英国企业家移民签证政策不够了解，建议您充分了解政策后再进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }

                ViewBag.Section1ScoreTest = S1ScoreTest;
                ViewBag.Section2Message = S1ScoreTestMsg;

                return View("Section4a/S4aPageSum");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Get: S4bPage1
        public ActionResult S4bPage1()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage1");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage1
        [HttpPost, ActionName("S4bPage1")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage1Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ1Answer", "S4bQ2Answer", "S4bQ3Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage2");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage2
        public ActionResult S4bPage2()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage2");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage2
        [HttpPost, ActionName("S4bPage2")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage2Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ4Answer", "S4bQ5Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage3");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage2. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage3
        public ActionResult S4bPage3()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage3");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage3
        [HttpPost, ActionName("S4bPage3")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage3Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ6Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage4");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage3. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage4
        public ActionResult S4bPage4()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage4");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage4
        [HttpPost, ActionName("S4bPage4")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage4Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ7Answer", "S4bQ8Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage5");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage4. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage5
        public ActionResult S4bPage5()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage5");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage5
        [HttpPost, ActionName("S4bPage5")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage5Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ9Answer", "S4bQ10Answer", "S4bQ11Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage6");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage5. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage6
        public ActionResult S4bPage6()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage6");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage6
        [HttpPost, ActionName("S4bPage6")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage6Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ12Answer", "S4bQ13Answer", "S4bQ14Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage7");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage6. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage7
        public ActionResult S4bPage7()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage7");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage7
        [HttpPost, ActionName("S4bPage7")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage7Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ15Answer", "S4bQ16Answer", "S4bQ17Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage8");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage7. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage8
        public ActionResult S4bPage8()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage8");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage8
        [HttpPost, ActionName("S4bPage8")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage8Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ18Answer", "S4bQ19Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage9");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage8. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage9
        public ActionResult S4bPage9()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage9");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage9
        [HttpPost, ActionName("S4bPage9")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage9Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ20Answer", "S4bQ21Answer", "S4bQ22Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage10");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage9. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage10
        public ActionResult S4bPage10()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage10");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage10
        [HttpPost, ActionName("S4bPage10")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage10Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ23Answer", "S4bQ24Answer", "S4bQ25Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage11");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage10. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage11
        public ActionResult S4bPage11()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage11");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage11
        [HttpPost, ActionName("S4bPage11")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage11Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ26Answer", "S4bQ27Answer", "S4bQ28Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage12");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage11. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage12
        public ActionResult S4bPage12()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage12");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage12
        [HttpPost, ActionName("S4bPage12")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage12Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ29Answer", "S4bQ30Answer", "S4bQ31Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage13");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage12. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage13
        public ActionResult S4bPage13()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage13");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage13
        [HttpPost, ActionName("S4bPage13")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage13Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ32Answer", "S4bQ33Answer", "S4bQ34Answer", "S4bQ35Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage14");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage13. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage14
        public ActionResult S4bPage14()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage14");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage14
        [HttpPost, ActionName("S4bPage14")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage14Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ36Answer", "S4bQ37Answer", "S4bQ38Answer", "S4bQ39Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage15");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage14. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage15
        public ActionResult S4bPage15()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage15");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage15
        [HttpPost, ActionName("S4bPage15")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage15Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ40Answer", "S4bQ41Answer", "S4bQ42Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage16");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage15. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage16
        public ActionResult S4bPage16()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage16");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage16
        [HttpPost, ActionName("S4bPage16")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage16Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ43Answer", "S4bQ44Answer", "S4bQ45Answer", "S4bQ46Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage17");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage16. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage17
        public ActionResult S4bPage17()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage17");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage17
        [HttpPost, ActionName("S4bPage17")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage17Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ47Answer", "S4bQ48Answer", "S4bQ49Answer", "S4bQ50Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage18");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage17. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage18
        public ActionResult S4bPage18()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage18");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage18
        [HttpPost, ActionName("S4bPage18")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage18Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ51Answer", "S4bQ52Answer", "S4bQ53Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage19");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage18. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage19
        public ActionResult S4bPage19()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage19");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage19
        [HttpPost, ActionName("S4bPage19")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage19Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ54Answer", "S4bQ55Answer", "S4bQ56Answer", "S4bQ57Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPage20");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage19. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPage20
        public ActionResult S4bPage20()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);
            if (survey != null)
            {
                return View("Section4b/S4bPage20");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Post: S4bPage20
        [HttpPost, ActionName("S4bPage20")]
        [ValidateAntiForgeryToken]
        public ActionResult S4bPage20Post()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ58Answer", "S4bQ59Answer", "S4bQ60Answer", "S4bQ61Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S4bPage20. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cant update model";
                    return View("Error");
                }
                else
                {
                    Session["error"] = "Db is null";
                    return View("Error");
                }
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }
        }

        // Get: S4bPageSum
        public ActionResult S4bPageSum()
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "Session timeout";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);

            int S1ScoreTest = 0;
            string S1ScoreTestMsg = "";

            if (survey != null)
            {
                S1ScoreTest = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                if (S1ScoreTest > 60)
                {
                    S1ScoreTestMsg = "第一部得分大于60分：您对英国企业家移民签证政策充分了解，可以进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }
                else if (S1ScoreTest >= 30 && S1ScoreTest < 60)
                {
                    S1ScoreTestMsg = "第一部分得分在30-60分之间：您对英国企业家移民签证政策基本了解，可以进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }
                else if (S1ScoreTest < 30)
                {
                    S1ScoreTestMsg = "第一部分得分在30分以下：您对英国企业家移民签证政策不够了解，建议您充分了解政策后再进入下一步评测。Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tempus pulvinar dictum. Praesent commodo augue vitae massa vestibulum pulvinar id nec mauris. Nam id tellus tincidunt, fringilla massa eu, finibus lectus. Quisque quis elementum ante. Etiam varius aliquam lacus. Pellentesque vitae luctus eros. Nunc maximus sapien sit amet ipsum scelerisque lobortis. Aenean ac vestibulum lacus. Integer bibendum nunc in aliquet commodo. Nunc mollis laoreet felis in faucibus. Integer faucibus ornare libero sed suscipit. Nullam in euismod nunc, eu tempus velit.";
                }

                ViewBag.Section1ScoreTest = S1ScoreTest;
                ViewBag.Section2Message = S1ScoreTestMsg;

                return View("Section4b/S4bPageSum");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}