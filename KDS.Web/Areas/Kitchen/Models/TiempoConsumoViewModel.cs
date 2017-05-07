//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using KDS.Presentation.Seedwork.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Models
{
    public class BandejaTiempoConsumoViewModel
    {
        //Para filtros de Grupos 
        //No hay definidos de momento

        //Para filtros de Sub-Grupos 
        [Display(Name = "Familia")]
        public string SubGrupo_CodGrupo { get; set; }
        public IEnumerable<SelectListItem> SubGrupo_ItemsGrupos { get; set; }

        //Para filtros de Productos 
        [Display(Name = "Producto")]
        public string Producto_DescProducto { get; set; }

        [Display(Name = "Familia")]
        public string Producto_CodGrupo { get; set; }

        [Display(Name = "Sub-Familia")]
        public string Producto_CodSubGrupo { get; set; }

        public IEnumerable<SelectListItem> Producto_ItemsGrupos { get; set; }

        public IEnumerable<SelectListItem> Producto_ItemsSubGrupos { get; set; }
    }

    public class TiempoConsumoViewModel
    {
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        [Display(Name = "Código")]
        public int CodTiempoConsumo { get; set; }

        [Display(Name = "Código Producto")]
        public string CodProducto { get; set; }

        [Display(Name = "Producto")]
        public string DescProducto { get; set; }

        [Display(Name = "Código Familia")]
        public string CodGrupo { get; set; }

        [Display(Name = "Familia")]
        public string DescGrupo { get; set; }

        [Display(Name = "Código Sub-Familia")]
        public string CodSubGrupo { get; set; }

        [Display(Name = "Sub-Familia")]
        public string DescSubGrupo { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Modo Consumo")]
        public string CodPropiedad { get; set; }

        public IEnumerable<SelectListItem> LstModoConsumo { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [Display(Name = "Cant. Platos")]
        public Nullable<int> Cantidad { get; set; }

        public IEnumerable<SelectListItem> LstCantidad { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [RegularExpression("^[0-9]*$", ErrorMessage = ErrorMessage.DataAnnotation.SoloNumeros)]
        [Display(Name = "Máx. Comensales")]
        public Nullable<int> MaxComensales { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [RegularExpression("^[0-9]*$", ErrorMessage = ErrorMessage.DataAnnotation.SoloNumeros)]
        [Display(Name = "Mín. Comensales")]
        public Nullable<int> MinComensales { get; set; }

        [Required(ErrorMessage = ErrorMessage.DataAnnotation.CampoRequerido)]
        [RegularExpression("^[0-9]*$", ErrorMessage = ErrorMessage.DataAnnotation.SoloNumeros)]
        [Display(Name = "Tiempo (min)")]
        public Nullable<int> Tiempo { get; set; }

        [Display(Name = "Modo Consumo")]
        public string Filtro_CodPropiedad { get; set; }

        public IEnumerable<SelectListItem> Filtro_LstModoConsumo { get; set; }

        [Display(Name = "Cant. Platos")]
        public Nullable<int> Filtro_Cantidad { get; set; }
        public IEnumerable<SelectListItem> Filtro_LstCantidad { get; set; }
    }
}