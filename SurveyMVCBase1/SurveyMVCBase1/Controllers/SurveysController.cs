using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyMVCBase1.DAL;
using SurveyMVCBase1.Models;

namespace SurveyMVCBase1.Controllers
{
    public class SurveysController : Controller
    {
        private SurveyContext db = new SurveyContext();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }


        // direct to page - Workflow
        public ActionResult Workflow()
        {
            Survey survyCreate = new Survey();
            survyCreate.SurveyID = Guid.NewGuid().ToString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Workflow([Bind(Include = "SurveyID,S1Q1Answer,S1Q2Answer,S1Q3Answer,S1Q3Score,S1Q4Answer,S1Q5Answer,S1Q6Answer,S1Q6Score,S1Q7Answer,S1Q8Answer")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Section1 / S1Page1");
            }

            return View();
        }

        public ActionResult S1Page1(string id)
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
            return View("Section1 / S1Page1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult S1Page1([Bind(Include = "SurveyID,S1Q1Answer,S1Q2Answer,S1Q3Answer,S1Q3Score,S1Q4Answer,S1Q5Answer,S1Q6Answer,S1Q6Score,S1Q7Answer,S1Q8Answer")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Section1 / S1Page2");
            }

            return View("Section1 / S1Page1");
        }

        public ActionResult S1Page2()
        {
            return View("Section1/S1Page2");
        }

        public ActionResult S1Page3()
        {
            return View("Section1/S1Page3");
        }

        public ActionResult S1Page4()
        {
            return View("Section1/S1Page4");
        }

        public ActionResult S1Page5()
        {
            return View("Section1/S1Page5");
        }




        // GET: Surveys/Details/5
        public ActionResult Details(string id)
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

        public ActionResult Start()
        {
            return View();
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
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
