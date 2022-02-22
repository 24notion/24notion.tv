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
    }
}