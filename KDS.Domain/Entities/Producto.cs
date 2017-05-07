using System;

namespace KDS.Domain.Entities
{
    public class Producto
    {
        public string CodProducto { get; set; }
        public string DescProducto { get; set; }

        public string CodGrupo { get; set; }
        public string DescGrupo { get; set; }
        public string CodSubGrupo { get; set; }
        public string DescSubGrupo { get; set; }
    }
}
