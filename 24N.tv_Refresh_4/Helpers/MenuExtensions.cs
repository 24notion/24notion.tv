using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace _24N.tv_Refresh.Helpers
{
    public static class MenuExtensions
    {
        public static MvcHtmlString MenuItemLink(this HtmlHelper htmlHelper, string text, string action)
        {
            return MenuItemLink(htmlHelper, text, action, null, null, null);
        }

        public static MvcHtmlString MenuItemLink(this HtmlHelper htmlHelper, string text, string action, string controller)
        {
            return MenuItemLink(htmlHelper, text, action, controller, null, null);
        }

        public static MvcHtmlString MenuItemLink(this HtmlHelper htmlHelper, string text, string action, string controller, object routeValues)
        {
            return MenuItemLink(htmlHelper, text, action, controller, routeValues, null);
        }

        public static MvcHtmlString MenuItemLink(this HtmlHelper htmlHelper, string text, string action,
            string controller, object routeValues, object htmlAttributes)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var passedAction = action ?? routeData.GetRequiredString("action");
            var passedController = controller ?? routeData.GetRequiredString("controller");
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");

            var li = new TagBuilder("li");
            if (String.Equals(currentAction, passedAction, StringComparison.OrdinalIgnoreCase) && String.Equals(currentController, passedController, StringComparison.OrdinalIgnoreCase))
                li.AddCssClass("active");
            li.InnerHtml = htmlHelper.ActionLink(text, passedAction, passedController, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)).ToHtmlString();

            return MvcHtmlString.Create(li.ToString());
        }
    }
}