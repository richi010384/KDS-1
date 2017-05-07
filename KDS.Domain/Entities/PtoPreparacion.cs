using System;

namespace KDS.Domain.Entities
{
    public class PtoPreparacion
    {        
        public string CodUnidadNegocio { get; set; }
        public string NombreUnidadNegocio { get; set; }
        public int CodPtoPreparacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
