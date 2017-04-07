using System.Web.Mvc;

namespace MvcEventVolunteeringDemo
{
	public static class Generics
	{
		public static string IfNullString(object text)
		{
			string s = string.Empty;
			try
			{
				s = text.ToString().Trim();
			}
			catch
			{
				s = string.Empty;
			}
			return s;
		}

		public static MvcHtmlString IsDisabled(this MvcHtmlString htmlString, bool disabled)
		{
			string rawstring = htmlString.ToString();
			if (disabled)
			{
				rawstring = rawstring.Insert(rawstring.Length - 2, "disabled=\"disabled\"");
			}
			return new MvcHtmlString(rawstring);
		}

		public static MvcHtmlString IsReadonly(this MvcHtmlString htmlString, bool @readonly)
		{
			string rawstring = htmlString.ToString();
			if (@readonly)
			{
				rawstring = rawstring.Insert(rawstring.Length - 2, "readonly=\"readonly\"");
			}
			return new MvcHtmlString(rawstring);
		}
	}
}


