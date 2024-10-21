using System.Text.RegularExpressions;

namespace Class06
{
	public class MyRulesConstraint : IRouteConstraint
	{
		public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			if (routeKey != "letter")
				return false;

			return values[routeKey] is null || Regex.IsMatch((values[routeKey] as string), @"^[a-zA-ZÂÁÉÓ]$");
		}
	}
}
