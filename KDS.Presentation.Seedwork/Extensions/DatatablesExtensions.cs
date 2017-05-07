using DataTables.Mvc;
using KDS.Infraestructure.CrossCutting.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace KDS.Presentation.Seedwork.Extensions
{
    public static class DatatablesExtensions
    {
        public static Pagination ToPagination(this IDataTablesRequest request)
        {
            var columna = request.Columns.FirstOrDefault(x => x.OrderNumber == 0);
            return new Pagination
            {
                StartIndex = (short)(request.Start + 1),
                EndIndex = (short)(request.Start + request.Length),
                SortColumn = columna.Name,
                SortOrder = columna.SortDirection == Column.OrderDirection.Ascendant ? "ASC" : "DESC"
            };
        }

        public static string ToResponse(this string[][] data, Pagination paginacion)
        {
            return JsonConvert.SerializeObject(new
            {
                sEcho = string.Empty,
                aaData = data,
                iTotalDisplayRecords = paginacion.TotalDisplayRecords,
                iTotalRecords = paginacion.TotalRecords                
            });
        }
    }
}
