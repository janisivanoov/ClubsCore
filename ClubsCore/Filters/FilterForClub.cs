using ClubsCore.Models;
using System;
using System.Web.Http.Controllers;

namespace ClubsCore.Filters
{
    public class FilterForClub
    {
        private string parameter = "KeyDataForClub";

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments == null || !actionContext.ActionArguments.ContainsKey(parameter))
            {
                throw new Exception(string.Format("Parameter '{0}' not present", parameter));
            }

            Club club = actionContext.ActionArguments[parameter] as Club;

            if (String.IsNullOrEmpty(club.Type))
            {
                throw new Exception("Error: could not find key data");
            }
        }
    }
}