using ClubsCore.Models;
using System;
using System.Web.Http.Controllers;

namespace ClubsCore.Filters
{
    public class FilterForStudent
    {
        private string parameter = "KeyDataForStudent";

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments == null || !actionContext.ActionArguments.ContainsKey(parameter))
            {
                throw new Exception(string.Format("Parameter '{0}' not present", parameter));
            }

            Student student = actionContext.ActionArguments[parameter] as Student;

            if (String.IsNullOrEmpty(student.FirstName) || String.IsNullOrEmpty(student.LastName))
            {
                throw new Exception("Error: could not find key data");
            }
        }
    }
}