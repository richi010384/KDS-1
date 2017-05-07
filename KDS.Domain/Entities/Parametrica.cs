using System;

namespace KDS.Domain.Entities
{
    public class Parametrica
    {
        public int CodParametrica { get; set; }
        public int CodTipoParametrica { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public bool EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string NombreAux { get; set; }
        public string Valor { get; set; }
    }
}
