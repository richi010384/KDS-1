using KDS.Infraestructure.CrossCutting.Entities;
using System;
using System.Web;
using Constante = KDS.Infraestructure.CrossCutting.Constants.App;

namespace KDS.Web.Helpers
{
    public class AppContext
    {
        public static Session Sesion
        {
            get
            {
                if (!Exists(Constante.NombreSesion))
                {
                    HttpContext.Current.Session[Constante.NombreSesion] = new Session();
                }
                return (Session)Convert.ChangeType(HttpContext.Current.Session[Constante.NombreSesion], typeof(Session));
            }
            set
            {
                if (value == null)
                {
                    Remove(Constante.NombreSesion);
                }
                else
                {
                    HttpContext.Current.Session[Constante.NombreSesion] = value;
                }
            }
        }

        public static bool Exists(string sessionVariable)
        {
            return HttpContext.Current.Session[sessionVariable] != null;
        }

        public static void Remove(string sessionVariable)
        {
            HttpContext.Current.Session.Remove(sessionVariable);
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}