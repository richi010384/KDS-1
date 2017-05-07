using KDS.Presentation.Seedwork.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Models
{
    public class PtoPreparacionViewModel
    {
        [Key]
        public string CodPtoPreparacion { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Unidad de negocio")]
        public string CodUnidadNegocio { get; set; }
        public IEnumerable<SelectListItem> UnidadesNegocio { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [MinLength(2, ErrorMessage = ErrorMessage.DataAnnotation.LongitudMinima)]
        [MaxLength(40, ErrorMessage = ErrorMessage.DataAnnotation.LongitudMaxima)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [MaxLength(400, ErrorMessage = ErrorMessage.DataAnnotation.LongitudMaxima)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}