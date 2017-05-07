using KDS.Presentation.Seedwork.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Models
{
    public class BandejaPtoPreparacionViewModel
    {        
        [Display(Name = "Unidad de negocio")]
        public string CodUnidadNegocio { get; set; }
        public IEnumerable<SelectListItem> UnidadesNegocio { get; set; }
    }
}