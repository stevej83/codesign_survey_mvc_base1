using SurveyMVCBase1.DAL;
using SurveyMVCBase1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using WxPayAPI;

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

        // Post: Continue
        [HttpPost, ActionName("Continue")]
        public ActionResult ContinuePost()
        {
            string surveyId = "";
            surveyId = Request.Form["testCodeId"];

            int S1Score = 0;
            int S2Score = 0;
            int S3Score = 0;

            Survey survey = db.Surveys.Find(surveyId);
            if (survey != null)
            {
                Session["viewKey"] = surveyId;

                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
                S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;

                if (S1Score >= 30 && S2Score < 60)
                {
                    return RedirectToAction("S2Page1");
                }
                else if (S2Score >= 60 && S3Score == 0)
                {
                    return RedirectToAction("S3Page1");
                }
                else if (S3Score > 0 && string.IsNullOrEmpty(survey.S4aQ1Answer.Trim()) && string.IsNullOrEmpty(survey.S4bQ1Answer.Trim()))
                {
                    return RedirectToAction("S3PageSum");
                }
                else if (!string.IsNullOrEmpty(survey.S4aQ1Answer.Trim()) && string.IsNullOrEmpty(survey.S4aQ34Answer.Trim()))
                {
                    Session["contS4aQ1Ans"] = survey.S4aQ1Answer;
                    Session["contS4aQ2Ans"] = survey.S4aQ2Answer;
                    Session["contS4aQ3Ans"] = survey.S4aQ3Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ4Answer))
                    {
                        Session["contS4aQ4Ans"] = survey.S4aQ4Answer;
                    }
                    else
                    {
                        Session["contS4aQ4Ans"] = null;
                    }

                    Session["contS4aQ5Ans"] = survey.S4aQ5Answer;
                    Session["contS4aQ6Ans"] = survey.S4aQ6Answer;
                    Session["contS4aQ7Ans"] = survey.S4aQ7Answer;
                    Session["contS4aQ8Ans"] = survey.S4aQ8Answer;
                    Session["contS4aQ9Ans"] = survey.S4aQ9Answer;
                    Session["contS4aQ10Ans"] = survey.S4aQ10Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ11Answer))
                    {
                        Session["contS4aQ11Ans"] = survey.S4aQ11Answer;
                    }
                    else
                    {
                        Session["contS4aQ11Ans"] = null;
                    }
                    
                    Session["contS4aQ12Ans"] = survey.S4aQ12Answer;
                    Session["contS4aQ13Ans"] = survey.S4aQ13Answer;
                    Session["contS4aQ14Ans"] = survey.S4aQ14Answer;
                    Session["contS4aQ15Ans"] = survey.S4aQ15Answer;
                    Session["contS4aQ16Ans"] = survey.S4aQ16Answer;
                    Session["contS4aQ17Ans"] = survey.S4aQ17Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ18Answer))
                    {
                        Session["contS4aQ18Ans"] = survey.S4aQ18Answer;
                    }
                    else
                    {
                        Session["contS4aQ18Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4aQ19Answer))
                    {
                        Session["contS4aQ19Ans"] = survey.S4aQ19Answer;
                    }
                    else
                    {
                        Session["contS4aQ19Ans"] = null;
                    }

                    Session["contS4aQ20Ans"] = survey.S4aQ20Answer;
                    Session["contS4aQ21Ans"] = survey.S4aQ21Answer;
                    Session["contS4aQ22Ans"] = survey.S4aQ22Answer;
                    Session["contS4aQ23Ans"] = survey.S4aQ23Answer;
                    Session["contS4aQ24Ans"] = survey.S4aQ24Answer;
                    Session["contS4aQ25Ans"] = survey.S4aQ25Answer;
                    Session["contS4aQ26Ans"] = survey.S4aQ26Answer;
                    Session["contS4aQ27Ans"] = survey.S4aQ27Answer;
                    Session["contS4aQ28Ans"] = survey.S4aQ28Answer;
                    Session["contS4aQ29Ans"] = survey.S4aQ29Answer;
                    Session["contS4aQ30Ans"] = survey.S4aQ30Answer;
                    Session["contS4aQ31Ans"] = survey.S4aQ31Answer;
                    Session["contS4aQ32Ans"] = survey.S4aQ32Answer;
                    Session["contS4aQ33Ans"] = survey.S4aQ33Answer;
                    return RedirectToAction("S4aPage1");
                }
                else if (!string.IsNullOrEmpty(survey.S4aQ34Answer))
                {
                    Session["contS4aQ34Ans"] = survey.S4aQ34Answer;
                    Session["contS4aQ35Ans"] = survey.S4aQ35Answer;
                    Session["contS4aQ36Ans"] = survey.S4aQ36Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ37Answer))
                    {
                        Session["contS4aQ37Ans"] = survey.S4aQ37Answer;
                    }
                    else
                    {
                        Session["contS4aQ37Ans"] = null;
                    }


                    Session["contS4aQ38Ans"] = survey.S4aQ38Answer;
                    Session["contS4aQ39Ans"] = survey.S4aQ39Answer;
                    Session["contS4aQ40Ans"] = survey.S4aQ40Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ41Answer))
                    {
                        Session["contS4aQ41Ans"] = survey.S4aQ41Answer;
                    }
                    else
                    {
                        Session["contS4aQ41Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4aQ42Answer))
                    {
                        Session["contS4aQ42Ans"] = survey.S4aQ42Answer;
                    }
                    else
                    {
                        Session["contS4aQ42Ans"] = null;
                    }

                    Session["contS4aQ43Ans"] = survey.S4aQ43Answer;
                    Session["contS4aQ44Ans"] = survey.S4aQ44Answer;
 
                    if (!string.IsNullOrEmpty(survey.S4aQ45Answer))
                    {
                        Session["contS4aQ45Ans"] = survey.S4aQ45Answer;
                    }
                    else
                    {
                        Session["contS4aQ45Ans"] = null;
                    }

                    Session["contS4aQ46Ans"] = survey.S4aQ46Answer;
                    Session["contS4aQ47Ans"] = survey.S4aQ47Answer;
                    Session["contS4aQ48Ans"] = survey.S4aQ48Answer;
                    Session["contS4aQ49Ans"] = survey.S4aQ49Answer;
                    Session["contS4aQ50Ans"] = survey.S4aQ50Answer;
                    
                    if (!string.IsNullOrEmpty(survey.S4aQ51Answer))
                    {
                        Session["contS4aQ51Ans"] = survey.S4aQ51Answer;
                    }
                    else
                    {
                        Session["contS4aQ51Ans"] = null;
                    }

                    Session["contS4aQ52Ans"] = survey.S4aQ52Answer;
                    Session["contS4aQ53Ans"] = survey.S4aQ53Answer;
                    
                    if (!string.IsNullOrEmpty(survey.S4aQ54Answer))
                    {
                        Session["contS4aQ54Ans"] = survey.S4aQ54Answer;
                    }
                    else
                    {
                        Session["contS4aQ54Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4aQ55Answer))
                    {
                        Session["contS4aQ55Ans"] = survey.S4aQ55Answer;
                    }
                    else
                    {
                        Session["contS4aQ55Ans"] = null;
                    }

                    Session["contS4aQ56Ans"] = survey.S4aQ56Answer;
                    Session["contS4aQ57Ans"] = survey.S4aQ57Answer;
                    Session["contS4aQ58Ans"] = survey.S4aQ58Answer;
                    Session["contS4aQ59Ans"] = survey.S4aQ59Answer;
                    Session["contS4aQ60Ans"] = survey.S4aQ60Answer;

                    if (!string.IsNullOrEmpty(survey.S4aQ61Answer))
                    {
                        Session["contS4aQ61Ans"] = survey.S4aQ61Answer;
                    }
                    else
                    {
                        Session["contS4aQ61Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4aQ62Answer))
                    {
                        Session["contS4aQ62Ans"] = survey.S4aQ62Answer;
                    }
                    else
                    {
                        Session["contS4aQ62Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4aQ63Answer))
                    {
                        Session["contS4aQ63Ans"] = survey.S4aQ63Answer;
                    }
                    else
                    {
                        Session["contS4aQ63Ans"] = null;
                    }

                    return RedirectToAction("S4aPage2");
                }
                else if (!string.IsNullOrEmpty(survey.S4bQ1Answer) && string.IsNullOrEmpty(survey.S4bQ30Answer))
                {
                    Session["contS4bQ1Ans"] = survey.S4bQ1Answer;
                    Session["contS4bQ2Ans"] = survey.S4bQ2Answer;
                    Session["contS4bQ3Ans"] = survey.S4bQ3Answer;
                    Session["contS4bQ4Ans"] = survey.S4bQ4Answer;
                    Session["contS4bQ5Ans"] = survey.S4bQ5Answer;
                    Session["contS4bQ6Ans"] = survey.S4bQ6Answer;
                    Session["contS4bQ7Ans"] = survey.S4bQ7Answer;
                    Session["contS4bQ8Ans"] = survey.S4bQ8Answer;
                    Session["contS4bQ9Ans"] = survey.S4bQ9Answer;
                    Session["contS4bQ10Ans"] = survey.S4bQ10Answer;
                    Session["contS4bQ11Ans"] = survey.S4bQ11Answer;
                    Session["contS4bQ12Ans"] = survey.S4bQ12Answer;
                    Session["contS4bQ13Ans"] = survey.S4bQ13Answer;
                    Session["contS4bQ14Ans"] = survey.S4bQ14Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ15Answer))
                    {
                        Session["contS4bQ15Ans"] = survey.S4bQ15Answer;
                    }
                    else
                    {
                        Session["contS4bQ15Ans"] = null;
                    }

                    Session["contS4bQ16Ans"] = survey.S4bQ16Answer;
                    Session["contS4bQ17Ans"] = survey.S4bQ17Answer;
                    Session["contS4bQ18Ans"] = survey.S4bQ18Answer;
                    Session["contS4bQ19Ans"] = survey.S4bQ19Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ20Answer))
                    {
                        Session["contS4bQ20Ans"] = survey.S4bQ20Answer;
                    }
                    else
                    {
                        Session["contS4bQ20Ans"] = null;
                    }

                    Session["contS4bQ21Ans"] = survey.S4bQ21Answer;
                    Session["contS4bQ22Ans"] = survey.S4bQ22Answer;
                    Session["contS4bQ23Ans"] = survey.S4bQ23Answer;
                    Session["contS4bQ24Ans"] = survey.S4bQ24Answer;
                    Session["contS4bQ25Ans"] = survey.S4bQ25Answer;
                    Session["contS4bQ26Ans"] = survey.S4bQ26Answer;
                    Session["contS4bQ27Ans"] = survey.S4bQ27Answer;
                    Session["contS4bQ28Ans"] = survey.S4bQ28Answer;
                    Session["contS4bQ29Ans"] = survey.S4bQ29Answer;

                    return RedirectToAction("S4bPage1");
                }
                else if (!string.IsNullOrEmpty(survey.S4bQ30Answer))
                {
                    if (!string.IsNullOrEmpty(survey.S4bQ30Answer))
                    {
                        Session["contS4bQ30Ans"] = survey.S4bQ30Answer;
                    }
                    else
                    {
                        Session["contS4bQ30Ans"] = null;
                    }

                    Session["contS4bQ31Ans"] = survey.S4bQ31Answer;
                    Session["contS4bQ32Ans"] = survey.S4bQ32Answer;
                    Session["contS4bQ33Ans"] = survey.S4bQ33Answer;
                    Session["contS4bQ34Ans"] = survey.S4bQ34Answer;
                    Session["contS4bQ35Ans"] = survey.S4bQ35Answer;
                    Session["contS4bQ36Ans"] = survey.S4bQ36Answer;
                    Session["contS4bQ37Ans"] = survey.S4bQ37Answer;
                    Session["contS4bQ38Ans"] = survey.S4bQ38Answer;
                    Session["contS4bQ39Ans"] = survey.S4bQ39Answer;
                    Session["contS4bQ40Ans"] = survey.S4bQ40Answer;
                    Session["contS4bQ41Ans"] = survey.S4bQ41Answer;
                    Session["contS4bQ42Ans"] = survey.S4bQ42Answer;
                    Session["contS4bQ43Ans"] = survey.S4bQ43Answer;
                    Session["contS4bQ44Ans"] = survey.S4bQ44Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ45Answer))
                    {
                        Session["contS4bQ45Ans"] = survey.S4bQ45Answer;
                    }
                    else
                    {
                        Session["contS4bQ45Ans"] = null;
                    }

                    Session["contS4bQ46Ans"] = survey.S4bQ46Answer;
                    Session["contS4bQ47Ans"] = survey.S4bQ47Answer;
                    Session["contS4bQ48Ans"] = survey.S4bQ48Answer;
                    Session["contS4bQ49Ans"] = survey.S4bQ49Answer;
                    Session["contS4bQ50Ans"] = survey.S4bQ50Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ51Answer))
                    {
                        Session["contS4bQ51Ans"] = survey.S4bQ51Answer;
                    }
                    else
                    {
                        Session["contS4bQ51Ans"] = null;
                    }

                    Session["contS4bQ52Ans"] = survey.S4bQ52Answer;
                    Session["contS4bQ53Ans"] = survey.S4bQ53Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ54Answer))
                    {
                        Session["contS4bQ54Ans"] = survey.S4bQ54Answer;
                    }
                    else
                    {
                        Session["contS4bQ54Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4bQ55Answer))
                    {
                        Session["contS4bQ55Ans"] = survey.S4bQ55Answer;
                    }
                    else
                    {
                        Session["contS4bQ55Ans"] = null;
                    }

                    Session["contS4bQ56Ans"] = survey.S4bQ56Answer;
                    Session["contS4bQ57Ans"] = survey.S4bQ57Answer;
                    Session["contS4bQ58Ans"] = survey.S4bQ58Answer;
                    Session["contS4bQ59Ans"] = survey.S4bQ59Answer;
                    Session["contS4bQ60Ans"] = survey.S4bQ60Answer;

                    if (!string.IsNullOrEmpty(survey.S4bQ61Answer))
                    {
                        Session["contS4bQ61Ans"] = survey.S4bQ61Answer;
                    }
                    else
                    {
                        Session["contS4bQ61Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4bQ62Answer))
                    {
                        Session["contS4bQ62Ans"] = survey.S4bQ62Answer;
                    }
                    else
                    {
                        Session["contS4bQ62Ans"] = null;
                    }

                    if (!string.IsNullOrEmpty(survey.S4bQ63Answer))
                    {
                        Session["contS4bQ63Ans"] = survey.S4bQ63Answer;
                    }
                    else
                    {
                        Session["contS4bQ63Ans"] = null;
                    }
                    
                    return RedirectToAction("S4bPage2");
                }
            }

            Session["error"] = "您的测试码无效，请重新测试。";
            return View("Error");
        }

        public class EmailBusiness
        {
            public MailAddress to { get; set; }
            public MailAddress from { get; set; }
            public string sub { get; set; }
            public string body { get; set; }
            public string ToAdmin()
            {
                string feedback = "";
                EmailBusiness me = new EmailBusiness();

                var m = new MailMessage()
                {

                    Subject = sub,
                    Body = body,
                    IsBodyHtml = true
                };
                to = new MailAddress("jinyue306@gmail.com", "Administrator");
                m.To.Add(to);
                m.From = new MailAddress(from.ToString());
                m.Sender = to;


                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.ukvisatest.com",
                    Port = 25,
                    Credentials = new NetworkCredential("", "Dut930611jk"),
                    EnableSsl = true
                };

                try
                {
                    smtp.Send(m);
                    feedback = "Message sent to insurance";
                }
                catch (Exception e)
                {
                    feedback = "Message not sent retry" + e.Message;
                }
                return feedback;
            }

        }
        /// <summary>
        /// 模式一
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult GetQRCode1()
        //{
        //object objResult = "";
        //string strProductID = Request.Form["productId"];
        //string strQRCodeStr = GetPrePayUrl(strProductID);
        //string strQRCodeStr = GetPrePayUrl("123456789");


        //if (!string.IsNullOrWhiteSpace(strProductID))
        //if (!string.IsNullOrWhiteSpace(strQRCodeStr))
        //{
        //objResult = new { result = true, str = strQRCodeStr };
        //}
        //else
        //{
        //objResult = new { result = false };
        //}
        //return Json(objResult);
        //}
        /**
        * 生成扫描支付模式一URL
        * @param productId 商品ID
        * @return 模式一URL
        */
        //public string GetPrePayUrl(string productId)
        //{
        //WxPayData data = new WxPayData();
        //data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
        //data.SetValue("mch_id", WxPayConfig.MCHID);//商户号
        //data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
        //data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
        //data.SetValue("product_id", productId);//商品ID
        //data.SetValue("sign", data.MakeSign());//签名
        //string str = ToUrlParams(data.GetValues());//转换为URL串
        //string url = "weixin://wxpay/bizpayurl?" + str;
        //return url;
        //}
        /**
       * 参数数组转换为url格式
       * @param map 参数名与参数值的映射表
       * @return URL字符串
       */
        //private string ToUrlParams(SortedDictionary<string, object> map)
        //{
        //string buff = "";
        //foreach (KeyValuePair<string, object> pair in map)
        //{
        //buff += pair.Key + "=" + pair.Value + "&";
        //}
        //buff = buff.Trim('&');
        //return buff;
        //}

        // redirect page to SectionSaved
        public ActionResult SectionSaved()
        {
            ViewBag.UserTestCode = Session["viewKey"].ToString();
            return View();
        }

        // redirect section4a from section2 to section1
        public ActionResult SectionBack4a()
        {
            string surveyId = "";
            surveyId = Session["viewKey"].ToString();

            Survey survey = db.Surveys.Find(surveyId);
            if (survey != null)
            {
                Session["contS4aQ1Ans"] = survey.S4aQ1Answer;
                Session["contS4aQ2Ans"] = survey.S4aQ2Answer;
                Session["contS4aQ3Ans"] = survey.S4aQ3Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ4Answer))
                {
                    Session["contS4aQ4Ans"] = survey.S4aQ4Answer;
                }
                else
                {
                    Session["contS4aQ4Ans"] = null;
                }

                Session["contS4aQ5Ans"] = survey.S4aQ5Answer;
                Session["contS4aQ6Ans"] = survey.S4aQ6Answer;
                Session["contS4aQ7Ans"] = survey.S4aQ7Answer;
                Session["contS4aQ8Ans"] = survey.S4aQ8Answer;
                Session["contS4aQ9Ans"] = survey.S4aQ9Answer;
                Session["contS4aQ10Ans"] = survey.S4aQ10Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ11Answer))
                {
                    Session["contS4aQ11Ans"] = survey.S4aQ11Answer;
                }
                else
                {
                    Session["contS4aQ11Ans"] = null;
                }

                Session["contS4aQ12Ans"] = survey.S4aQ12Answer;
                Session["contS4aQ13Ans"] = survey.S4aQ13Answer;
                Session["contS4aQ14Ans"] = survey.S4aQ14Answer;
                Session["contS4aQ15Ans"] = survey.S4aQ15Answer;
                Session["contS4aQ16Ans"] = survey.S4aQ16Answer;
                Session["contS4aQ17Ans"] = survey.S4aQ17Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ18Answer))
                {
                    Session["contS4aQ18Ans"] = survey.S4aQ18Answer;
                }
                else
                {
                    Session["contS4aQ18Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4aQ19Answer))
                {
                    Session["contS4aQ19Ans"] = survey.S4aQ19Answer;
                }
                else
                {
                    Session["contS4aQ19Ans"] = null;
                }

                Session["contS4aQ20Ans"] = survey.S4aQ20Answer;
                Session["contS4aQ21Ans"] = survey.S4aQ21Answer;
                Session["contS4aQ22Ans"] = survey.S4aQ22Answer;
                Session["contS4aQ23Ans"] = survey.S4aQ23Answer;
                Session["contS4aQ24Ans"] = survey.S4aQ24Answer;
                Session["contS4aQ25Ans"] = survey.S4aQ25Answer;
                Session["contS4aQ26Ans"] = survey.S4aQ26Answer;
                Session["contS4aQ27Ans"] = survey.S4aQ27Answer;
                Session["contS4aQ28Ans"] = survey.S4aQ28Answer;
                Session["contS4aQ29Ans"] = survey.S4aQ29Answer;
                Session["contS4aQ30Ans"] = survey.S4aQ30Answer;
                Session["contS4aQ31Ans"] = survey.S4aQ31Answer;
                Session["contS4aQ32Ans"] = survey.S4aQ32Answer;
                Session["contS4aQ33Ans"] = survey.S4aQ33Answer;
                Session["contS4aQ34Ans"] = survey.S4aQ34Answer;
                Session["contS4aQ35Ans"] = survey.S4aQ35Answer;
                Session["contS4aQ36Ans"] = survey.S4aQ36Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ37Answer))
                {
                    Session["contS4aQ37Ans"] = survey.S4aQ37Answer;
                }
                else
                {
                    Session["contS4aQ37Ans"] = null;
                }


                Session["contS4aQ38Ans"] = survey.S4aQ38Answer;
                Session["contS4aQ39Ans"] = survey.S4aQ39Answer;
                Session["contS4aQ40Ans"] = survey.S4aQ40Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ41Answer))
                {
                    Session["contS4aQ41Ans"] = survey.S4aQ41Answer;
                }
                else
                {
                    Session["contS4aQ41Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4aQ42Answer))
                {
                    Session["contS4aQ42Ans"] = survey.S4aQ42Answer;
                }
                else
                {
                    Session["contS4aQ42Ans"] = null;
                }

                Session["contS4aQ43Ans"] = survey.S4aQ43Answer;
                Session["contS4aQ44Ans"] = survey.S4aQ44Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ45Answer))
                {
                    Session["contS4aQ45Ans"] = survey.S4aQ45Answer;
                }
                else
                {
                    Session["contS4aQ45Ans"] = null;
                }

                Session["contS4aQ46Ans"] = survey.S4aQ46Answer;
                Session["contS4aQ47Ans"] = survey.S4aQ47Answer;
                Session["contS4aQ48Ans"] = survey.S4aQ48Answer;
                Session["contS4aQ49Ans"] = survey.S4aQ49Answer;
                Session["contS4aQ50Ans"] = survey.S4aQ50Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ51Answer))
                {
                    Session["contS4aQ51Ans"] = survey.S4aQ51Answer;
                }
                else
                {
                    Session["contS4aQ51Ans"] = null;
                }

                Session["contS4aQ52Ans"] = survey.S4aQ52Answer;
                Session["contS4aQ53Ans"] = survey.S4aQ53Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ54Answer))
                {
                    Session["contS4aQ54Ans"] = survey.S4aQ54Answer;
                }
                else
                {
                    Session["contS4aQ54Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4aQ55Answer))
                {
                    Session["contS4aQ55Ans"] = survey.S4aQ55Answer;
                }
                else
                {
                    Session["contS4aQ55Ans"] = null;
                }

                Session["contS4aQ56Ans"] = survey.S4aQ56Answer;
                Session["contS4aQ57Ans"] = survey.S4aQ57Answer;
                Session["contS4aQ58Ans"] = survey.S4aQ58Answer;
                Session["contS4aQ59Ans"] = survey.S4aQ59Answer;
                Session["contS4aQ60Ans"] = survey.S4aQ60Answer;

                if (!string.IsNullOrEmpty(survey.S4aQ61Answer))
                {
                    Session["contS4aQ61Ans"] = survey.S4aQ61Answer;
                }
                else
                {
                    Session["contS4aQ61Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4aQ62Answer))
                {
                    Session["contS4aQ62Ans"] = survey.S4aQ62Answer;
                }
                else
                {
                    Session["contS4aQ62Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4aQ63Answer))
                {
                    Session["contS4aQ63Ans"] = survey.S4aQ63Answer;
                }
                else
                {
                    Session["contS4aQ63Ans"] = null;
                }
            }

            return View("Section4a/S4aPage1");
        }

        // redirect section4b from section2 to section1
        public ActionResult SectionBack4b()
        {
            string surveyId = "";
            surveyId = Session["viewKey"].ToString();

            Survey survey = db.Surveys.Find(surveyId);
            if (survey != null)
            {
                Session["contS4bQ1Ans"] = survey.S4bQ1Answer;
                Session["contS4bQ2Ans"] = survey.S4bQ2Answer;
                Session["contS4bQ3Ans"] = survey.S4bQ3Answer;
                Session["contS4bQ4Ans"] = survey.S4bQ4Answer;
                Session["contS4bQ5Ans"] = survey.S4bQ5Answer;
                Session["contS4bQ6Ans"] = survey.S4bQ6Answer;
                Session["contS4bQ7Ans"] = survey.S4bQ7Answer;
                Session["contS4bQ8Ans"] = survey.S4bQ8Answer;
                Session["contS4bQ9Ans"] = survey.S4bQ9Answer;
                Session["contS4bQ10Ans"] = survey.S4bQ10Answer;
                Session["contS4bQ11Ans"] = survey.S4bQ11Answer;
                Session["contS4bQ12Ans"] = survey.S4bQ12Answer;
                Session["contS4bQ13Ans"] = survey.S4bQ13Answer;
                Session["contS4bQ14Ans"] = survey.S4bQ14Answer;
                
                if (!string.IsNullOrEmpty(survey.S4bQ15Answer))
                {
                    Session["contS4bQ15Ans"] = survey.S4bQ15Answer;
                }
                else
                {
                    Session["contS4bQ15Ans"] = null;
                }

                Session["contS4bQ16Ans"] = survey.S4bQ16Answer;
                Session["contS4bQ17Ans"] = survey.S4bQ17Answer;
                Session["contS4bQ18Ans"] = survey.S4bQ18Answer;
                Session["contS4bQ19Ans"] = survey.S4bQ19Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ20Answer))
                {
                    Session["contS4bQ20Ans"] = survey.S4bQ20Answer;
                }
                else
                {
                    Session["contS4bQ20Ans"] = null;
                }

                Session["contS4bQ21Ans"] = survey.S4bQ21Answer;
                Session["contS4bQ22Ans"] = survey.S4bQ22Answer;
                Session["contS4bQ23Ans"] = survey.S4bQ23Answer;
                Session["contS4bQ24Ans"] = survey.S4bQ24Answer;
                Session["contS4bQ25Ans"] = survey.S4bQ25Answer;
                Session["contS4bQ26Ans"] = survey.S4bQ26Answer;
                Session["contS4bQ27Ans"] = survey.S4bQ27Answer;
                Session["contS4bQ28Ans"] = survey.S4bQ28Answer;
                Session["contS4bQ29Ans"] = survey.S4bQ29Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ30Answer))
                {
                    Session["contS4bQ30Ans"] = survey.S4bQ30Answer;
                }
                else
                {
                    Session["contS4bQ30Ans"] = null;
                }

                Session["contS4bQ31Ans"] = survey.S4bQ31Answer;
                Session["contS4bQ32Ans"] = survey.S4bQ32Answer;
                Session["contS4bQ33Ans"] = survey.S4bQ33Answer;
                Session["contS4bQ34Ans"] = survey.S4bQ34Answer;
                Session["contS4bQ35Ans"] = survey.S4bQ35Answer;
                Session["contS4bQ36Ans"] = survey.S4bQ36Answer;
                Session["contS4bQ37Ans"] = survey.S4bQ37Answer;
                Session["contS4bQ38Ans"] = survey.S4bQ38Answer;
                Session["contS4bQ39Ans"] = survey.S4bQ39Answer;
                Session["contS4bQ40Ans"] = survey.S4bQ40Answer;
                Session["contS4bQ41Ans"] = survey.S4bQ41Answer;
                Session["contS4bQ42Ans"] = survey.S4bQ42Answer;
                Session["contS4bQ43Ans"] = survey.S4bQ43Answer;
                Session["contS4bQ44Ans"] = survey.S4bQ44Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ45Answer))
                {
                    Session["contS4bQ45Ans"] = survey.S4bQ45Answer;
                }
                else
                {
                    Session["contS4bQ45Ans"] = null;
                }

                Session["contS4bQ46Ans"] = survey.S4bQ46Answer;
                Session["contS4bQ47Ans"] = survey.S4bQ47Answer;
                Session["contS4bQ48Ans"] = survey.S4bQ48Answer;
                Session["contS4bQ49Ans"] = survey.S4bQ49Answer;
                Session["contS4bQ50Ans"] = survey.S4bQ50Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ51Answer))
                {
                    Session["contS4bQ51Ans"] = survey.S4bQ51Answer;
                }
                else
                {
                    Session["contS4bQ51Ans"] = null;
                }

                Session["contS4bQ52Ans"] = survey.S4bQ52Answer;
                Session["contS4bQ53Ans"] = survey.S4bQ53Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ54Answer))
                {
                    Session["contS4bQ54Ans"] = survey.S4bQ54Answer;
                }
                else
                {
                    Session["contS4bQ54Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4bQ55Answer))
                {
                    Session["contS4bQ55Ans"] = survey.S4bQ55Answer;
                }
                else
                {
                    Session["contS4bQ55Ans"] = null;
                }

                Session["contS4bQ56Ans"] = survey.S4bQ56Answer;
                Session["contS4bQ57Ans"] = survey.S4bQ57Answer;
                Session["contS4bQ58Ans"] = survey.S4bQ58Answer;
                Session["contS4bQ59Ans"] = survey.S4bQ59Answer;
                Session["contS4bQ60Ans"] = survey.S4bQ60Answer;

                if (!string.IsNullOrEmpty(survey.S4bQ61Answer))
                {
                    Session["contS4bQ61Ans"] = survey.S4bQ61Answer;
                }
                else
                {
                    Session["contS4bQ61Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4bQ62Answer))
                {
                    Session["contS4bQ62Ans"] = survey.S4bQ62Answer;
                }
                else
                {
                    Session["contS4bQ62Ans"] = null;
                }

                if (!string.IsNullOrEmpty(survey.S4bQ63Answer))
                {
                    Session["contS4bQ63Ans"] = survey.S4bQ63Answer;
                }
                else
                {
                    Session["contS4bQ63Ans"] = null;
                }
            }

            return View("Section4b/S4bPage1");
        }

        // redirect page to Workflow
        public ActionResult Workflow()
        {
            //Survey survyCreate = new Survey();
            //survyCreate.SurveyID = Guid.NewGuid().ToString();
            Session.RemoveAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Workflow([Bind(
            Include = "SurveyID,StartTime,S1Q1Answer,S1Q2Answer,S1Q3Answer,S1Q3Score,S1Q4Answer,S1Q5Answer,S1Q6Answer,S1Q6Score,S1Q7Answer,S1Q8Answer," +
            "S1Q9Answer,S1Q10Answer,S1Q10Score,S1Q11Answer,S1Q11Score,S1Q12Answer,S1Q13Answer,S1Q13Score,S1Q14Answer,S1Q15Answer,S1Q16Answer,S1Q17Answer,S1Q18Answer,S1Q19Answer," +
            "S2Q1Answer,S2Q1Score,S2Q2Answer,S2Q2Score,S2Q3Answer,S2Q3Score,S2Q4Answer,S2Q4Score,S2Q5Answer,S2Q5Score,S2Q6Answer,S2Q6Score," +
            "S2Q7Answer,S2Q7Score,S2Q8Answer,S2Q8Score,S2Q9Answer,S2Q9Score,S2Q10Answer,S2Q10Score," +
            "S3Q1Answer,S3Q1Score,S3Q2Answer,S3Q2Score,S3Q3Answer,S3Q3Score,S3Q4Answer,S3Q4Score,S3Q5Answer,S3Q5Score,S3Q6Answer,S3Q6Score," +
            "S3Q7Answer,S3Q7Score,S3Q8Answer,S3Q8Score,S3Q9Answer,S3Q9Score,S3Q10Answer,S3Q10Score," +
            "S4aQ1Answer,S4aQ2Answer,S4aQ3Answer,S4aQ4Answer,S4aQ5Answer,S4aQ6Answer,S4aQ7Answer,S4aQ8Answer,S4aQ9Answer,S4aQ10Answer," +
            "S4aQ11Answer,S4aQ12Answer,S4aQ13Answer,S4aQ14Answer,S4aQ15Answer,S4aQ16Answer,S4aQ17Answer,S4aQ18Answer,S4aQ19Answer,S4aQ20Answer," +
            "S4aQ21Answer,S4aQ22Answer,S4aQ23Answer,S4aQ24Answer,S4aQ25Answer,S4aQ26Answer,S4aQ27Answer,S4aQ28Answer,S4aQ29Answer,S4aQ30Answer," +
            "S4aQ31Answer,S4aQ32Answer,S4aQ33Answer,S4aQ34Answer,S4aQ35Answer,S4aQ36Answer,S4aQ37Answer,S4aQ38Answer,S4aQ39Answer,S4aQ40Answer," +
            "S4aQ41Answer,S4aQ42Answer,S4aQ43Answer,S4aQ44Answer,S4aQ45Answer,S4aQ46Answer,S4aQ47Answer,S4aQ48Answer,S4aQ49Answer,S4aQ50Answer," +
            "S4aQ51Answer,S4aQ52Answer,S4aQ53Answer,S4aQ54Answer,S4aQ55Answer,S4aQ56Answer,S4aQ57Answer,S4aQ58Answer,S4aQ59Answer,S4aQ60Answer,S4aQ61Answer,S4aQ62Answer,S4aQ63Answer," +
            "S4bQ1Answer,S4bQ2Answer,S4bQ3Answer,S4bQ4Answer,S4bQ5Answer,S4bQ6Answer,S4bQ7Answer,S4bQ8Answer,S4bQ9Answer,S4bQ10Answer," +
            "S4bQ11Answer,S4bQ12Answer,S4bQ13Answer,S4bQ14Answer,S4bQ15Answer,S4bQ16Answer,S4bQ17Answer,S4bQ18Answer,S4bQ19Answer,S4bQ20Answer," +
            "S4bQ21Answer,S4bQ22Answer,S4bQ23Answer,S4bQ24Answer,S4bQ25Answer,S4bQ26Answer,S4bQ27Answer,S4bQ28Answer,S4bQ29Answer,S4bQ30Answer," +
            "S4bQ31Answer,S4bQ32Answer,S4bQ33Answer,S4bQ34Answer,S4bQ35Answer,S4bQ36Answer,S4bQ37Answer,S4bQ38Answer,S4bQ39Answer,S4bQ40Answer," +
            "S4bQ41Answer,S4bQ42Answer,S4bQ43Answer,S4bQ44Answer,S4bQ45Answer,S4bQ46Answer,S4bQ47Answer,S4bQ48Answer,S4bQ49Answer,S4bQ50Answer," +
            "S4bQ51Answer,S4bQ52Answer,S4bQ53Answer,S4bQ54Answer,S4bQ55Answer,S4bQ56Answer,S4bQ57Answer,S4bQ58Answer,S4bQ59Answer,S4bQ60Answer," +
            "S4bQ61Answer,S4bQ62Answer,S4bQ63Answer")] Survey survey)
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
                    S1Q9Score = 0,
                    S1Q10Answer = "",
                    S1Q11Answer = "",
                    S1Q12Answer = "",
                    S1Q13Answer = "",
                    S1Q13Score = 0,
                    S1Q14Answer = "",
                    S1Q14Score = 0,
                    S1Q15Answer = "",
                    S1Q16Answer = "",
                    S1Q16Score = 0,
                    S1Q17Answer = "",
                    S1Q18Answer = "",
                    S1Q19Answer = "",
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
                    S4aQ58Answer = "",
                    S4aQ59Answer = "",
                    S4aQ60Answer = "",
                    S4aQ61Answer = "",
                    S4aQ62Answer = "",
                    S4aQ63Answer = "",
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
                    S4bQ61Answer = "",
                    S4bQ62Answer = "",
                    S4bQ63Answer = ""
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

        // Get: Admin check submitted data
        public ActionResult Data()
        {
            string surveyId = "";
            surveyId = Request.QueryString["surveyid"];
            
            int S1Score = 0;
            int S2Score = 0;
            int S3Score = 0;

            string S4Helper = "";

            Survey survey = db.Surveys.Find(surveyId);
            if (survey != null)
            {
                string dateString = survey.StartTime;
                if (!string.IsNullOrEmpty(dateString))
                {
                    //ViewBag.testDate = dateString.Substring(0, 3) + "-" + dateString.Substring(4, 5) + "-" + dateString.Substring(6, 7) + " / " + dateString.Substring(8, 9) + ":" + dateString.Substring(10, 11);
                    //ViewBag.testDate = "测试时间被记录";
                    StringBuilder sb = new StringBuilder();
                    sb.Append(dateString.Substring(0,8));
                    ViewBag.testDate = sb;
                }
                else
                {
                    ViewBag.testDate = "测试时间没有被记录";
                }
                
                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
                S2Score = survey.S2Q1Score + survey.S2Q2Score + survey.S2Q3Score + survey.S2Q4Score + survey.S2Q5Score + survey.S2Q6Score + survey.S2Q7Score + survey.S2Q8Score + survey.S2Q9Score + survey.S2Q10Score;
                S3Score = survey.S3Q1Score + survey.S3Q2Score + survey.S3Q3Score + survey.S3Q4Score + survey.S3Q5Score + survey.S3Q6Score + survey.S3Q7Score + survey.S3Q8Score + survey.S3Q9Score + survey.S3Q10Score;

                // Section Score 1 - 3
                ViewBag.dataS1Score = S1Score;
                ViewBag.dataS2Score = S2Score;
                ViewBag.dataS3Score = S3Score;

                // Section 1
                string dataS1Q3Ans = "";
                string dataS1Q6Ans = "";
                string dataS1Q9Ans = "";
                string dataS1Q13Ans = "";
                string dataS1Q14Ans = "";
                string dataS1Q16Ans = "";

                ViewBag.dataS1Q1Answer = survey.S1Q1Answer;
                ViewBag.dataS1Q2Answer = survey.S1Q2Answer;

                if (survey.S1Q3Answer == "UK")
                {
                    dataS1Q3Ans = "英国";
                }
                else if (survey.S1Q3Answer == "China" || survey.S1Q3Answer == "Other")
                {
                    dataS1Q3Ans = "中国或其它国家";
                }
                else
                {
                    dataS1Q3Ans = "无学士学历";
                }
                ViewBag.dataS1Q3Answer = dataS1Q3Ans;

                ViewBag.dataS1Q4Answer = survey.S1Q4Answer;
                ViewBag.dataS1Q5Answer = survey.S1Q5Answer;

                if (survey.S1Q6Answer == "UK")
                {
                    dataS1Q6Ans = "英国";
                }
                else if (survey.S1Q6Answer == "China" || survey.S1Q6Answer == "Other")
                {
                    dataS1Q6Ans = "中国或其它国家";
                }
                else
                {
                    dataS1Q6Ans = "无硕士学历";
                }

                ViewBag.dataS1Q6Answer = dataS1Q6Ans;

                ViewBag.dataS1Q7Answer = survey.S1Q7Answer;
                ViewBag.dataS1Q8Answer = survey.S1Q8Answer;

                if (survey.S1Q9Answer == "UK")
                {
                    dataS1Q9Ans = "英国";
                }
                else if (survey.S1Q9Answer == "China" || survey.S1Q9Answer == "Other")
                {
                    dataS1Q9Ans = "中国或其它国家";
                }
                else
                {
                    dataS1Q9Ans = "无硕士学历";
                }

                ViewBag.dataS1Q9Answer = dataS1Q9Ans;

                ViewBag.dataS1Q10Answer = survey.S1Q10Answer;
                ViewBag.dataS1Q11Answer = survey.S1Q11Answer;
                ViewBag.dataS1Q12Answer = survey.S1Q12Answer;

                if (survey.S1Q13Answer == "exp3")
                {
                    dataS1Q13Ans = "三年以上";
                }
                else if (survey.S1Q13Answer == "exp2")
                {
                    dataS1Q13Ans = "一到三年";
                }
                else
                {
                    dataS1Q13Ans = "一年以内";
                }

                ViewBag.dataS1Q113Answer = dataS1Q13Ans;

                if (survey.S1Q14Answer == "yes")
                {
                    dataS1Q14Ans = "相关";
                }
                else
                {
                    dataS1Q14Ans = "不相关";
                }

                ViewBag.dataS1Q14Answer = dataS1Q14Ans;
                ViewBag.dataS1Q15Answer = survey.S1Q15Answer;

                if (survey.S1Q16Answer == "time4")
                {
                    dataS1Q16Ans = "三年以上";
                }
                else if (survey.S1Q16Answer == "time3")
                {
                    dataS1Q16Ans = "一到三年";
                }
                else if (survey.S1Q16Answer == "time2")
                {
                    dataS1Q16Ans = "半年到一年";
                }
                else
                {
                    dataS1Q16Ans = "半年以内";
                }

                ViewBag.dataS1Q16Answer = dataS1Q16Ans;
                ViewBag.dataS1Q17Answer = survey.S1Q17Answer;
                ViewBag.dataS1Q18Answer = survey.S1Q18Answer;
                ViewBag.dataS1Q19Answer = survey.S1Q19Answer;

                // Section 2
                string dataS2Q1Ans = "";
                string dataS2Q2Ans = "";
                string dataS2Q3Ans = "";
                string dataS2Q4Ans = "";
                string dataS2Q5Ans = "";
                string dataS2Q6Ans = "";
                string dataS2Q7Ans = "";
                string dataS2Q8Ans = "";
                string dataS2Q9Ans = "";
                string dataS2Q10Ans = "";

                if (survey.S2Q1Answer == "immigration")
                {
                    dataS2Q1Ans = "移民";
                }
                else if (survey.S2Q1Answer == "business")
                {
                    dataS2Q1Ans = "创业";
                }
                else if (survey.S2Q1Answer == "education")
                {
                    dataS2Q1Ans = "孩子教育";
                }

                ViewBag.dataS2Q1Answer = dataS2Q1Ans;


                if (survey.S2Q2Answer == "yes")
                {
                    dataS2Q2Ans = "可以";
                }
                else if (survey.S2Q2Answer == "no")
                {
                    dataS2Q2Ans = "不可以";
                }

                ViewBag.dataS2Q2Answer = dataS2Q2Ans;

                if (survey.S2Q3Answer == "lessthanielts4")
                {
                    dataS2Q3Ans = "雅思 4 分以下";
                }
                else if (survey.S2Q3Answer == "ielts4orabove")
                {
                    dataS2Q3Ans = "雅思 4 分以上（包括 4 分）";
                }

                ViewBag.dataS2Q3Answer = dataS2Q3Ans;

                if (survey.S2Q4Answer == "200k")
                {
                    dataS2Q4Ans = "20万";
                }
                else if (survey.S2Q4Answer == "100k")
                {
                    dataS2Q4Ans = "10万";
                }
                else if (survey.S2Q4Answer == "50k")
                {
                    dataS2Q4Ans = "5万";
                }

                ViewBag.dataS2Q4Answer = dataS2Q4Ans;

                if (survey.S2Q5Answer == "cantwork")
                {
                    dataS2Q5Ans = "不能为他人工作";
                }
                else if (survey.S2Q5Answer == "canwork")
                {
                    dataS2Q5Ans = "可以为他人工作";
                }

                ViewBag.dataS2Q5Answer = dataS2Q5Ans;

                if (survey.S2Q6Answer == "can")
                {
                    dataS2Q6Ans = "可以";
                }
                else if (survey.S2Q6Answer == "cant")
                {
                    dataS2Q6Ans = "不可以";
                }

                ViewBag.dataS2Q6Answer = dataS2Q6Ans;

                if (survey.S2Q7Answer == "100")
                {
                    dataS2Q7Ans = "200 左右";
                }
                else if (survey.S2Q7Answer == "500")
                {
                    dataS2Q7Ans = "500 左右";
                }
                else if (survey.S2Q7Answer == "1000")
                {
                    dataS2Q7Ans = "1000 左右";
                }

                ViewBag.dataS2Q7Answer = dataS2Q7Ans;

                if (survey.S2Q8Answer == "can")
                {
                    dataS2Q8Ans = "可以";
                }
                else if (survey.S2Q8Answer == "cant")
                {
                    dataS2Q8Ans = "不可以";
                }

                ViewBag.dataS2Q8Answer = dataS2Q8Ans;

                if (survey.S2Q9Answer == "2employee")
                {
                    dataS2Q9Ans = "2 个全职员工，至少每个员工职位超过 12 个月";
                }
                else if (survey.S2Q9Answer == "1employee")
                {
                    dataS2Q9Ans = "1 个全职员工，至少职位超过 24 个月";
                }

                ViewBag.dataS2Q9Answer = dataS2Q9Ans;

                if (survey.S2Q10Answer == "200k")
                {
                    dataS2Q10Ans = "能够证明有超过20万英镑的存款";
                }
                else if (survey.S2Q10Answer == "freedom")
                {
                    dataS2Q10Ans = "能够证明资金可以自由转入英国";
                }
                else if (survey.S2Q10Answer == "3months")
                {
                    dataS2Q10Ans = "能够证明资金在银行户头超过3个月";
                }

                ViewBag.dataS2Q10Answer = dataS2Q10Ans;

                // Section 3
                string dataS3Q1Ans = "";
                string dataS3Q2Ans = "";
                string dataS3Q3Ans = "";
                string dataS3Q4Ans = "";
                string dataS3Q5Ans = "";
                string dataS3Q6Ans = "";
                string dataS3Q7Ans = "";
                string dataS3Q8Ans = "";
                string dataS3Q9Ans = "";
                string dataS3Q10Ans = "";

                if (survey.S3Q1Answer == "20pct")
                {
                    dataS3Q1Ans = "20%";
                }
                else if (survey.S3Q1Answer == "17pct")
                {
                    dataS3Q1Ans = "17%";
                }
                else if (survey.S3Q1Answer == "14pct")
                {
                    dataS3Q1Ans = "14%";
                }

                ViewBag.dataS3Q1Answer = dataS3Q1Ans;

                if (survey.S3Q2Answer == "yes")
                {
                    dataS3Q2Ans = "需要";
                }
                else if (survey.S3Q2Answer == "no")
                {
                    dataS3Q2Ans = "不需要";
                }

                ViewBag.dataS3Q2Answer = dataS3Q2Ans;

                if (survey.S3Q3Answer == "6.00")
                {
                    dataS3Q3Ans = "6.00";
                }
                else if (survey.S3Q3Answer == "7.00")
                {
                    dataS3Q3Ans = "7.00";
                }
                else if (survey.S3Q3Answer == "8.00")
                {
                    dataS3Q3Ans = "8.00";
                }

                ViewBag.dataS3Q3Answer = dataS3Q3Ans;

                if (survey.S3Q4Answer == "15k")
                {
                    dataS3Q4Ans = "1万5千镑";
                }
                else if (survey.S3Q4Answer == "25k")
                {
                    dataS3Q4Ans = "2万5千镑";
                }
                else if (survey.S3Q4Answer == "50k")
                {
                    dataS3Q4Ans = "5万镑";
                }

                ViewBag.dataS3Q4Answer = dataS3Q4Ans;

                if (survey.S3Q5Answer == "1k")
                {
                    dataS3Q5Ans = "1千镑";
                }
                else if (survey.S3Q5Answer == "2k")
                {
                    dataS3Q5Ans = "2千镑";
                }
                else if (survey.S3Q5Answer == "5k")
                {
                    dataS3Q5Ans = "5千镑";
                }

                ViewBag.dataS3Q5Answer = dataS3Q5Ans;

                if (survey.S3Q6Answer == "20pct")
                {
                    dataS3Q6Ans = "20%";
                }
                else if (survey.S3Q6Answer == "25pct")
                {
                    dataS3Q6Ans = "25%";
                }
                else if (survey.S3Q6Answer == "28pct")
                {
                    dataS3Q6Ans = "28%";
                }

                ViewBag.dataS3Q6Answer = dataS3Q6Ans;

                if (survey.S3Q7Answer == "yes")
                {
                    dataS3Q7Ans = "咨询过";
                }
                else if (survey.S3Q7Answer == "no")
                {
                    dataS3Q7Ans = "从未咨询过";
                }

                ViewBag.dataS3Q7Answer = dataS3Q7Ans;

                if (survey.S3Q8Answer == "1500")
                {
                    dataS3Q8Ans = "1500";
                }
                else if (survey.S3Q8Answer == "2500")
                {
                    dataS3Q8Ans = "2500";
                }
                else if (survey.S3Q8Answer == "3500")
                {
                    dataS3Q8Ans = "3500";
                }

                ViewBag.dataS3Q8Answer = dataS3Q8Ans;

                if (survey.S3Q9Answer == "300")
                {
                    dataS3Q9Ans = "300";
                }
                else if (survey.S3Q9Answer == "1000")
                {
                    dataS3Q9Ans = "1000";
                }
                else if (survey.S3Q9Answer == "2000")
                {
                    dataS3Q9Ans = "2000";
                }

                ViewBag.dataS3Q9Answer = dataS3Q9Ans;

                if (survey.S3Q10Answer == "yes")
                {
                    dataS3Q10Ans = "理解";
                }
                else if (survey.S3Q10Answer == "no")
                {
                    dataS3Q10Ans = "不理解";
                }

                ViewBag.dataS3Q10Answer = dataS3Q10Ans;

                // Section 4
                if (!string.IsNullOrEmpty(survey.S4aQ1Answer))
                {
                    S4Helper = "0";
                    ViewBag.dataS4Helper = S4Helper;
                    ViewBag.dataS4Q1Answer = survey.S4aQ1Answer;
                    ViewBag.dataS4Q2Answer = survey.S4aQ2Answer;
                    ViewBag.dataS4Q3Answer = survey.S4aQ3Answer;
                    ViewBag.dataS4Q4Answer = survey.S4aQ4Answer;
                    ViewBag.dataS4Q5Answer = survey.S4aQ5Answer;
                    ViewBag.dataS4Q6Answer = survey.S4aQ6Answer;
                    ViewBag.dataS4Q7Answer = survey.S4aQ7Answer;
                    ViewBag.dataS4Q8Answer = survey.S4aQ8Answer;
                    ViewBag.dataS4Q9Answer = survey.S4aQ9Answer;
                    ViewBag.dataS4Q10Answer = survey.S4aQ10Answer;
                    ViewBag.dataS4Q11Answer = survey.S4aQ11Answer;
                    ViewBag.dataS4Q12Answer = survey.S4aQ12Answer;
                    ViewBag.dataS4Q13Answer = survey.S4aQ13Answer;
                    ViewBag.dataS4Q14Answer = survey.S4aQ14Answer;
                    ViewBag.dataS4Q15Answer = survey.S4aQ15Answer;
                    ViewBag.dataS4Q16Answer = survey.S4aQ16Answer;
                    ViewBag.dataS4Q17Answer = survey.S4aQ17Answer;
                    ViewBag.dataS4Q18Answer = survey.S4aQ18Answer;
                    ViewBag.dataS4Q19Answer = survey.S4aQ19Answer;
                    ViewBag.dataS4Q20Answer = survey.S4aQ20Answer;
                    ViewBag.dataS4Q21Answer = survey.S4aQ21Answer;
                    ViewBag.dataS4Q22Answer = survey.S4aQ22Answer;
                    ViewBag.dataS4Q23Answer = survey.S4aQ23Answer;
                    ViewBag.dataS4Q24Answer = survey.S4aQ24Answer;
                    ViewBag.dataS4Q25Answer = survey.S4aQ25Answer;
                    ViewBag.dataS4Q26Answer = survey.S4aQ26Answer;
                    ViewBag.dataS4Q27Answer = survey.S4aQ27Answer;
                    ViewBag.dataS4Q28Answer = survey.S4aQ28Answer;
                    ViewBag.dataS4Q29Answer = survey.S4aQ29Answer;
                    ViewBag.dataS4Q30Answer = survey.S4aQ30Answer;
                    ViewBag.dataS4Q31Answer = survey.S4aQ31Answer;
                    ViewBag.dataS4Q32Answer = survey.S4aQ32Answer;
                    ViewBag.dataS4Q33Answer = survey.S4aQ33Answer;
                    ViewBag.dataS4Q34Answer = survey.S4aQ34Answer;
                    ViewBag.dataS4Q35Answer = survey.S4aQ35Answer;
                    ViewBag.dataS4Q36Answer = survey.S4aQ36Answer;
                    ViewBag.dataS4Q37Answer = survey.S4aQ37Answer;
                    ViewBag.dataS4Q38Answer = survey.S4aQ38Answer;
                    ViewBag.dataS4Q39Answer = survey.S4aQ39Answer;
                    ViewBag.dataS4Q40Answer = survey.S4aQ40Answer;
                    ViewBag.dataS4Q41Answer = survey.S4aQ41Answer;
                    ViewBag.dataS4Q42Answer = survey.S4aQ42Answer;
                    ViewBag.dataS4Q43Answer = survey.S4aQ43Answer;
                    ViewBag.dataS4Q44Answer = survey.S4aQ44Answer;
                    ViewBag.dataS4Q45Answer = survey.S4aQ45Answer;
                    ViewBag.dataS4Q46Answer = survey.S4aQ46Answer;
                    ViewBag.dataS4Q47Answer = survey.S4aQ47Answer;
                    ViewBag.dataS4Q48Answer = survey.S4aQ48Answer;
                    ViewBag.dataS4Q49Answer = survey.S4aQ49Answer;
                    ViewBag.dataS4Q50Answer = survey.S4aQ50Answer;
                    ViewBag.dataS4Q51Answer = survey.S4aQ51Answer;
                    ViewBag.dataS4Q52Answer = survey.S4aQ52Answer;
                    ViewBag.dataS4Q53Answer = survey.S4aQ53Answer;
                    ViewBag.dataS4Q54Answer = survey.S4aQ54Answer;
                    ViewBag.dataS4Q55Answer = survey.S4aQ55Answer;
                    ViewBag.dataS4Q56Answer = survey.S4aQ56Answer;
                    ViewBag.dataS4Q57Answer = survey.S4aQ57Answer;
                    ViewBag.dataS4Q58Answer = survey.S4aQ58Answer;
                    ViewBag.dataS4Q59Answer = survey.S4aQ59Answer;
                    ViewBag.dataS4Q60Answer = survey.S4aQ60Answer;
                    ViewBag.dataS4Q61Answer = survey.S4aQ61Answer;
                    ViewBag.dataS4Q62Answer = survey.S4aQ62Answer;
                    ViewBag.dataS4Q63Answer = survey.S4aQ63Answer;
                } else
                {
                    S4Helper = "1";
                    ViewBag.dataS4Helper = S4Helper;
                    ViewBag.dataS4Q1Answer = survey.S4bQ1Answer;
                    ViewBag.dataS4Q2Answer = survey.S4bQ2Answer;
                    ViewBag.dataS4Q3Answer = survey.S4bQ3Answer;
                    ViewBag.dataS4Q4Answer = survey.S4bQ4Answer;
                    ViewBag.dataS4Q5Answer = survey.S4bQ5Answer;
                    ViewBag.dataS4Q6Answer = survey.S4bQ6Answer;
                    ViewBag.dataS4Q7Answer = survey.S4bQ7Answer;
                    ViewBag.dataS4Q8Answer = survey.S4bQ8Answer;
                    ViewBag.dataS4Q9Answer = survey.S4bQ9Answer;
                    ViewBag.dataS4Q10Answer = survey.S4bQ10Answer;
                    ViewBag.dataS4Q11Answer = survey.S4bQ11Answer;
                    ViewBag.dataS4Q12Answer = survey.S4bQ12Answer;
                    ViewBag.dataS4Q13Answer = survey.S4bQ13Answer;
                    ViewBag.dataS4Q14Answer = survey.S4bQ14Answer;
                    ViewBag.dataS4Q15Answer = survey.S4bQ15Answer;
                    ViewBag.dataS4Q16Answer = survey.S4bQ16Answer;
                    ViewBag.dataS4Q17Answer = survey.S4bQ17Answer;
                    ViewBag.dataS4Q18Answer = survey.S4bQ18Answer;
                    ViewBag.dataS4Q19Answer = survey.S4bQ19Answer;
                    ViewBag.dataS4Q20Answer = survey.S4bQ20Answer;
                    ViewBag.dataS4Q21Answer = survey.S4bQ21Answer;
                    ViewBag.dataS4Q22Answer = survey.S4bQ22Answer;
                    ViewBag.dataS4Q23Answer = survey.S4bQ23Answer;
                    ViewBag.dataS4Q24Answer = survey.S4bQ24Answer;
                    ViewBag.dataS4Q25Answer = survey.S4bQ25Answer;
                    ViewBag.dataS4Q26Answer = survey.S4bQ26Answer;
                    ViewBag.dataS4Q27Answer = survey.S4bQ27Answer;
                    ViewBag.dataS4Q28Answer = survey.S4bQ28Answer;
                    ViewBag.dataS4Q29Answer = survey.S4bQ29Answer;
                    ViewBag.dataS4Q30Answer = survey.S4bQ30Answer;
                    ViewBag.dataS4Q31Answer = survey.S4bQ31Answer;
                    ViewBag.dataS4Q32Answer = survey.S4bQ32Answer;
                    ViewBag.dataS4Q33Answer = survey.S4bQ33Answer;
                    ViewBag.dataS4Q34Answer = survey.S4bQ34Answer;
                    ViewBag.dataS4Q35Answer = survey.S4bQ35Answer;
                    ViewBag.dataS4Q36Answer = survey.S4bQ36Answer;
                    ViewBag.dataS4Q37Answer = survey.S4bQ37Answer;
                    ViewBag.dataS4Q38Answer = survey.S4bQ38Answer;
                    ViewBag.dataS4Q39Answer = survey.S4bQ39Answer;
                    ViewBag.dataS4Q40Answer = survey.S4bQ40Answer;
                    ViewBag.dataS4Q41Answer = survey.S4bQ41Answer;
                    ViewBag.dataS4Q42Answer = survey.S4bQ42Answer;
                    ViewBag.dataS4Q43Answer = survey.S4bQ43Answer;
                    ViewBag.dataS4Q44Answer = survey.S4bQ44Answer;
                    ViewBag.dataS4Q45Answer = survey.S4bQ45Answer;
                    ViewBag.dataS4Q46Answer = survey.S4bQ46Answer;
                    ViewBag.dataS4Q47Answer = survey.S4bQ47Answer;
                    ViewBag.dataS4Q48Answer = survey.S4bQ48Answer;
                    ViewBag.dataS4Q49Answer = survey.S4bQ49Answer;
                    ViewBag.dataS4Q50Answer = survey.S4bQ50Answer;
                    ViewBag.dataS4Q51Answer = survey.S4bQ51Answer;
                    ViewBag.dataS4Q52Answer = survey.S4bQ52Answer;
                    ViewBag.dataS4Q53Answer = survey.S4bQ53Answer;
                    ViewBag.dataS4Q54Answer = survey.S4bQ54Answer;
                    ViewBag.dataS4Q55Answer = survey.S4bQ55Answer;
                    ViewBag.dataS4Q56Answer = survey.S4bQ56Answer;
                    ViewBag.dataS4Q57Answer = survey.S4bQ57Answer;
                    ViewBag.dataS4Q58Answer = survey.S4bQ58Answer;
                    ViewBag.dataS4Q59Answer = survey.S4bQ59Answer;
                    ViewBag.dataS4Q60Answer = survey.S4bQ60Answer;
                    ViewBag.dataS4Q61Answer = survey.S4bQ61Answer;
                    ViewBag.dataS4Q62Answer = survey.S4bQ62Answer;
                    ViewBag.dataS4Q63Answer = survey.S4bQ63Answer;
                }
            }
            else
            {
                Session["error"] = "没有找到此 Survey ID。";
                return View("Error");
            }

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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S1Q1Answer", "S1Q2Answer", "S1Q3Answer", "S1Q4Answer", "S1Q5Answer", "S1Q6Answer", "S1Q7Answer", "S1Q8Answer", "S1Q9Answer", "S1Q10Answer", "S1Q11Answer", "S1Q12Answer", "S1Q13Answer", "S1Q14Answer", "S1Q15Answer", "S1Q16Answer", "S1Q17Answer", "S1Q18Answer", "S1Q19Answer" }))
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
            int S1Q9ScoreLocal = 0;
            int S1Q13ScoreLocal = 0;
            int S1Q14ScoreLocal = 0;
            int S1Q16ScoreLocal = 0;

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
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q6Answer))
                    {
                        if (survey.S1Q6Answer == "UK")
                        {
                            S1Q6ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q9Answer))
                    {
                        if (survey.S1Q9Answer == "UK")
                        {
                            S1Q9ScoreLocal = 10;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q13Answer))
                    {
                        if (survey.S1Q13Answer == "exp3")
                        {
                            S1Q13ScoreLocal = 10;
                        }
                        else if (survey.S1Q13Answer == "exp2")
                        {
                            S1Q13ScoreLocal = 5;
                        }
                        else
                        {
                            S1Q13ScoreLocal = 0;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q14Answer))
                    {
                        if (survey.S1Q14Answer == "yes")
                        {
                            S1Q14ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q14ScoreLocal = 0;
                        }
                    }

                    if (!string.IsNullOrEmpty(survey.S1Q16Answer))
                    {
                        if (survey.S1Q16Answer == "time4")
                        {
                            S1Q16ScoreLocal = 30;
                        }
                        else if (survey.S1Q16Answer == "time3")
                        {
                            S1Q16ScoreLocal = 20;
                        }
                        else if (survey.S1Q16Answer == "time2")
                        {
                            S1Q16ScoreLocal = 10;
                        }
                        else
                        {
                            S1Q16ScoreLocal = 0;
                        }
                    }

                    if (TryUpdateModel(survey, "", new string[] { "S1Q3Score","S1Q6Score", "S1Q9Score", "S1Q13Score", "S1Q14Score", "S1Q16Score" }))
                    {
                        try
                        {
                            survey.S1Q3Score = S1Q3ScoreLocal;
                            survey.S1Q6Score = S1Q6ScoreLocal;
                            survey.S1Q9Score = S1Q9ScoreLocal;
                            survey.S1Q13Score = S1Q13ScoreLocal;
                            survey.S1Q14Score = S1Q14ScoreLocal;
                            survey.S1Q16Score = S1Q16ScoreLocal;
                            db.SaveChanges();
                        }
                        catch (RetryLimitExceededException)
                        {
                            ModelState.AddModelError("", "Unable to save changes for Stage 1 Score. Try again, and if the problem persists, see your system administrator.");
                        }
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                    S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;

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

                    ViewBag.Section1Score = S1Score;
                    ViewBag.Section1Message = S1ScoreMsg;

                    if (survey.S1Q3Answer == "UK")
                    {
                        ViewBag.Section3AnwserMessage = "这里您得到10分，在英国拿到本科学位有助申请企业家移民签证";
                    }
                    

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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }
        }

        // Post: S1PageSum
        [HttpPost, ActionName("S1PageSum")]
        [ValidateAntiForgeryToken]
        public ActionResult S1PageSumPost(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (command.Equals("继续"))
            {
                return RedirectToAction("S2Page1");
            }
            else if (command.Equals("保存并退出"))
            {
                return RedirectToAction("SectionSaved");
            }

            return View("Error");
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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UserTestCode = Session["viewKey"].ToString();
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                            ModelState.AddModelError("", "Unable to save changes for Stage 2. Try again, and if the problem persists, see your system administrator.");
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                        if (survey.S2Q3Answer == "ielts4orabove")
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

                            S1Score = survey.S1Q3Score + survey.S1Q6Score + +survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }
        }

        // Post: S2PageSum
        [HttpPost, ActionName("S2PageSum")]
        [ValidateAntiForgeryToken]
        public ActionResult S2PageSumPost(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (command.Equals("继续"))
            {
                return RedirectToAction("S3Page1");
            }
            else if (command.Equals("保存并退出"))
            {
                return RedirectToAction("SectionSaved");
            }

            return View("Error");
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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UserTestCode = Session["viewKey"].ToString();
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                        if (survey.S3Q3Answer == "8.00")
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
                        if (survey.S3Q8Answer == "2500")
                        {
                            S3Q8ScoreLocal = 10;
                        }
                    }
                        
                    if (!string.IsNullOrEmpty(survey.S3Q9Answer))
                    {
                        if (survey.S3Q9Answer == "1000")
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

                            S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }
            if (Section4 == "独立创业")
            {
                return RedirectToAction("S4aPage1");
            }
            else if (Section4 == "加入创业")
            {
                return RedirectToAction("S4bPage1");
            }
            else if (Section4 == "保存并退出")
            {
                return RedirectToAction("SectionSaved");
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
                Session["error"] = "页面显示超时，请重新测试。";
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
        public ActionResult S4aPage1Post(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ1Answer", "S4aQ2Answer", "S4aQ3Answer", "S4aQ4Answer", "S4aQ5Answer", "S4aQ6Answer", "S4aQ7Answer", "S4aQ8Answer", "S4aQ9Answer", "S4aQ10Answer", "S4aQ11Answer", "S4aQ12Answer", "S4aQ13Answer", "S4aQ14Answer", "S4aQ15Answer", "S4aQ16Answer", "S4aQ17Answer", "S4aQ18Answer", "S4aQ19Answer", "S4aQ20Answer", "S4aQ21Answer", "S4aQ22Answer", "S4aQ23Answer", "S4aQ24Answer", "S4aQ25Answer", "S4aQ26Answer", "S4aQ27Answer", "S4aQ28Answer", "S4aQ29Answer", "S4aQ30Answer", "S4aQ31Answer", "S4aQ32Answer", "S4aQ33Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();

                            if (command.Equals("继续"))
                            {
                                return RedirectToAction("S4aPage2");
                            }
                            else if (command.Equals("保存并退出"))
                            {
                                return RedirectToAction("SectionSaved");
                            }
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
        public ActionResult S4aPage2Post(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4aQ34Answer", "S4aQ35Answer", "S4aQ36Answer", "S4aQ37Answer", "S4aQ38Answer", "S4aQ39Answer", "S4aQ40Answer", "S4aQ41Answer", "S4aQ42Answer", "S4aQ43Answer", "S4aQ44Answer", "S4aQ45Answer", "S4aQ46Answer", "S4aQ47Answer", "S4aQ48Answer", "S4aQ49Answer", "S4aQ50Answer", "S4aQ51Answer", "S4aQ52Answer", "S4aQ53Answer", "S4aQ54Answer", "S4aQ55Answer", "S4aQ56Answer", "S4aQ57Answer", "S4aQ58Answer", "S4aQ59Answer", "S4aQ60Answer", "S4aQ61Answer", "S4aQ62Answer", "S4aQ63Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            if (command.Equals("继续"))
                            {
                                return RedirectToAction("S4aPageSum");
                            }
                            else if (command.Equals("回到独立创业测试第一部分"))
                            {
                                return RedirectToAction("SectionBack4a");
                            }
                            else if (command.Equals("保存并退出"))
                            {
                                return RedirectToAction("SectionSaved");
                            }
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
                Session["error"] = "页面显示超时，请重新测试。";
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
            string S1Q3Ans = "";
            string S1Q3Msg = "";
            string S1Q6Ans = "";
            string S1Q6Msg = "";
            string S1Q9Ans = "";
            string S1Q9Msg = "";
            string S1Q13Ans = "";
            string S1Q13Msg = "";
            string S1Q14Ans = "";
            string S1Q14Msg = "";
            string S1Q16Ans = "";
            string S1Q16Msg = "";
            string S2Q1Ans = "";
            string S2Q1Msg = "";
            string S2Q2Ans = "";
            string S2Q2Msg = "";
            string S2Q3Ans = "";
            string S2Q3Msg = "";
            string S2Q4Ans = "";
            string S2Q4Msg = "";
            string S2Q5Ans = "";
            string S2Q5Msg = "";
            string S2Q6Ans = "";
            string S2Q6Msg = "";
            string S2Q7Ans = "";
            string S2Q7Msg = "";
            string S2Q8Ans = "";
            string S2Q8Msg = "";
            string S2Q9Ans = "";
            string S2Q9Msg = "";
            string S2Q10Ans = "";
            string S2Q10Msg = "";
            string S3Q1Ans = "";
            string S3Q1Msg = "";
            string S3Q2Ans = "";
            string S3Q2Msg = "";
            string S3Q3Ans = "";
            string S3Q3Msg = "";
            string S3Q4Ans = "";
            string S3Q4Msg = "";
            string S3Q5Ans = "";
            string S3Q5Msg = "";
            string S3Q6Ans = "";
            string S3Q6Msg = "";
            string S3Q7Ans = "";
            string S3Q7Msg = "";
            string S3Q8Ans = "";
            string S3Q8Msg = "";
            string S3Q9Ans = "";
            string S3Q9Msg = "";
            string S3Q10Ans = "";
            string S3Q10Msg = "";

            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);

            if (survey != null)
            {
                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
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

                ViewBag.Section1Question1Anwser = survey.S1Q1Answer;
                ViewBag.Section1Question2Anwser = survey.S1Q2Answer;

                if (survey.S1Q3Answer == "UK")
                {
                    S1Q3Ans = "英国";
                    S1Q3Msg = "您在英国取得学士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q3Answer == "China" || survey.S1Q3Answer == "Other")
                {
                    S1Q3Ans = "中国或其它国家";
                    S1Q3Msg = "您在英国以外国家取得学士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q3Ans = "无学士学历";
                    S1Q3Msg = "您没有取得学士学位，此处不加分。";
                }

                ViewBag.Section1Question3Anwser = S1Q3Ans;
                ViewBag.Section1Question3AnwserMessage = S1Q3Msg;

                ViewBag.Section1Question4Anwser = survey.S1Q4Answer;
                ViewBag.Section1Question5Anwser = survey.S1Q5Answer;

                if (survey.S1Q6Answer == "UK")
                {
                    S1Q6Ans = "英国";
                    S1Q6Msg = "您在英国取得硕士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q6Answer == "China" || survey.S1Q6Answer == "Other")
                {
                    S1Q6Ans = "中国或其它国家";
                    S1Q6Msg = "您在英国以外国家取得硕士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q6Ans = "无硕士学历";
                    S1Q6Msg = "您没有取得硕士学位，此处不加分。";
                }

                ViewBag.Section1Question6Anwser = S1Q6Ans;
                ViewBag.Section1Question6AnwserMessage = S1Q6Msg;

                ViewBag.Section1Question7Anwser = survey.S1Q7Answer;
                ViewBag.Section1Question8Anwser = survey.S1Q8Answer;

                if (survey.S1Q9Answer == "UK")
                {
                    S1Q9Ans = "英国";
                    S1Q9Msg = "您在英国取得博士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q9Answer == "China" || survey.S1Q9Answer == "Other")
                {
                    S1Q9Ans = "中国或其它国家";
                    S1Q9Msg = "您在英国以外国家取得博士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q9Ans = "无硕士学历";
                    S1Q9Msg = "您没有取得博士学位，此处不加分。";
                }

                ViewBag.Section1Question9Anwser = S1Q9Ans;
                ViewBag.Section1Question9AnwserMessage = S1Q9Msg;

                ViewBag.Section1Question10Anwser = survey.S1Q10Answer;
                ViewBag.Section1Question11Anwser = survey.S1Q11Answer;
                ViewBag.Section1Question12Anwser = survey.S1Q12Answer;

                if (survey.S1Q13Answer == "exp3")
                {
                    S1Q13Ans = "三年以上";
                    S1Q13Msg = "您的工作经验在三年以上，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q13Answer == "exp2")
                {
                    S1Q13Ans = "一到三年";
                    S1Q13Msg = "您的工作经验是一到三年，这对于企业家移民签证申请有一定的帮助, 此处加5分。";
                }
                else
                {
                    S1Q13Ans = "一年以内";
                    S1Q13Msg = "您的工作经验较少，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question13Anwser = S1Q13Ans;
                ViewBag.Section1Question13AnwserMessage = S1Q13Msg;

                if (survey.S1Q14Answer == "yes")
                {
                    S1Q14Ans = "相关";
                    S1Q14Msg = "您的工作与英国相关，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else
                {
                    S1Q14Ans = "不相关";
                    S1Q14Msg = "您的工作与英国不相关，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question14Anwser = S1Q14Ans;
                ViewBag.Section1Question14AnwserMessage = S1Q14Msg;

                ViewBag.Section1Question15Anwser = survey.S1Q15Answer;

                if (survey.S1Q16Answer == "time4")
                {
                    S1Q16Ans = "三年以上";
                    S1Q16Msg = "您在英国停留累计时间超过三年，这非常有助于您的企业家移民签证申请，此处加30分。";
                }
                else if (survey.S1Q16Answer == "time3")
                {
                    S1Q16Ans = "一到三年";
                    S1Q16Msg = "您在英国停留累计时间在一到三年之间，这有助于您的企业家移民签证申请，此处加20分。";
                }
                else if (survey.S1Q16Answer == "time2")
                {
                    S1Q16Ans = "半年到一年";
                    S1Q16Msg = "您在英国停留累计时间在半年到一年之间，这对于您的企业家移民签证申请有一定帮助，此处加10分。";
                }
                else
                {
                    S1Q16Ans = "半年以内";
                    S1Q16Msg = "您在英国停留累计时间少于半年，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question16Anwser = S1Q16Ans;
                ViewBag.Section1Question16AnwserMessage = S1Q16Msg;

                ViewBag.Section1Question17Anwser = survey.S1Q17Answer;
                ViewBag.Section1Question18Anwser = survey.S1Q18Answer;
                ViewBag.Section1Question19Anwser = survey.S1Q19Answer;

                if (survey.S2Q1Answer == "immigration")
                {
                    S2Q1Ans = "移民";
                    S2Q1Msg = "申请企业家移民的主要目的一定是创业，并且要具备企业家精神，移民不是理想答案，此处不加分。";
                }
                else if (survey.S2Q1Answer == "business")
                {
                    S2Q1Ans = "创业";
                    S2Q1Msg = "创业是申请企业家移民的最主要目的，并且要让自己具备企业家精神，您的答案正确，此处加10分。";
                }
                else if (survey.S2Q1Answer == "education")
                {
                    S2Q1Ans = "孩子教育";
                    S2Q1Msg = "申请企业家移民的主要目的一定是创业，并且要具备企业家精神，孩子教育不是理想答案，此处不加分。";
                }

                ViewBag.Section2Question1Anwser = S2Q1Ans;
                ViewBag.Section2Question1AnwserMessage = S2Q1Msg;

                if (survey.S2Q2Answer == "yes")
                {
                    S2Q2Ans = "可以";
                    S2Q2Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q2Answer == "no")
                {
                    S2Q2Ans = "不可以";
                    S2Q2Msg = "您可以与其它人以合伙人的方式申请企业家移民签证，要想了解更多信息请联系我们，此处不加分。";
                }

                ViewBag.Section2Question2Anwser = S2Q2Ans;
                ViewBag.Section2Question2AnwserMessage = S2Q2Msg;

                if (survey.S2Q3Answer == "lessthanielts4")
                {
                    S2Q3Ans = "雅思 4 分以下";
                    S2Q3Msg = "企业家移民签证的最低雅思分数要求是4分。您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q3Answer == "ielts4orabove")
                {
                    S2Q3Ans = "雅思 4 分以上（包括 4 分）";
                    S2Q3Msg = "答案正确，此处加10分。";
                }

                ViewBag.Section2Question3Anwser = S2Q3Ans;
                ViewBag.Section2Question3AnwserMessage = S2Q3Msg;

                if (survey.S2Q4Answer == "200k")
                {
                    S2Q4Ans = "20万";
                    S2Q4Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q4Answer == "100k")
                {
                    S2Q4Ans = "10万";
                    S2Q4Msg = "企业家移民要求的最低投资金额是20万英镑，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q4Answer == "50k")
                {
                    S2Q4Ans = "5万";
                    S2Q4Msg = "企业家移民要求的最低投资金额是20万英镑，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question4Anwser = S2Q4Ans;
                ViewBag.Section2Question4AnwserMessage = S2Q4Msg;

                if (survey.S2Q5Answer == "cantwork")
                {
                    S2Q5Ans = "不能为他人工作";
                    S2Q5Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q5Answer == "canwork")
                {
                    S2Q5Ans = "可以为他人工作";
                    S2Q5Msg = "企业家移民签证的主申请人是不可以为他人工作的。您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question5Anwser = S2Q5Ans;
                ViewBag.Section2Question5AnwserMessage = S2Q5Msg;

                if (survey.S2Q6Answer == "can")
                {
                    S2Q6Ans = "可以";
                    S2Q6Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q6Answer == "cant")
                {
                    S2Q6Ans = "不可以";
                    S2Q6Msg = "企业家移民签证的主申请人是可以带自己的配偶和未满18岁的小孩来英国的。您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question6Anwser = S2Q6Ans;
                ViewBag.Section2Question6AnwserMessage = S2Q6Msg;

                if (survey.S2Q7Answer == "100")
                {
                    S2Q7Ans = "200 左右";
                    S2Q7Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q7Answer == "500")
                {
                    S2Q7Ans = "500 左右";
                    S2Q7Msg = "正确答案为100人左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q7Answer == "1000")
                {
                    S2Q7Ans = "1000 左右";
                    S2Q7Msg = "正确答案为100人左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question7Anwser = S2Q7Ans;
                ViewBag.Section2Question7AnwserMessage = S2Q7Msg;

                if (survey.S2Q8Answer == "can")
                {
                    S2Q8Ans = "可以";
                    S2Q8Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q8Answer == "cant")
                {
                    S2Q8Ans = "不可以";
                    S2Q8Msg = "企业家移民分独立创业和加入创业两种模式，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question8Anwser = S2Q8Ans;
                ViewBag.Section2Question8AnwserMessage = S2Q8Msg;

                if (survey.S2Q9Answer == "2employee")
                {
                    S2Q9Ans = "2 个全职员工，至少每个员工职位超过 12 个月";
                    S2Q9Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q9Answer == "1employee")
                {
                    S2Q9Ans = "1 个全职员工，至少职位超过 24 个月";
                    S2Q9Msg = "企业家需要在3年内雇佣2个持有英国护照的全职员工，并且至少每位员工在职要超过12个月，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question9Anwser = S2Q9Ans;
                ViewBag.Section2Question9AnwserMessage = S2Q9Msg;

                if (survey.S2Q10Answer == "200k")
                {
                    S2Q10Ans = "能够证明有超过20万英镑的存款";
                    S2Q10Msg = "证明信的最关键要素是能够证明资金可以自由转入英国，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q10Answer == "freedom")
                {
                    S2Q10Ans = "能够证明资金可以自由转入英国";
                    S2Q10Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q10Answer == "3months")
                {
                    S2Q10Ans = "能够证明资金在银行户头超过3个月";
                    S2Q10Msg = "证明信的最关键要素是能够证明资金可以自由转入英国，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question10Anwser = S2Q10Ans;
                ViewBag.Section2Question10AnwserMessage = S2Q10Msg;

                if (survey.S3Q1Answer == "20pct")
                {
                    S3Q1Ans = "20%";
                    S3Q1Msg = "答案正确，此处加10分。";
                }
                else if (survey.S3Q1Answer == "17pct")
                {
                    S3Q1Ans = "17%";
                    S3Q1Msg = "英国 VAT 税率为 20%，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q1Answer == "14pct")
                {
                    S3Q1Ans = "14%";
                    S3Q1Msg = "英国 VAT 税率为 20%，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question1Anwser = S3Q1Ans;
                ViewBag.Section3Question1AnwserMessage = S3Q1Msg;

                if (survey.S3Q2Answer == "yes")
                {
                    S3Q2Ans = "需要";
                    S3Q2Msg = "答案正确，此处加10分。";
                }
                else if (survey.S3Q2Answer == "no")
                {
                    S3Q2Ans = "不需要";
                    S3Q2Msg = "在英国开公司是需要买保险的，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question2Anwser = S3Q2Ans;
                ViewBag.Section3Question2AnwserMessage = S3Q2Msg;

                if (survey.S3Q3Answer == "6.00")
                {
                    S3Q3Ans = "6.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q3Answer == "7.00")
                {
                    S3Q3Ans = "7.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q3Answer == "8.00")
                {
                    S3Q3Ans = "8.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案正确，此处加10分。";
                }

                ViewBag.Section3Question3Anwser = S3Q3Ans;
                ViewBag.Section3Question3AnwserMessage = S3Q3Msg;

                if (survey.S3Q4Answer == "15k")
                {
                    S3Q4Ans = "1万5千镑";
                    S3Q4Msg = "聘请一位有3年工作经验的项目开发经理需要支付2万5千镑左右的年薪，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q4Answer == "25k")
                {
                    S3Q4Ans = "2万5千镑";
                    S3Q4Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q4Answer == "50k")
                {
                    S3Q4Ans = "5万镑";
                    S3Q4Msg = "聘请一位有3年工作经验的项目开发经理需要支付2万5千镑左右的年薪，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question4Anwser = S3Q4Ans;
                ViewBag.Section3Question4AnwserMessage = S3Q4Msg;

                if (survey.S3Q5Answer == "1k")
                {
                    S3Q5Ans = "1千镑";
                    S3Q5Msg = "ZONE2四人办公室一个月租金是2千镑左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q5Answer == "2k")
                {
                    S3Q5Ans = "2千镑";
                    S3Q5Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q5Answer == "5k")
                {
                    S3Q5Ans = "5千镑";
                    S3Q5Msg = "ZONE2四人办公室一个月租金是2千镑左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question5Anwser = S3Q5Ans;
                ViewBag.Section3Question5AnwserMessage = S3Q5Msg;

                if (survey.S3Q6Answer == "20pct")
                {
                    S3Q6Ans = "20%";
                    S3Q6Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q6Answer == "25pct")
                {
                    S3Q6Ans = "25%";
                    S3Q6Msg = "纳税工资部分缴纳比例是20%, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q6Answer == "28pct")
                {
                    S3Q6Ans = "28%";
                    S3Q6Msg = "纳税工资部分缴纳比例是20%, 您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question6Anwser = S3Q6Ans;
                ViewBag.Section3Question6AnwserMessage = S3Q6Msg;

                if (survey.S3Q7Answer == "yes")
                {
                    S3Q7Ans = "咨询过";
                    S3Q7Msg = "如果您咨询过移民律师或类似的企业家签证持有人对您的签证申请会有帮助，此处加10分。";
                }
                else if (survey.S3Q7Answer == "no")
                {
                    S3Q7Ans = "从未咨询过";
                    S3Q7Msg = "我们建议您咨询移民律师或类似的企业家签证持有人，这样对您的企业家移民签证申请会有帮助，此处不加分。";
                }

                ViewBag.Section3Question7Anwser = S3Q7Ans;
                ViewBag.Section3Question7AnwserMessage = S3Q7Msg;

                if (survey.S3Q8Answer == "1500")
                {
                    S3Q8Ans = "1500";
                    S3Q8Msg = "会计服务费用在2500镑左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q8Answer == "2500")
                {
                    S3Q8Ans = "2500";
                    S3Q8Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q8Answer == "3500")
                {
                    S3Q8Ans = "3500";
                    S3Q8Msg = "会计服务费用在2500镑左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question8Anwser = S3Q8Ans;
                ViewBag.Section3Question8AnwserMessage = S3Q8Msg;

                if (survey.S3Q9Answer == "300")
                {
                    S3Q9Ans = "300";
                    S3Q9Msg = "公司每年保险费用在1000镑左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q9Answer == "1000")
                {
                    S3Q9Ans = "1000";
                    S3Q9Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q9Answer == "2000")
                {
                    S3Q9Ans = "2000";
                    S3Q9Msg = "公司每年保险费用在1000镑左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question9Anwser = S3Q9Ans;
                ViewBag.Section3Question9AnwserMessage = S3Q9Msg;

                if (survey.S3Q10Answer == "yes")
                {
                    S3Q10Ans = "理解";
                    S3Q10Msg = "在英国董事和股东之间是有很大区别的，股东是公司的所有者，董事会是受股东授权管理公司的机构，由各个股东指定人士负责担任管理公司的职责，股东不一定是董事，董事也不一定是股东，您已了解这些信息，这对申请企业家移民签证有帮助，此处加10分。";
                }
                else if (survey.S3Q10Answer == "no")
                {
                    S3Q10Ans = "不理解";
                    S3Q10Msg = "在英国董事和股东之间是有很大区别的，股东是公司的所有者，董事会是受股东授权管理公司的机构，由各个股东指定人士负责担任管理公司的职责，股东不一定是董事，董事也不一定是股东，您应该对这些信息进一步了解，这对申请企业家移民签证有帮助，此处不加分";
                }

                ViewBag.Section3Question10Anwser = S3Q10Ans;
                ViewBag.Section3Question10AnwserMessage = S3Q10Msg;

                ViewBag.Section4aQuestion1Anwser = survey.S4aQ1Answer;
                ViewBag.Section4aQuestion2Anwser = survey.S4aQ2Answer;
                ViewBag.Section4aQuestion3Anwser = survey.S4aQ3Answer;
                ViewBag.Section4aQuestion4Anwser = survey.S4aQ4Answer;
                ViewBag.Section4aQuestion5Anwser = survey.S4aQ5Answer;
                ViewBag.Section4aQuestion6Anwser = survey.S4aQ6Answer;
                ViewBag.Section4aQuestion7Anwser = survey.S4aQ7Answer;
                ViewBag.Section4aQuestion8Anwser = survey.S4aQ8Answer;
                ViewBag.Section4aQuestion9Anwser = survey.S4aQ9Answer;
                ViewBag.Section4aQuestion10Anwser = survey.S4aQ10Answer;
                ViewBag.Section4aQuestion11Anwser = survey.S4aQ11Answer;
                ViewBag.Section4aQuestion12Anwser = survey.S4aQ12Answer;
                ViewBag.Section4aQuestion13Anwser = survey.S4aQ13Answer;
                ViewBag.Section4aQuestion14Anwser = survey.S4aQ14Answer;
                ViewBag.Section4aQuestion15Anwser = survey.S4aQ15Answer;
                ViewBag.Section4aQuestion16Anwser = survey.S4aQ16Answer;
                ViewBag.Section4aQuestion17Anwser = survey.S4aQ17Answer;
                ViewBag.Section4aQuestion18Anwser = survey.S4aQ18Answer;
                ViewBag.Section4aQuestion19Anwser = survey.S4aQ19Answer;
                ViewBag.Section4aQuestion20Anwser = survey.S4aQ20Answer;
                ViewBag.Section4aQuestion21Anwser = survey.S4aQ21Answer;
                ViewBag.Section4aQuestion22Anwser = survey.S4aQ22Answer;
                ViewBag.Section4aQuestion23Anwser = survey.S4aQ23Answer;
                ViewBag.Section4aQuestion24Anwser = survey.S4aQ24Answer;
                ViewBag.Section4aQuestion25Anwser = survey.S4aQ25Answer;
                ViewBag.Section4aQuestion26Anwser = survey.S4aQ26Answer;
                ViewBag.Section4aQuestion27Anwser = survey.S4aQ27Answer;
                ViewBag.Section4aQuestion28Anwser = survey.S4aQ28Answer;
                ViewBag.Section4aQuestion29Anwser = survey.S4aQ29Answer;
                ViewBag.Section4aQuestion30Anwser = survey.S4aQ30Answer;
                ViewBag.Section4aQuestion31Anwser = survey.S4aQ31Answer;
                ViewBag.Section4aQuestion32Anwser = survey.S4aQ32Answer;
                ViewBag.Section4aQuestion33Anwser = survey.S4aQ33Answer;
                ViewBag.Section4aQuestion34Anwser = survey.S4aQ34Answer;
                ViewBag.Section4aQuestion35Anwser = survey.S4aQ35Answer;
                ViewBag.Section4aQuestion36Anwser = survey.S4aQ36Answer;
                ViewBag.Section4aQuestion37Anwser = survey.S4aQ37Answer;
                ViewBag.Section4aQuestion38Anwser = survey.S4aQ38Answer;
                ViewBag.Section4aQuestion39Anwser = survey.S4aQ39Answer;
                ViewBag.Section4aQuestion40Anwser = survey.S4aQ40Answer;
                ViewBag.Section4aQuestion41Anwser = survey.S4aQ41Answer;
                ViewBag.Section4aQuestion42Anwser = survey.S4aQ42Answer;
                ViewBag.Section4aQuestion43Anwser = survey.S4aQ43Answer;
                ViewBag.Section4aQuestion44Anwser = survey.S4aQ44Answer;
                ViewBag.Section4aQuestion45Anwser = survey.S4aQ45Answer;
                ViewBag.Section4aQuestion46Anwser = survey.S4aQ46Answer;
                ViewBag.Section4aQuestion47Anwser = survey.S4aQ47Answer;
                ViewBag.Section4aQuestion48Anwser = survey.S4aQ48Answer;
                ViewBag.Section4aQuestion49Anwser = survey.S4aQ49Answer;
                ViewBag.Section4aQuestion50Anwser = survey.S4aQ50Answer;
                ViewBag.Section4aQuestion51Anwser = survey.S4aQ51Answer;
                ViewBag.Section4aQuestion52Anwser = survey.S4aQ52Answer;
                ViewBag.Section4aQuestion53Anwser = survey.S4aQ53Answer;
                ViewBag.Section4aQuestion54Anwser = survey.S4aQ54Answer;
                ViewBag.Section4aQuestion55Anwser = survey.S4aQ55Answer;
                ViewBag.Section4aQuestion56Anwser = survey.S4aQ56Answer;
                ViewBag.Section4aQuestion57Anwser = survey.S4aQ57Answer;
                ViewBag.Section4aQuestion58Anwser = survey.S4aQ58Answer;
                ViewBag.Section4aQuestion59Anwser = survey.S4aQ59Answer;
                ViewBag.Section4aQuestion60Anwser = survey.S4aQ60Answer;
                ViewBag.Section4aQuestion61Anwser = survey.S4aQ61Answer;
                ViewBag.Section4aQuestion62Anwser = survey.S4aQ62Answer;
                ViewBag.Section4aQuestion63Anwser = survey.S4aQ63Answer;

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
                Session["error"] = "页面显示超时，请重新测试。";
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
        public ActionResult S4bPage1Post(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ1Answer", "S4bQ2Answer", "S4bQ3Answer", "S4bQ4Answer", "S4bQ5Answer", "S4bQ6Answer", "S4bQ7Answer", "S4bQ8Answer", "S4bQ9Answer", "S4bQ10Answer", "S4bQ11Answer", "S4bQ12Answer", "S4bQ13Answer", "S4bQ14Answer", "S4bQ15Answer", "S4bQ16Answer", "S4bQ17Answer", "S4bQ18Answer", "S4bQ19Answer", "S4bQ20Answer", "S4bQ21Answer", "S4bQ22Answer", "S4bQ23Answer", "S4bQ24Answer", "S4bQ25Answer", "S4bQ26Answer", "S4bQ27Answer", "S4bQ28Answer", "S4bQ29Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            if (command.Equals("继续"))
                            {
                                return RedirectToAction("S4bPage2");
                            }
                            else if (command.Equals("保存并退出"))
                            {
                                return RedirectToAction("SectionSaved");
                            }
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
                Session["error"] = "页面显示超时，请重新测试。";
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
                Session["error"] = "页面显示超时，请重新测试。";
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
        public ActionResult S4bPage2Post(string command)
        {
            string id = "";
            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            Survey survey = db.Surveys.Find(id);
            if (ModelState.IsValid)
            {
                if (survey != null)
                {
                    if (TryUpdateModel(survey, "", new string[] { "S4bQ30Answer", "S4bQ31Answer", "S4bQ32Answer", "S4bQ33Answer", "S4bQ34Answer", "S4bQ35Answer", "S4bQ36Answer", "S4bQ37Answer", "S4bQ38Answer", "S4bQ39Answer", "S4bQ40Answer", "S4bQ41Answer", "S4bQ42Answer", "S4bQ43Answer", "S4bQ44Answer", "S4bQ45Answer", "S4bQ46Answer", "S4bQ47Answer", "S4bQ48Answer", "S4bQ49Answer", "S4bQ50Answer", "S4bQ51Answer", "S4bQ52Answer", "S4bQ53Answer", "S4bQ54Answer", "S4bQ55Answer", "S4bQ56Answer", "S4bQ57Answer", "S4bQ58Answer", "S4bQ59Answer", "S4bQ60Answer", "S4bQ61Answer", "S4bQ62Answer", "S4bQ63Answer" }))
                    {
                        try
                        {
                            db.SaveChanges();
                            if (command.Equals("继续"))
                            {
                                return RedirectToAction("S4bPageSum");
                            }
                            else if (command.Equals("回到加入创业测试第一部分"))
                            {
                                return RedirectToAction("SectionBack4b");
                            }
                            else if (command.Equals("保存并退出"))
                            {
                                return RedirectToAction("SectionSaved");
                            }
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
                Session["error"] = "页面显示超时，请重新测试。";
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

            string S1Q3Ans = "";
            string S1Q3Msg = "";
            string S1Q6Ans = "";
            string S1Q6Msg = "";
            string S1Q9Ans = "";
            string S1Q9Msg = "";
            string S1Q13Ans = "";
            string S1Q13Msg = "";
            string S1Q14Ans = "";
            string S1Q14Msg = "";
            string S1Q16Ans = "";
            string S1Q16Msg = "";
            string S2Q1Ans = "";
            string S2Q1Msg = "";
            string S2Q2Ans = "";
            string S2Q2Msg = "";
            string S2Q3Ans = "";
            string S2Q3Msg = "";
            string S2Q4Ans = "";
            string S2Q4Msg = "";
            string S2Q5Ans = "";
            string S2Q5Msg = "";
            string S2Q6Ans = "";
            string S2Q6Msg = "";
            string S2Q7Ans = "";
            string S2Q7Msg = "";
            string S2Q8Ans = "";
            string S2Q8Msg = "";
            string S2Q9Ans = "";
            string S2Q9Msg = "";
            string S2Q10Ans = "";
            string S2Q10Msg = "";
            string S3Q1Ans = "";
            string S3Q1Msg = "";
            string S3Q2Ans = "";
            string S3Q2Msg = "";
            string S3Q3Ans = "";
            string S3Q3Msg = "";
            string S3Q4Ans = "";
            string S3Q4Msg = "";
            string S3Q5Ans = "";
            string S3Q5Msg = "";
            string S3Q6Ans = "";
            string S3Q6Msg = "";
            string S3Q7Ans = "";
            string S3Q7Msg = "";
            string S3Q8Ans = "";
            string S3Q8Msg = "";
            string S3Q9Ans = "";
            string S3Q9Msg = "";
            string S3Q10Ans = "";
            string S3Q10Msg = "";

            if (Session["viewKey"] != null)
            {
                id = Session["viewKey"].ToString();
            }
            else
            {
                Session["error"] = "页面显示超时，请重新测试。";
                return View("Error");
            }

            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Survey survey = db.Surveys.Find(id);

            if (survey != null)
            {
                S1Score = survey.S1Q3Score + survey.S1Q6Score + survey.S1Q9Score + survey.S1Q13Score + survey.S1Q14Score + survey.S1Q16Score;
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

                ViewBag.Section1Question1Anwser = survey.S1Q1Answer;
                ViewBag.Section1Question2Anwser = survey.S1Q2Answer;

                if (survey.S1Q3Answer == "UK")
                {
                    S1Q3Ans = "英国";
                    S1Q3Msg = "您在英国取得学士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q3Answer == "China" || survey.S1Q3Answer == "Other")
                {
                    S1Q3Ans = "中国或其它国家";
                    S1Q3Msg = "您在英国以外国家取得学士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q3Ans = "无学士学历";
                    S1Q3Msg = "您没有取得学士学位，此处不加分。";
                }

                ViewBag.Section1Question3Anwser = S1Q3Ans;
                ViewBag.Section1Question3AnwserMessage = S1Q3Msg;

                ViewBag.Section1Question4Anwser = survey.S1Q4Answer;
                ViewBag.Section1Question5Anwser = survey.S1Q5Answer;

                if (survey.S1Q6Answer == "UK")
                {
                    S1Q6Ans = "英国";
                    S1Q6Msg = "您在英国取得硕士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q6Answer == "China" || survey.S1Q6Answer == "Other")
                {
                    S1Q6Ans = "中国或其它国家";
                    S1Q6Msg = "您在英国以外国家取得硕士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q6Ans = "无硕士学历";
                    S1Q6Msg = "您没有取得硕士学位，此处不加分。";
                }

                ViewBag.Section1Question6Anwser = S1Q6Ans;
                ViewBag.Section1Question6AnwserMessage = S1Q6Msg;

                ViewBag.Section1Question7Anwser = survey.S1Q7Answer;
                ViewBag.Section1Question8Anwser = survey.S1Q8Answer;

                if (survey.S1Q9Answer == "UK")
                {
                    S1Q9Ans = "英国";
                    S1Q9Msg = "您在英国取得博士学位，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q9Answer == "China" || survey.S1Q9Answer == "Other")
                {
                    S1Q9Ans = "中国或其它国家";
                    S1Q9Msg = "您在英国以外国家取得博士学位，但这对于企业家移民签证申请没有帮助，此处不加分。";
                }
                else
                {
                    S1Q9Ans = "无硕士学历";
                    S1Q9Msg = "您没有取得博士学位，此处不加分。";
                }

                ViewBag.Section1Question9Anwser = S1Q9Ans;
                ViewBag.Section1Question9AnwserMessage = S1Q9Msg;

                ViewBag.Section1Question10Anwser = survey.S1Q10Answer;
                ViewBag.Section1Question11Anwser = survey.S1Q11Answer;
                ViewBag.Section1Question12Anwser = survey.S1Q12Answer;

                if (survey.S1Q13Answer == "exp3")
                {
                    S1Q13Ans = "三年以上";
                    S1Q13Msg = "您的工作经验在三年以上，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else
                {
                    S1Q13Ans = "少于三年";
                    S1Q13Msg = "您的工作经验少于三年，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question13Anwser = S1Q13Ans;
                ViewBag.Section1Question13AnwserMessage = S1Q13Msg;

                if (survey.S1Q13Answer == "exp3")
                {
                    S1Q13Ans = "三年以上";
                    S1Q13Msg = "您的工作经验在三年以上，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else if (survey.S1Q13Answer == "exp2")
                {
                    S1Q13Ans = "一到三年";
                    S1Q13Msg = "您的工作经验是一到三年，这对于企业家移民签证申请有一定的帮助, 此处加5分。";
                }
                else
                {
                    S1Q13Ans = "一年以内";
                    S1Q13Msg = "您的工作经验较少，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question13Anwser = S1Q13Ans;
                ViewBag.Section1Question13AnwserMessage = S1Q13Msg;

                if (survey.S1Q14Answer == "yes")
                {
                    S1Q14Ans = "相关";
                    S1Q14Msg = "您的工作与英国相关，这有助于您的企业家移民签证申请，此处加10分。";
                }
                else
                {
                    S1Q14Ans = "不相关";
                    S1Q14Msg = "您的工作与英国不相关，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question14Anwser = S1Q14Ans;
                ViewBag.Section1Question14AnwserMessage = S1Q14Msg;

                ViewBag.Section1Question15Anwser = survey.S1Q15Answer;

                if (survey.S1Q16Answer == "time4")
                {
                    S1Q16Ans = "三年以上";
                    S1Q16Msg = "您在英国停留累计时间超过三年，这非常有助于您的企业家移民签证申请，此处加30分。";
                }
                else if (survey.S1Q16Answer == "time3")
                {
                    S1Q16Ans = "一到三年";
                    S1Q16Msg = "您在英国停留累计时间在一到三年之间，这有助于您的企业家移民签证申请，此处加20分。";
                }
                else if (survey.S1Q16Answer == "time2")
                {
                    S1Q16Ans = "半年到一年";
                    S1Q16Msg = "您在英国停留累计时间在半年到一年之间，这对于您的企业家移民签证申请有一定帮助，此处加10分。";
                }
                else
                {
                    S1Q16Ans = "半年以内";
                    S1Q16Msg = "您在英国停留累计时间少于半年，这对于企业家移民签证申请没有帮助, 此处不加分。";
                }

                ViewBag.Section1Question16Anwser = S1Q16Ans;
                ViewBag.Section1Question16AnwserMessage = S1Q16Msg;

                ViewBag.Section1Question17Anwser = survey.S1Q17Answer;
                ViewBag.Section1Question18Anwser = survey.S1Q18Answer;
                ViewBag.Section1Question19Anwser = survey.S1Q19Answer;

                if (survey.S2Q1Answer == "immigration")
                {
                    S2Q1Ans = "移民";
                    S2Q1Msg = "申请企业家移民的主要目的一定是创业，并且要具备企业家精神，移民不是理想答案，此处不加分。";
                }
                else if (survey.S2Q1Answer == "business")
                {
                    S2Q1Ans = "创业";
                    S2Q1Msg = "创业是申请企业家移民的最主要目的，并且要让自己具备企业家精神，您的答案正确，此处加10分。";
                }
                else if (survey.S2Q1Answer == "education")
                {
                    S2Q1Ans = "孩子教育";
                    S2Q1Msg = "申请企业家移民的主要目的一定是创业，并且要具备企业家精神，孩子教育不是理想答案，此处不加分。";
                }

                ViewBag.Section2Question1Anwser = S2Q1Ans;
                ViewBag.Section2Question1AnwserMessage = S2Q1Msg;

                if (survey.S2Q2Answer == "yes")
                {
                    S2Q2Ans = "可以";
                    S2Q2Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q2Answer == "no")
                {
                    S2Q2Ans = "不可以";
                    S2Q2Msg = "您可以与其它人以合伙人的方式申请企业家移民签证，要想了解更多信息请联系我们，此处不加分。";
                }

                ViewBag.Section2Question2Anwser = S2Q2Ans;
                ViewBag.Section2Question2AnwserMessage = S2Q2Msg;

                if (survey.S2Q3Answer == "lessthanielts4")
                {
                    S2Q3Ans = "雅思 4 分以下";
                    S2Q3Msg = "企业家移民签证的最低雅思分数要求是4分。您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q3Answer == "ielts4orabove")
                {
                    S2Q3Ans = "雅思 4 分以上（包括 4 分）";
                    S2Q3Msg = "答案正确，此处加10分。";
                }

                ViewBag.Section2Question3Anwser = S2Q3Ans;
                ViewBag.Section2Question3AnwserMessage = S2Q3Msg;

                if (survey.S2Q4Answer == "200k")
                {
                    S2Q4Ans = "20万";
                    S2Q4Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q4Answer == "100k")
                {
                    S2Q4Ans = "10万";
                    S2Q4Msg = "企业家移民要求的最低投资金额是20万英镑，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q4Answer == "50k")
                {
                    S2Q4Ans = "5万";
                    S2Q4Msg = "企业家移民要求的最低投资金额是20万英镑，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question4Anwser = S2Q4Ans;
                ViewBag.Section2Question4AnwserMessage = S2Q4Msg;

                if (survey.S2Q5Answer == "cantwork")
                {
                    S2Q5Ans = "不能为他人工作";
                    S2Q5Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q5Answer == "canwork")
                {
                    S2Q5Ans = "可以为他人工作";
                    S2Q5Msg = "企业家移民签证的主申请人是不可以为他人工作的。您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question5Anwser = S2Q5Ans;
                ViewBag.Section2Question5AnwserMessage = S2Q5Msg;

                if (survey.S2Q6Answer == "can")
                {
                    S2Q6Ans = "可以";
                    S2Q6Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q6Answer == "cant")
                {
                    S2Q6Ans = "不可以";
                    S2Q6Msg = "企业家移民签证的主申请人是可以带自己的配偶和未满18岁的小孩来英国的。您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question6Anwser = S2Q6Ans;
                ViewBag.Section2Question6AnwserMessage = S2Q6Msg;

                if (survey.S2Q7Answer == "100")
                {
                    S2Q7Ans = "200 左右";
                    S2Q7Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q7Answer == "500")
                {
                    S2Q7Ans = "500 左右";
                    S2Q7Msg = "正确答案为100人左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q7Answer == "1000")
                {
                    S2Q7Ans = "1000 左右";
                    S2Q7Msg = "正确答案为100人左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question7Anwser = S2Q7Ans;
                ViewBag.Section2Question7AnwserMessage = S2Q7Msg;

                if (survey.S2Q8Answer == "can")
                {
                    S2Q8Ans = "可以";
                    S2Q8Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q8Answer == "cant")
                {
                    S2Q8Ans = "不可以";
                    S2Q8Msg = "企业家移民分独立创业和加入创业两种模式，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question8Anwser = S2Q8Ans;
                ViewBag.Section2Question8AnwserMessage = S2Q8Msg;

                if (survey.S2Q9Answer == "2employee")
                {
                    S2Q9Ans = "2 个全职员工，至少每个员工职位超过 12 个月";
                    S2Q9Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q9Answer == "1employee")
                {
                    S2Q9Ans = "1 个全职员工，至少职位超过 24 个月";
                    S2Q9Msg = "企业家需要在3年内雇佣2个持有英国护照的全职员工，并且至少每位员工在职要超过12个月，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question9Anwser = S2Q9Ans;
                ViewBag.Section2Question9AnwserMessage = S2Q9Msg;

                if (survey.S2Q10Answer == "200k")
                {
                    S2Q10Ans = "能够证明有超过20万英镑的存款";
                    S2Q10Msg = "证明信的最关键要素是能够证明资金可以自由转入英国，您的答案不正确，此处不加分。";
                }
                else if (survey.S2Q10Answer == "freedom")
                {
                    S2Q10Ans = "能够证明资金可以自由转入英国";
                    S2Q10Msg = "答案正确，此处加10分。";
                }
                else if (survey.S2Q10Answer == "3months")
                {
                    S2Q10Ans = "能够证明资金在银行户头超过3个月";
                    S2Q10Msg = "证明信的最关键要素是能够证明资金可以自由转入英国，您的答案不正确，此处不加分。";
                }

                ViewBag.Section2Question10Anwser = S2Q10Ans;
                ViewBag.Section2Question10AnwserMessage = S2Q10Msg;

                if (survey.S3Q1Answer == "20pct")
                {
                    S3Q1Ans = "20%";
                    S3Q1Msg = "答案正确，此处加10分。";
                }
                else if (survey.S3Q1Answer == "17pct")
                {
                    S3Q1Ans = "17%";
                    S3Q1Msg = "英国 VAT 税率为 20%，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q1Answer == "14pct")
                {
                    S3Q1Ans = "14%";
                    S3Q1Msg = "英国 VAT 税率为 20%，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question1Anwser = S3Q1Ans;
                ViewBag.Section3Question1AnwserMessage = S3Q1Msg;

                if (survey.S3Q2Answer == "yes")
                {
                    S3Q2Ans = "需要";
                    S3Q2Msg = "答案正确，此处加10分。";
                }
                else if (survey.S3Q2Answer == "no")
                {
                    S3Q2Ans = "不需要";
                    S3Q2Msg = "在英国开公司是需要买保险的，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question2Anwser = S3Q2Ans;
                ViewBag.Section3Question2AnwserMessage = S3Q2Msg;

                if (survey.S3Q3Answer == "6.00")
                {
                    S3Q3Ans = "6.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q3Answer == "7.00")
                {
                    S3Q3Ans = "7.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q3Answer == "8.00")
                {
                    S3Q3Ans = "8.00";
                    S3Q3Msg = "截至到2018年6月，英国最低工资是每小时 7.83 镑, 您的答案正确，此处加10分。";
                }

                ViewBag.Section3Question3Anwser = S3Q3Ans;
                ViewBag.Section3Question3AnwserMessage = S3Q3Msg;

                if (survey.S3Q4Answer == "15k")
                {
                    S3Q4Ans = "1万5千镑";
                    S3Q4Msg = "聘请一位有3年工作经验的项目开发经理需要支付2万5千镑左右的年薪，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q4Answer == "25k")
                {
                    S3Q4Ans = "2万5千镑";
                    S3Q4Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q4Answer == "50k")
                {
                    S3Q4Ans = "5万镑";
                    S3Q4Msg = "聘请一位有3年工作经验的项目开发经理需要支付2万5千镑左右的年薪，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question4Anwser = S3Q4Ans;
                ViewBag.Section3Question4AnwserMessage = S3Q4Msg;

                if (survey.S3Q5Answer == "1k")
                {
                    S3Q5Ans = "1千镑";
                    S3Q5Msg = "ZONE2四人办公室一个月租金是2千镑左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q5Answer == "2k")
                {
                    S3Q5Ans = "2千镑";
                    S3Q5Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q5Answer == "5k")
                {
                    S3Q5Ans = "5千镑";
                    S3Q5Msg = "ZONE2四人办公室一个月租金是2千镑左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question5Anwser = S3Q5Ans;
                ViewBag.Section3Question5AnwserMessage = S3Q5Msg;

                if (survey.S3Q6Answer == "20pct")
                {
                    S3Q6Ans = "20%";
                    S3Q6Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q6Answer == "25pct")
                {
                    S3Q6Ans = "25%";
                    S3Q6Msg = "纳税工资部分缴纳比例是20%, 您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q6Answer == "28pct")
                {
                    S3Q6Ans = "28%";
                    S3Q6Msg = "纳税工资部分缴纳比例是20%, 您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question6Anwser = S3Q6Ans;
                ViewBag.Section3Question6AnwserMessage = S3Q6Msg;

                if (survey.S3Q7Answer == "yes")
                {
                    S3Q7Ans = "咨询过";
                    S3Q7Msg = "如果您咨询过移民律师或类似的企业家签证持有人对您的签证申请会有帮助，此处加10分。";
                }
                else if (survey.S3Q7Answer == "no")
                {
                    S3Q7Ans = "从未咨询过";
                    S3Q7Msg = "我们建议您咨询移民律师或类似的企业家签证持有人，这样对您的企业家移民签证申请会有帮助，此处不加分。";
                }

                ViewBag.Section3Question7Anwser = S3Q7Ans;
                ViewBag.Section3Question7AnwserMessage = S3Q7Msg;

                if (survey.S3Q8Answer == "1500")
                {
                    S3Q8Ans = "1500";
                    S3Q8Msg = "会计服务费用在2500镑左右，您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q8Answer == "2500")
                {
                    S3Q8Ans = "2500";
                    S3Q8Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q8Answer == "3500")
                {
                    S3Q8Ans = "3500";
                    S3Q8Msg = "会计服务费用在2500镑左右，您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question8Anwser = S3Q8Ans;
                ViewBag.Section3Question8AnwserMessage = S3Q8Msg;

                if (survey.S3Q9Answer == "")
                {
                    S3Q9Ans = "";
                    S3Q9Msg = "您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q9Answer == "")
                {
                    S3Q9Ans = "";
                    S3Q9Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q9Answer == "")
                {
                    S3Q9Ans = "";
                    S3Q9Msg = "您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question9Anwser = S3Q9Ans;
                ViewBag.Section3Question9AnwserMessage = S3Q9Msg;

                if (survey.S3Q10Answer == "")
                {
                    S3Q10Ans = "";
                    S3Q10Msg = "您的答案不正确，此处不加分。";
                }
                else if (survey.S3Q10Answer == "")
                {
                    S3Q10Ans = "";
                    S3Q10Msg = "您的答案正确，此处加10分。";
                }
                else if (survey.S3Q10Answer == "")
                {
                    S3Q10Ans = "";
                    S3Q10Msg = "您的答案不正确，此处不加分。";
                }

                ViewBag.Section3Question10Anwser = S3Q10Ans;
                ViewBag.Section3Question10AnwserMessage = S3Q10Msg;

                ViewBag.Section4bQuestion1Anwser = survey.S4bQ1Answer;
                ViewBag.Section4bQuestion2Anwser = survey.S4bQ2Answer;
                ViewBag.Section4bQuestion3Anwser = survey.S4bQ3Answer;
                ViewBag.Section4bQuestion4Anwser = survey.S4bQ4Answer;
                ViewBag.Section4bQuestion5Anwser = survey.S4bQ5Answer;
                ViewBag.Section4bQuestion6Anwser = survey.S4bQ6Answer;
                ViewBag.Section4bQuestion7Anwser = survey.S4bQ7Answer;
                ViewBag.Section4bQuestion8Anwser = survey.S4bQ8Answer;
                ViewBag.Section4bQuestion9Anwser = survey.S4bQ9Answer;
                ViewBag.Section4bQuestion10Anwser = survey.S4bQ10Answer;
                ViewBag.Section4bQuestion11Anwser = survey.S4bQ11Answer;
                ViewBag.Section4bQuestion12Anwser = survey.S4bQ12Answer;
                ViewBag.Section4bQuestion13Anwser = survey.S4bQ13Answer;
                ViewBag.Section4bQuestion14Anwser = survey.S4bQ14Answer;
                ViewBag.Section4bQuestion15Anwser = survey.S4bQ15Answer;
                ViewBag.Section4bQuestion16Anwser = survey.S4bQ16Answer;
                ViewBag.Section4bQuestion17Anwser = survey.S4bQ17Answer;
                ViewBag.Section4bQuestion18Anwser = survey.S4bQ18Answer;
                ViewBag.Section4bQuestion19Anwser = survey.S4bQ19Answer;
                ViewBag.Section4bQuestion20Anwser = survey.S4bQ20Answer;
                ViewBag.Section4bQuestion21Anwser = survey.S4bQ21Answer;
                ViewBag.Section4bQuestion22Anwser = survey.S4bQ22Answer;
                ViewBag.Section4bQuestion23Anwser = survey.S4bQ23Answer;
                ViewBag.Section4bQuestion24Anwser = survey.S4bQ24Answer;
                ViewBag.Section4bQuestion25Anwser = survey.S4bQ25Answer;
                ViewBag.Section4bQuestion26Anwser = survey.S4bQ26Answer;
                ViewBag.Section4bQuestion27Anwser = survey.S4bQ27Answer;
                ViewBag.Section4bQuestion28Anwser = survey.S4bQ28Answer;
                ViewBag.Section4bQuestion29Anwser = survey.S4bQ29Answer;
                ViewBag.Section4bQuestion30Anwser = survey.S4bQ30Answer;
                ViewBag.Section4bQuestion31Anwser = survey.S4bQ31Answer;
                ViewBag.Section4bQuestion32Anwser = survey.S4bQ32Answer;
                ViewBag.Section4bQuestion33Anwser = survey.S4bQ33Answer;
                ViewBag.Section4bQuestion34Anwser = survey.S4bQ34Answer;
                ViewBag.Section4bQuestion35Anwser = survey.S4bQ35Answer;
                ViewBag.Section4bQuestion36Anwser = survey.S4bQ36Answer;
                ViewBag.Section4bQuestion37Anwser = survey.S4bQ37Answer;
                ViewBag.Section4bQuestion38Anwser = survey.S4bQ38Answer;
                ViewBag.Section4bQuestion39Anwser = survey.S4bQ39Answer;
                ViewBag.Section4bQuestion40Anwser = survey.S4bQ40Answer;
                ViewBag.Section4bQuestion41Anwser = survey.S4bQ41Answer;
                ViewBag.Section4bQuestion42Anwser = survey.S4bQ42Answer;
                ViewBag.Section4bQuestion43Anwser = survey.S4bQ43Answer;
                ViewBag.Section4bQuestion44Anwser = survey.S4bQ44Answer;
                ViewBag.Section4bQuestion45Anwser = survey.S4bQ45Answer;
                ViewBag.Section4bQuestion46Anwser = survey.S4bQ46Answer;
                ViewBag.Section4bQuestion47Anwser = survey.S4bQ47Answer;
                ViewBag.Section4bQuestion48Anwser = survey.S4bQ48Answer;
                ViewBag.Section4bQuestion49Anwser = survey.S4bQ49Answer;
                ViewBag.Section4bQuestion50Anwser = survey.S4bQ50Answer;
                ViewBag.Section4bQuestion51Anwser = survey.S4bQ51Answer;
                ViewBag.Section4bQuestion52Anwser = survey.S4bQ52Answer;
                ViewBag.Section4bQuestion53Anwser = survey.S4bQ53Answer;
                ViewBag.Section4bQuestion54Anwser = survey.S4bQ54Answer;
                ViewBag.Section4bQuestion55Anwser = survey.S4bQ55Answer;
                ViewBag.Section4bQuestion56Anwser = survey.S4bQ56Answer;
                ViewBag.Section4bQuestion57Anwser = survey.S4bQ57Answer;
                ViewBag.Section4bQuestion58Anwser = survey.S4bQ58Answer;
                ViewBag.Section4bQuestion59Anwser = survey.S4bQ59Answer;
                ViewBag.Section4bQuestion60Anwser = survey.S4bQ60Answer;
                ViewBag.Section4bQuestion61Anwser = survey.S4bQ61Answer;
                ViewBag.Section4bQuestion62Anwser = survey.S4bQ62Answer;
                ViewBag.Section4bQuestion63Anwser = survey.S4bQ63Answer;

                return View("Section4b/S4bPageSum");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}