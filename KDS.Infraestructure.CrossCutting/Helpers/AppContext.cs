using KDS.Infraestructure.CrossCutting.Constants;
using KDS.Infraestructure.CrossCutting.Entities;
using System;

namespace KDS.Infraestructure.CrossCutting.Helpers
{
    public class AppContext
    {
        //public static Session Sesion
        //{
        //    get
        //    {
        //        return (Session)Convert.ChangeType(System.Web.HttpContext.Current.Session[App.NombreSesion], typeof(Session));
        //    }
        //}

        public static Session Sesion
        {
            get
            {
                if (!Exists)
                {
                    System.Web.HttpContext.Current.Session[App.NombreSesion] = new Session();
                }
                return (Session)Convert.ChangeType(System.Web.HttpContext.Current.Session[App.NombreSesion], typeof(Session));
            }
            set
            {
                if (value == null)
                {
                    Remove();
                }
                else
                {
                    System.Web.HttpContext.Current.Session[App.NombreSesion] = value;
                }
            }
        }

        public static bool Exists
        {
            get
            {
                return System.Web.HttpContext.Current.Session[App.NombreSesion] != null;
            }
        }

        private static void Remove()
        {
            System.Web.HttpContext.Current.Session.Remove(App.NombreSesion);
        }

        //public static void Clear()
        //{
        //    System.Web.HttpContext.Current.Session.Clear();
        //}

        public static void Abandon()
        {
            System.Web.HttpContext.Current.Session.Abandon();
        }
    }
}