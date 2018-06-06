﻿using SurveyMVCBase1.DAL;
using SurveyMVCBase1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WxPayAPI;

namespace SurveyMVCBase1.Controllers
{
    public class SurveysController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Surveys
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 模式一
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetQRCode1()
        {
            object objResult = "";
            //string strProductID = Request.Form["productId"];
            //string strQRCodeStr = GetPrePayUrl(strProductID);
            string strQRCodeStr = GetPrePayUrl("123456789");


            //if (!string.IsNullOrWhiteSpace(strProductID))
            if (!string.IsNullOrWhiteSpace(strQRCodeStr))
            {
                objResult = new { result = true, str = strQRCodeStr };
            }
            else
            {
                objResult = new { result = false };
            }
            return Json(objResult);
        }
        /**
        * 生成扫描支付模式一URL
        * @param productId 商品ID
        * @return 模式一URL
        */
        public string GetPrePayUrl(string productId)
        {
            WxPayData data = new WxPayData();
            data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
            data.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("product_id", productId);//商品ID
            data.SetValue("sign", data.MakeSign());//签名
            string str = ToUrlParams(data.GetValues());//转换为URL串
            string url = "weixin://wxpay/bizpayurl?" + str;
            return url;
        }
        /**
       * 参数数组转换为url格式
       * @param map 参数名与参数值的映射表
       * @return URL字符串
       */
        private string ToUrlParams(SortedDictionary<string, object> map)
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in map)
            {
                buff += pair.Key + "=" + pair.Value + "&";
            }
            buff = buff.Trim('&');
            return buff;
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
                    if (TryUpdateModel(survey, "", new string[] { "S1Q1Answer", "S1Q2Answer", "S1Q3Answer", "S1Q4Answer", "S1Q5Answer", "S1Q6Answer", "S1Q7Answer", "S1Q8Answer", "S1Q9Answer", "S1Q10Answer", "S1Q11Answer", "S1Q12Answer", "S1Q13Answer", "S1Q14Answer", "S1Q15Answer", "S1Q16Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S1PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for Stage 1. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    Session["error"] = "Cannot update the model.";
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

            int S1Q3ScoreLocal = 0;
            int S1Q6ScoreLocal = 0;
            int S1Q10ScoreLocal = 0;
            int S1Q11ScoreLocal = 0;
            int S1Q13ScoreLocal = 0;

<<<<<<< HEAD
=======
            int S1Score = 0;

            string S1ScoreMsg = "";

>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S1Q3Answer))
                    {
                        if (survey.S1Q3Answer == "business")
                        {
                            S1Q3ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q6Answer))
                    {
                        if (survey.S1Q6Answer == "UK")
                        {
                            S1Q6ScoreLocal = 10;
                        }
                    }

<<<<<<< HEAD
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
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q10Answer))
                    {
                        if (survey.S1Q10Answer == "exp3")
                        {
=======
                    if (!string.IsNullOrEmpty(survey.S1Q10Answer))
                    {
                        if (survey.S1Q10Answer == "exp3")
                        {
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
                            S1Q10ScoreLocal = 10;
                        }
                        else if (survey.S1Q10Answer == "exp2")
                        {
                            S1Q10ScoreLocal = 5;
                        }
<<<<<<< HEAD
                        else
                        {
                            S1Q10ScoreLocal = 0;
                        }
=======
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q11Answer))
                    {
                        if (survey.S1Q11Answer == "yes")
                        {
                            S1Q11ScoreLocal = 10;
                        }
<<<<<<< HEAD
                        else
                        {
                            S1Q11ScoreLocal = 0;
                        }
=======
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
<<<<<<< HEAD
                        else
                        {
                            S1Q13ScoreLocal = 0;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S1Q3Score","S1Q6Score", "S1Q10Score", "S1Q11Score", "S1Q13Score" }))
=======
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S1Q3Score", "S1Q6Score", "S1Q10Score", "S1Q11Score", "S1Q13Score" }))
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
                    {
                        try
                        {
                            survey.S1Q3Score = S1Q3ScoreLocal;
                            survey.S1Q6Score = S1Q6ScoreLocal;
                            survey.S1Q10Score = S1Q10ScoreLocal;
                            survey.S1Q11Score = S1Q11ScoreLocal;
                            survey.S1Q13Score = S1Q13ScoreLocal;
                            db.SaveChanges();
<<<<<<< HEAD
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for Stage 1 Score. Try again, and if the problem persists, see your system administrator.");
=======
                            //return View("Section1/S1PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for S1 scores. Try again, and if the problem persists, see your system administrator.");
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }

<<<<<<< HEAD
                    S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
=======
                    S1Score = S1Q3ScoreLocal + S1Q6ScoreLocal + S1Q10ScoreLocal + S1Q11ScoreLocal + S1Q13ScoreLocal;
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723

                    if (S1Score > 50)
                    {
                        S1ScoreMsg = "您的个人背景基本符合英国移民局关于企业家移民要求，可以进入下一步评测。";
                    }
                    else if (S1Score >= 30 && S1Score <= 50)
                    {
                        S1ScoreMsg = "您的个人背景有可能符合英国移民局关于企业家移民要求，可以进入下一步评测。";
                    }
                    else if (S1Score < 30)
                    {
                        S1ScoreMsg = "您的个人背景在现阶段达不到英国对企业家移民的要求， 但是我们可以帮助您选择适合的移民方式并给出建议，请联系我们。";
                        return RedirectToAction("S1PageEnd");
                    }
<<<<<<< HEAD

                    ViewBag.Section1Score = S1Score;
                    ViewBag.Section1Message = S1ScoreMsg;

=======

                    ViewBag.Section1Score = S1Score;
                    ViewBag.Section1Message = S1ScoreMsg;

>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
<<<<<<< HEAD
            } 

=======
            }
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
                    if (TryUpdateModel(survey, "", new string[] { "S2Q1Answer", "S2Q2Answer", "S2Q3Answer", "S2Q4Answer", "S2Q5Answer", "S2Q6Answer", "S2Q7Answer", "S2Q8Answer", "S2Q9Answer", "S2Q10Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S2PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
<<<<<<< HEAD
                            ModelState.AddModelError("", "Unable to save changes for Stage 2. Try again, and if the problem persists, see your system administrator.");
=======
                            ModelState.AddModelError("", "Unable to save changes for S2Page1. Try again, and if the problem persists, see your system administrator.");
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
            int S2Q1ScoreLocal = 0;
            int S2Q2ScoreLocal = 0;
            int S2Q3ScoreLocal = 0;
            int S2Q4ScoreLocal = 0;
            int S2Q5ScoreLocal = 0;
            int S2Q6ScoreLocal = 0;
            int S2Q7ScoreLocal = 0;
            int S2Q8ScoreLocal = 0;
            int S2Q9ScoreLocal = 0;
            int S2Q10ScoreLocal = 0;

            int S1Score = 0;
            int S2Score = 0;
            string S2ScoreMsg = "";

            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (!string.IsNullOrEmpty(survey.S2Q1Answer))
                    {
                        if (survey.S2Q1Answer == "business")
<<<<<<< HEAD
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
                        if (survey.S2Q3Answer == "ielts4")
                        {
                            S2Q3ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q4Answer))
                    {
                        if (survey.S2Q4Answer == "200k")
                        {
                            S2Q4ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q5Answer))
                    {
                        if (survey.S2Q5Answer == "cantwork")
                        {
                            S2Q5ScoreLocal = 10;
                        }
                    }

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
                        if (survey.S2Q8Answer == "can")
                        {
                            S2Q8ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q9Answer))
                    {
                        if (survey.S2Q9Answer == "2employee")
                        {
=======
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
                        if (survey.S2Q3Answer == "ielts4")
                        {
                            S2Q3ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q4Answer))
                    {
                        if (survey.S2Q4Answer == "200k")
                        {
                            S2Q4ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q5Answer))
                    {
                        if (survey.S2Q5Answer == "cantwork")
                        {
                            S2Q5ScoreLocal = 10;
                        }
                    }

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
                        if (survey.S2Q8Answer == "can")
                        {
                            S2Q8ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S2Q9Answer))
                    {
                        if (survey.S2Q9Answer == "2employee")
                        {
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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

                    if (TryUpdateModel(survey, "", new string[] { "S2Q1Score", "S2Q2Score", "S2Q3Score", "S2Q4Score", "S2Q5Score", "S2Q6Score", "S2Q7Score", "S2Q8Score", "S2Q9Score", "S2Q10Score" }))
                    {
                        try
                        {
                            survey.S2Q1Score = S2Q1ScoreLocal;
                            survey.S2Q2Score = S2Q2ScoreLocal;
                            survey.S2Q3Score = S2Q3ScoreLocal;
                            survey.S2Q4Score = S2Q4ScoreLocal;
                            survey.S2Q5Score = S2Q5ScoreLocal;
                            survey.S2Q6Score = S2Q6ScoreLocal;
                            survey.S2Q7Score = S2Q7ScoreLocal;
                            survey.S2Q8Score = S2Q8ScoreLocal;
                            survey.S2Q9Score = S2Q9ScoreLocal;
                            survey.S2Q10Score = S2Q10ScoreLocal;
                            db.SaveChanges();

                            S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                            S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                            
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
                                S2ScoreMsg = "您对企业家签证了解不够，请深入阅读《商业创业宝典》后，再来参加我们的企业家评测。";
                                return RedirectToAction("S2PageEnd");
                            }

                            ViewBag.Section1ScoreTest = S1Score;
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

        // Get: S2PageEnd
        public ActionResult S2PageEnd()
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

            return View("Section2/S2PageEnd");
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
                    if (TryUpdateModel(survey, "", new string[] { "S3Q1Answer", "S3Q2Answer", "S3Q3Answer", "S3Q4Answer", "S3Q5Answer", "S3Q6Answer", "S3Q7Answer", "S3Q8Answer", "S3Q9Answer", "S3Q10Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S3PageSum");
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for Stage 3. Try again, and if the problem persists, see your system administrator.");
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
            int S3Q1ScoreLocal = 0;
            int S3Q2ScoreLocal = 0;
            int S3Q3ScoreLocal = 0;
            int S3Q4ScoreLocal = 0;
            int S3Q5ScoreLocal = 0;
            int S3Q6ScoreLocal = 0;
            int S3Q7ScoreLocal = 0;
            int S3Q8ScoreLocal = 0;
            int S3Q9ScoreLocal = 0;
            int S3Q10ScoreLocal = 0;

            int S1Score = 0;
            int S2Score = 0;
            int S3Score = 0;
            string S3ScoreMsg = "";

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
<<<<<<< HEAD
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
                        if (survey.S3Q8Answer == "2000")
                        {
                            S3Q8ScoreLocal = 10;
                        }
                    }

=======
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
                        if (survey.S3Q8Answer == "2000")
                        {
                            S3Q8ScoreLocal = 10;
                        }
                    }

>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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

                    if (TryUpdateModel(survey, "", new string[] { "S3Q1Score", "S3Q2Score", "S3Q3Score", "S3Q4Score", "S3Q5Score", "S3Q6Score", "S3Q7Score", "S3Q8Score", "S3Q9Score", "S3Q10Score" }))
                    {
                        try
                        {
                            survey.S3Q1Score = S3Q1ScoreLocal;
                            survey.S3Q2Score = S3Q2ScoreLocal;
                            survey.S3Q3Score = S3Q3ScoreLocal;
                            survey.S3Q4Score = S3Q4ScoreLocal;
                            survey.S3Q5Score = S3Q5ScoreLocal;
                            survey.S3Q6Score = S3Q6ScoreLocal;
                            survey.S3Q7Score = S3Q7ScoreLocal;
                            survey.S3Q8Score = S3Q8ScoreLocal;
                            survey.S3Q9Score = S3Q9ScoreLocal;
                            survey.S3Q10Score = S3Q10ScoreLocal;
                            db.SaveChanges();

                            S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                            S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                            S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;
                            // case - 01 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 60及以上
                            if (S3Score == 100 && S2Score == 100 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景，企业家签证知识和商业知识都非常完美，您非常适合申请英国的企业家签证。";
                            }
                            // case - 02 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 60及以上
                            else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景和商业知识都非常好，对英国的企业家签证也有一定的了解，请阅读《商业创业宝典》，深入了解企业家签证后可申请英国的企业家签证。";
                            }
                            // case - 03 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 30-50
                            else if (S3Score == 100 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对商业知识和企业家签证非常了解，在个人背景方面要有针对性的加强，可以咨询专业律师，并做好充分的准备工作后可尝试申请英国的企业家签证。";
                            }
                            // case - 04 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 30-50
                            else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对商业知识非常了解，个人背景有一些基础，对企业家签证也有一定的了解，可阅读《商业创业宝典》加深了解英国企业家签证知识后，可尝试申请企业家签证。";
                            }
                            // case - 05 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 60及以上
                            else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景和签证知识都非常好，大体的商业知识也已了解，可通过阅读《商业创业宝典》加深对英国商业的理解，在做好充分的准备工作后可申请英国的企业家签证。";
                            }
                            // case - 06 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 60及以上
                            else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景很好，对商业知识和企业家签证也有一定的了解，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                            }
                            // case - 07 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 30-50
                            else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对企业家签证非常了解，对英国商业知识也有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                            }
                            // case - 08 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 30-50
                            else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对英国商业知识、企业家签证都有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                            }
                            // case - 09 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 60及以上
                            else if (S3Score <= 50 && S2Score == 100 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景和签证知识都非常好，但缺乏英国的商业知识，请阅读《商业创业宝典》，深入了解英国商业知识后可尝试申请英国的企业家签证。";
                            }
                            // case - 10 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 60及以上
                            else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                            {
                                S3ScoreMsg = "您的个人背景很好，对企业家签证也有一定的了解，需加强商业知识，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                            }
                            // case - 11 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 30-50
                            else if (S3Score <= 50 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对企业家签证非常了解，个人背景也有一定的基础，但缺乏英国商业知识，可在阅读《商业创业宝典》加深了解后，可尝试申请企业家签证。";
                            }
                            // case - 12 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 30-50
                            else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                            {
                                S3ScoreMsg = "您对企业家签证知识有一定的了解，个人背景也有一定的基础，但英国商业知识有待加强，可通过阅读《商业创业宝典》加深了解后，再来参加我们的企业家评测。";
                            }

                            ViewBag.Section1Score = S1Score;
                            ViewBag.Section2Score = S2Score;
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

<<<<<<< HEAD
            if (Section4 == "独立创业")
            {
                return RedirectToAction("S4aPage1");
            }
            else if (Section4 == "加入创业")
=======
            if (Section4 == "英国创业项目测试 - 独立创业")
            {
                return RedirectToAction("S4aPage1");
            }
            else if (Section4 == "英国创业项目测试 - 加入创业")
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ1Answer", "S4aQ2Answer", "S4aQ3Answer", "S4aQ4Answer", "S4aQ5Answer", "S4aQ6Answer", "S4aQ7Answer", "S4aQ8Answer", "S4aQ9Answer", "S4aQ10Answer", "S4aQ11Answer", "S4aQ12Answer", "S4aQ13Answer", "S4aQ14Answer", "S4aQ15Answer", "S4aQ16Answer", "S4aQ17Answer", "S4aQ18Answer", "S4aQ19Answer", "S4aQ20Answer", "S4aQ21Answer", "S4aQ22Answer", "S4aQ23Answer", "S4aQ24Answer", "S4aQ25Answer", "S4aQ26Answer", "S4aQ27Answer", "S4aQ28Answer" }))
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
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ29Answer", "S4aQ30Answer", "S4aQ31Answer", "S4aQ32Answer", "S4aQ33Answer", "S4aQ34Answer", "S4aQ35Answer", "S4aQ36Answer", "S4aQ37Answer", "S4aQ38Answer", "S4aQ39Answer", "S4aQ40Answer", "S4aQ41Answer", "S4aQ42Answer", "S4aQ43Answer", "S4aQ44Answer", "S4aQ45Answer", "S4aQ46Answer", "S4aQ47Answer", "S4aQ48Answer", "S4aQ49Answer", "S4aQ50Answer", "S4aQ51Answer", "S4aQ52Answer", "S4aQ53Answer", "S4aQ54Answer", "S4aQ55Answer", "S4aQ56Answer", "S4aQ57Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4aPageSum");
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

        // Get: S4aPageSum
        public ActionResult S4aPageSum()
        {
            string id = "";

            int S1Score = 0;
            int S2Score = 0;
            int S3Score = 0;
            string S3ScoreMsg = "";

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
                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;
                // case - 01 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 60及以上
                if (S3Score == 100 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景，企业家签证知识和商业知识都非常完美，您非常适合申请英国的企业家签证。";
                }
                // case - 02 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和商业知识都非常好，对英国的企业家签证也有一定的了解，请阅读《商业创业宝典》，深入了解企业家签证后可申请英国的企业家签证。";
                }
                // case - 03 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score == 100 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对商业知识和企业家签证非常了解，在个人背景方面要有针对性的加强，可以咨询专业律师，并做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 04 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对商业知识非常了解，个人背景有一些基础，对企业家签证也有一定的了解，可阅读《商业创业宝典》加深了解英国企业家签证知识后，可尝试申请企业家签证。";
                }
                // case - 05 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 60及以上
                else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和签证知识都非常好，大体的商业知识也已了解，可通过阅读《商业创业宝典》加深对英国商业的理解，在做好充分的准备工作后可申请英国的企业家签证。";
                }
                // case - 06 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景很好，对商业知识和企业家签证也有一定的了解，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 07 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证非常了解，对英国商业知识也有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                }
                // case - 08 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对英国商业知识、企业家签证都有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                }
                // case - 09 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 60及以上
                else if (S3Score <= 50 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和签证知识都非常好，但缺乏英国的商业知识，请阅读《商业创业宝典》，深入了解英国商业知识后可尝试申请英国的企业家签证。";
                }
                // case - 10 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景很好，对企业家签证也有一定的了解，需加强商业知识，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 11 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score <= 50 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证非常了解，个人背景也有一定的基础，但缺乏英国商业知识，可在阅读《商业创业宝典》加深了解后，可尝试申请企业家签证。";
                }
                // case - 12 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证知识有一定的了解，个人背景也有一定的基础，但英国商业知识有待加强，可通过阅读《商业创业宝典》加深了解后，再来参加我们的企业家评测。";
                }

                ViewBag.Section1Score = S1Score;
                ViewBag.Section2Score = S2Score;
                ViewBag.Section3Score = S3Score;
                ViewBag.Section3Message = S3ScoreMsg;

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
<<<<<<< HEAD
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ1Answer", "S4bQ2Answer", "S4bQ3Answer", "S4bQ4Answer", "S4bQ5Answer", "S4bQ6Answer", "S4bQ7Answer", "S4bQ8Answer", "S4bQ9Answer", "S4bQ10Answer", "S4bQ11Answer", "S4bQ12Answer", "S4bQ13Answer", "S4bQ14Answer", "S4bQ15Answer", "S4bQ16Answer", "S4bQ17Answer", "S4bQ18Answer", "S4bQ19Answer", "S4bQ20Answer", "S4bQ21Answer", "S4bQ22Answer", "S4bQ23Answer", "S4bQ24Answer", "S4bQ25Answer", "S4bQ26Answer", "S4bQ27Answer", "S4bQ28Answer", "S4bQ29Answer" }))
=======
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ1Answer", "S4bQ2Answer", "S4bQ3Answer", "S4bQ4Answer", "S4bQ5Answer", "S4bQ6Answer", "S4bQ7Answer", "S4bQ8Answer", "S4bQ9Answer", "S4bQ10Answer", "S4bQ11Answer", "S4bQ12Answer", "S4bQ13Answer", "S4bQ14Answer", "S4bQ15Answer", "S4bQ16Answer", "S4bQ17Answer", "S4bQ18Answer", "S4bQ19Answer", "S4bQ20Answer", "S4bQ21Answer", "S4bQ22Answer", "S4bQ23Answer", "S4bQ24Answer", "S4bQ25Answer", "S4bQ26Answer", "S4bQ27Answer", "S4bQ28Answer" }))
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
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
<<<<<<< HEAD
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ30Answer", "S4bQ31Answer", "S4bQ32Answer", "S4bQ33Answer", "S4bQ34Answer", "S4bQ35Answer", "S4bQ36Answer", "S4bQ37Answer", "S4bQ38Answer", "S4bQ39Answer", "S4bQ40Answer", "S4bQ41Answer", "S4bQ42Answer", "S4bQ43Answer", "S4bQ44Answer", "S4bQ45Answer", "S4bQ46Answer", "S4bQ47Answer", "S4bQ48Answer", "S4bQ49Answer", "S4bQ50Answer", "S4bQ51Answer", "S4bQ52Answer", "S4bQ53Answer", "S4bQ54Answer", "S4bQ55Answer", "S4bQ56Answer", "S4bQ57Answer", "S4bQ58Answer", "S4bQ59Answer", "S4bQ60Answer", "S4bQ61Answer" }))
=======
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ29Answer", "S4bQ30Answer", "S4bQ31Answer", "S4bQ32Answer", "S4bQ33Answer", "S4bQ34Answer", "S4bQ35Answer", "S4bQ36Answer", "S4bQ37Answer", "S4bQ38Answer", "S4bQ39Answer", "S4bQ40Answer", "S4bQ41Answer", "S4bQ42Answer", "S4bQ43Answer", "S4bQ44Answer", "S4bQ45Answer", "S4bQ46Answer", "S4bQ47Answer", "S4bQ48Answer", "S4bQ49Answer", "S4bQ50Answer", "S4bQ51Answer", "S4bQ52Answer", "S4bQ53Answer", "S4bQ54Answer", "S4bQ55Answer", "S4bQ52Answer", "S4bQ53Answer", "S4bQ54Answer", "S4bQ55Answer", "S4bQ56Answer", "S4bQ57Answer", "S4bQ58Answer", "S4bQ59Answer", "S4bQ60Answer", "S4bQ61Answer" }))
>>>>>>> 5f128ca9a7d9be7956d86b9d517d494adf36e723
                    {
                        try
                        {
                            db.SaveChanges();
                            return RedirectToAction("S4bPageSum");
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

        // Get: S4bPageSum
        public ActionResult S4bPageSum()
        {
            string id = "";

            int S1Score = 0;
            int S2Score = 0;
            int S3Score = 0;
            string S3ScoreMsg = "";

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
                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q10Score + survey.S1Q11Score + survey.S1Q13Score;
                S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;
                // case - 01 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 60及以上
                if (S3Score == 100 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景，企业家签证知识和商业知识都非常完美，您非常适合申请英国的企业家签证。";
                }
                // case - 02 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和商业知识都非常好，对英国的企业家签证也有一定的了解，请阅读《商业创业宝典》，深入了解企业家签证后可申请英国的企业家签证。";
                }
                // case - 03 : 英国商业知识得分 100, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score == 100 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对商业知识和企业家签证非常了解，在个人背景方面要有针对性的加强，可以咨询专业律师，并做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 04 : 英国商业知识得分 100, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score == 100 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对商业知识非常了解，个人背景有一些基础，对企业家签证也有一定的了解，可阅读《商业创业宝典》加深了解英国企业家签证知识后，可尝试申请企业家签证。";
                }
                // case - 05 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 60及以上
                else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和签证知识都非常好，大体的商业知识也已了解，可通过阅读《商业创业宝典》加深对英国商业的理解，在做好充分的准备工作后可申请英国的企业家签证。";
                }
                // case - 06 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景很好，对商业知识和企业家签证也有一定的了解，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 07 : 英国商业知识得分 60-90, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score >= 60 && S3Score <= 90 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证非常了解，对英国商业知识也有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                }
                // case - 08 : 英国商业知识得分 60-90, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score >= 60 && S3Score <= 90 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对英国商业知识、企业家签证都有一定的了解，个人背景也有一定的基础，请阅读《商业创业宝典》在深入了解、提高后可尝试申请企业家签证。";
                }
                // case - 09 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 60及以上
                else if (S3Score <= 50 && S2Score == 100 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景和签证知识都非常好，但缺乏英国的商业知识，请阅读《商业创业宝典》，深入了解英国商业知识后可尝试申请英国的企业家签证。";
                }
                // case - 10 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 60及以上
                else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 60)
                {
                    S3ScoreMsg = "您的个人背景很好，对企业家签证也有一定的了解，需加强商业知识，可通过阅读《商业创业宝典》加深对英国商业和企业家签证的理解，在做好充分的准备工作后可尝试申请英国的企业家签证。";
                }
                // case - 11 : 英国商业知识得分 0-50, 签证知识得分 100, 基本信息得分 30-50
                else if (S3Score <= 50 && S2Score == 100 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证非常了解，个人背景也有一定的基础，但缺乏英国商业知识，可在阅读《商业创业宝典》加深了解后，可尝试申请企业家签证。";
                }
                // case - 12 : 英国商业知识得分 0-50, 签证知识得分 60-90, 基本信息得分 30-50
                else if (S3Score <= 50 && S2Score >= 60 && S2Score <= 90 && S1Score >= 30 && S1Score <= 50)
                {
                    S3ScoreMsg = "您对企业家签证知识有一定的了解，个人背景也有一定的基础，但英国商业知识有待加强，可通过阅读《商业创业宝典》加深了解后，再来参加我们的企业家评测。";
                }

                ViewBag.Section1Score = S1Score;
                ViewBag.Section2Score = S2Score;
                ViewBag.Section3Score = S3Score;
                ViewBag.Section3Message = S3ScoreMsg;

                return View("Section4b/S4bPageSum");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}