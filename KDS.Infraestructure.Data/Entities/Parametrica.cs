//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDS.Infraestructure.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parametrica
    {
        public Parametrica()
        {
            this.OperadorPropiedad = new HashSet<OperadorPropiedad>();
            this.PedidoProducto = new HashSet<PedidoProducto>();
        }
    
        public int CodParametrica { get; set; }
        public int CodTipoParametrica { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public bool EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string NombreAux { get; set; }
        public string Valor { get; set; }
    
        public virtual ICollection<OperadorPropiedad> OperadorPropiedad { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
        public virtual TipoParametrica TipoParametrica { get; set; }
    }
}
