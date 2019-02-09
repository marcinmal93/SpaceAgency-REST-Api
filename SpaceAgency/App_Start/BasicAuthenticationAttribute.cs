using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace SpaceAgency.App_Start
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                // decoding authToken we get decode value in 'Username:Password' format  
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                // spliting decodeauthToken using ':'   
                var arrUserNameandPassword = decodeauthToken.Split(':');

                // at 0th postion of array we get username and at 1st we get password  
                if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    // setting current principle  
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here...  
            return Username == "admin@spaceagency.com" && Password == "123$rewQ";
        }

        protected string[] RolesSplit
        {
            get { return SplitStrings(Roles); }
        }

        private bool CheckRoles(IPrincipal principal)
        {
            string[] roles = RolesSplit;
            if (roles.Length == 0) return true;
            return roles.Any(principal.IsInRole);
        }

        /// <;summary>;
        /// Implement to include authentication logic and create IPrincipal
        /// <;/summary>;
//        protected abstract bool TryCreatePrincipal(string user, string password,
//            out IPrincipal principal);


        protected static string[] SplitStrings(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[0];
            var result = input.Split(',')
                .Where(s => !String.IsNullOrWhiteSpace(s.Trim()));
            return result.Select(s => s.Trim()).ToArray();
        }
    }
}