using System;

namespace KDS.Domain.Entities
{
    public partial class ProductoPtoPrep
    {
        public int CodProductoPtoPrep { get; set; }
        public string CodUnidadNegocio { get; set; }
        public int CodPtoPreparacion { get; set; }
        public string CodProducto { get; set; }
        public string DescProducto { get; set; }
        public int IndEnsamblado { get; set; }
        public int TiempoPrepDirecto { get; set; }
        public int TiempoPrepSegundo { get; set; }
        public int MinCantidad { get; set; }
        public int MaxCantidad { get; set; }
        public bool EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
