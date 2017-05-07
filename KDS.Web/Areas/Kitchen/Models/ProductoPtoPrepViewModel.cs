using KDS.Presentation.Seedwork.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Models
{
    public class ProductoPtoPrepViewModel
    {
        [Key]
        public string CodProductoPtoPrep { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Unidad de negocio")]
        public string CodUnidadNegocio { get; set; }
        public IEnumerable<SelectListItem> UnidadesNegocio { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Punto de preparación")]
        public int? CodPtoPreparacion { get; set; }
        public IEnumerable<SelectListItem> PtosPreparacion { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        public string CodProducto { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Producto")]
        public string DescProducto { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Range(0, 60, ErrorMessage = "Debe ser un valor entre {1} y {2}.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Debe ser un número entero.")]
        [Display(Name = "Directo")]
        public int TiempoPrepDirecto { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Range(0, 60, ErrorMessage = "Debe ser un valor entre {1} y {2}.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Debe ser un número entero.")]
        [Display(Name = "Segundo")]
        public int TiempoPrepSegundo { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Range(0, 20, ErrorMessage = "Debe ser un valor entre {1} y {2}.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Debe ser un número entero.")]
        [Display(Name = "Minima")]
        public int MinCantidad { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Range(0, 20, ErrorMessage = "Debe ser un valor entre {1} y {2}.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Debe ser un número entero.")]
        [Display(Name = "Máxima")]
        public int MaxCantidad { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Punto de ensamblado")]
        public bool IndEnsamblado { get; set; }
    }
}