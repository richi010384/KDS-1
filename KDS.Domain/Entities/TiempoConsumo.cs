//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using System;

namespace KDS.Domain.Entities
{
    public class TiempoConsumo
    {
        public int CodTiempoConsumo { get; set; }
        public string CodGrupo { get; set; }
        public string DescGrupo { get; set; }
        public string CodSubGrupo { get; set; }
        public string DescSubGrupo { get; set; }
        public string CodProducto { get; set; }
        public string DescProducto { get; set; }
        public string CodPropiedad { get; set; }
        public int Cantidad { get; set; }
        public int MinComensales { get; set; }
        public int MaxComensales { get; set; }
        public int Tiempo { get; set; }
    }
}
