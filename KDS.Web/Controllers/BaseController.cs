using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Helpers;
using System.Web.Mvc;

namespace KDS.Web.Controllers
{
    public class BaseController : Controller
    {
        public Session MiSesion
        {
            get
            {
                return AppContext.Sesion;
            }
            set
            {
                AppContext.Sesion = value;
            }
        }
    }
}