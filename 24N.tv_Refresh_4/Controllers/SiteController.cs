using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using _24N.tv_Refresh.Models;

namespace _24N.tv_Refresh.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Index()
        {
            SetControllerETag(nameof(Index));
            return View();
        }

        public ActionResult Values()
        {
            //throw new ApplicationException("Testing Exception Handling Page");
            return View();
        }

        [ActionName("Bold-Ideas")]
        public ActionResult BoldIdeas()
        {
            return View();
        }

        public ActionResult Experiences()
        {
            SetControllerETag(nameof(Experiences));
            return View();
        }

        public ActionResult ExperiencesOS()
        {
            //Old School with carousel -- kept per Ivo's request
            return View();
        }

        public ActionResult Partners()
        {
            return View();
        }

        private const string _cFeedUrl = "https://24notion.net/category/press/rss";
        public ActionResult Updates()
        {
            //return Redirect("https://24notion.net")
            ViewBag.RssFeed = _RssReader.GetFeed(_cFeedUrl);
            return View();
        }

        public ActionResult Holiday()
        {
            return View();
        }

        public ActionResult Connect()
        {
            return View();
        }

        public ActionResult Vip()
        {
            return View();
        }

        public ActionResult Vvip()
        {
            return View();
        }

        private void SetControllerETag(string viewname)
        {
            string filePath = Server.MapPath($"~/Views/Site/{viewname}.cshtml");
            String etag = CheckMD5(filePath);
            base.Response.Cache.SetETag(etag);
        }

        private string CheckMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }
    }
}