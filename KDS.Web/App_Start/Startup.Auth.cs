using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace KDS.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
            // y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
            // Configurar cookie de inicio de sesión
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (!IsAjaxRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
            });
        }

        private bool IsAjaxRequest(IOwinRequest request)
        {
            var query = request.Query;
            if (query != null)
            {
                if (query["X-Requested-With"] == "XMLHttpRequest")
                {
                    return true;
                }
            }

            var headers = request.Headers;
            if (headers == null) return false;
            return headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}