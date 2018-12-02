using System.Web;
using System.Web.Mvc;

namespace _24N.tv_Refresh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}