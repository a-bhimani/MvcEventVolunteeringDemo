using MvcEventVolunteeringDemo.Models;
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcEventVolunteeringDemo
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			CultureInfo newCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
			newCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
			newCulture.DateTimeFormat.DateSeparator = "/";
			Thread.CurrentThread.CurrentCulture = newCulture;
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
