using Microsoft.Owin.Security.OAuth;

using Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCuuTro.App_Start
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            OAuthOptions = new OAuthBearerAuthenticationOptions
            {

            };
            app.UseOAuthBearerAuthentication(OAuthOptions);
        }
    }
}