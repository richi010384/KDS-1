using KDS.Domain.Entities;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KDS.Presentation.Seedwork.Extensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<UnidadNegocio> unidadesNegocio, string selectedId = null)
        {
            return
                unidadesNegocio.OrderBy(x => x.Nombre)
                               .Select(x =>
                                   new SelectListItem
                                   {
                                       Selected = !string.IsNullOrWhiteSpace(selectedId) && (x.CodUnidadNegocio == selectedId),
                                       Text = x.Nombre,
                                       Value = x.CodUnidadNegocio.ToString()
                                   });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<Grupo> grupos, string selectedId = null)
        {
            return
                grupos.OrderBy(x => x.Nombre)
                      .Select(x =>
                          new SelectListItem
                          {
                              Selected = !string.IsNullOrWhiteSpace(selectedId) && (x.CodGrupo == selectedId),
                              Text = x.Nombre,
                              Value = x.CodGrupo.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<Subgrupo> subgrupos, string selectedId = null)
        {
            return
                subgrupos.OrderBy(x => x.Nombre)
                      .Select(x =>
                          new SelectListItem
                          {
                              Selected = !string.IsNullOrWhiteSpace(selectedId) && (x.CodSubGrupo == selectedId),
                              Text = x.Nombre,
                              Value = x.CodSubGrupo.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<PtoPreparacion> ptosPreparacion, int? selectedId = null)
        {
            return
                ptosPreparacion.OrderBy(x => x.Descripcion)
                               .Select(x =>
                                   new SelectListItem
                                   {
                                       Selected = selectedId != null && x.CodPtoPreparacion == selectedId,
                                       Text = x.Nombre,
                                       Value = x.CodPtoPreparacion.ToString()
                                   });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems_Nombre(
            this IEnumerable<Parametrica> parametros, int selectedId = 0)
        {
            return
                parametros.OrderBy(x => x.CodParametrica)
                      .Select(x =>
                          new SelectListItem
                          {
                              Selected = selectedId != 0 && (x.CodParametrica == selectedId),
                              Text = x.Nombre + " [" + x.Descripcion + "]",
                              Value = x.Nombre.ToString()
                          });
        }

        public static string ToResponse(IEnumerable<SelectListItem> items)
        {
            var arreglo = new ArrayList();
            foreach (var obj in items)
            {
                var json = new
                {
                    Text = obj.Text,
                    Value = obj.Value
                };
                arreglo.Add(json);
            }
            return JsonConvert.SerializeObject(arreglo);
        }
    }

}
