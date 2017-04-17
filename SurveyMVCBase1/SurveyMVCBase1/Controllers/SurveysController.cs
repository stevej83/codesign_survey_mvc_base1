using SurveyMVCBase1.DAL;
using SurveyMVCBase1.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SurveyMVCBase1.Controllers
{
    public class SurveysController : Controller
    {
        private SurveyContext db = new SurveyContext();

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
            Include = "SurveyID,S1Q1Answer,S1Q2Answer,S1Q3Answer,S1Q3Score,S1Q4Answer,S1Q5Answer,S1Q6Answer,S1Q6Score,S1Q7Answer,S1Q8Answer," +
            "S1Q9Answer,S1Q10Answer,S1Q10Score,S1Q11Answer,S1Q11Score,S1Q12Answer,S1Q13Answer,S1Q13Score,S1Q14Answer,S1Q15Answer,S1Q16Answer")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                Survey surveyCreate = new Survey();
                surveyCreate.SurveyID = Guid.NewGuid().ToString();
                surveyCreate.S1Q1Answer = "";
                //surveyCreate.S1Q2Answer = new DateTime(1980, 01, 01);
                surveyCreate.S1Q2Answer = "";
                surveyCreate.S1Q3Answer = "";
                surveyCreate.S1Q3Score = 0;
                surveyCreate.S1Q4Answer = "";
                surveyCreate.S1Q5Answer = "";
                surveyCreate.S1Q6Answer = "";
                surveyCreate.S1Q6Score = 0;
                surveyCreate.S1Q7Answer = "";
                surveyCreate.S1Q8Answer = "";
                surveyCreate.S1Q9Answer = "";
                surveyCreate.S1Q10Answer = "";
                surveyCreate.S1Q10Score = 0;
                surveyCreate.S1Q11Answer = "";
                surveyCreate.S1Q11Score = 0;
                surveyCreate.S1Q12Answer = "";
                surveyCreate.S1Q13Answer = "";
                surveyCreate.S1Q13Score = 0;
                surveyCreate.S1Q14Answer = "";
                surveyCreate.S1Q15Answer = "";
                surveyCreate.S1Q16Answer = "";

                db.Surveys.Add(surveyCreate);
                db.SaveChanges();
                Session["viewKey"] = surveyCreate.SurveyID;
                Session["error"] = "null";

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
            if (survey != null)
            {
                return View("Section1/S1PageSum");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,S1Q1Answer,S1Q1Score,S1Q2Answer,S1Q2Score")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,S1Q1Answer,S1Q1Score,S1Q2Answer,S1Q2Score")] Survey survey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(survey).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}