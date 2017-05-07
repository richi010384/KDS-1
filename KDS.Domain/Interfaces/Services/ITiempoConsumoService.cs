//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using KDS.Domain.Entities;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface ITiempoConsumoService : IServiceBase<TiempoConsumo>
    {
        IEnumerable<TiempoConsumo> ListarPorGrupos(string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion);
        IEnumerable<TiempoConsumo> ListarPorSubGrupos(string CodSubGrupo, string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion);
        IEnumerable<TiempoConsumo> ListarPorProductos(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, string CodPropiedad, int Cantidad, ref Pagination paginacion);
        IEnumerable<Grupo> ListarMaestroGrupo(string CodGrupo, ref Pagination paginacion);
        IEnumerable<Subgrupo> ListarMaestroSubGrupo(string CodSubGrupo, string CodGrupo, ref Pagination paginacion);
        IEnumerable<Producto> ListarMaestroProducto(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, ref Pagination paginacion);
        IEnumerable<Grupo> ListarGrupos();
        IEnumerable<Subgrupo> ListarSubGrupos(string CodGrupo);
        IEnumerable<Parametrica> ListarParametros(int CodTipoParametro);
        ValidationResult Guardar(TiempoConsumo tconsumo);
        ValidationResult Actualizar(TiempoConsumo tconsumo);
        ValidationResult Eliminar(int id);
    }
}
