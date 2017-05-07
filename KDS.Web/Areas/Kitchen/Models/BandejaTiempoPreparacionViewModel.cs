using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Models
{
    public class BandejaTiempoPreparacionViewModel
    {        
        [Display(Name = "Unidad de negocio")]
        public string CodUnidadNegocio { get; set; }
        public IEnumerable<SelectListItem> UnidadesNegocio { get; set; }

        [Display(Name = "Punto de preparación")]
        public int? CodPtoPreparacion { get; set; }
        public IEnumerable<SelectListItem> PtosPreparacion { get; set; }
    }
}