using System;

namespace KDS.Domain.Entities
{
    public class PedidoProducto
    {
        public string PuntoPreparacion { get; set; }
        public string CodPedido { get; set; }
        public string Mesa { get; set; }
        public int? PasoServicio { get; set; }
        public int Cantidad { get; set; }
        public string ImagenProducto { get; set; }
        public string ImagenOperador { get; set; }
        public string ImagenPropiedad { get; set; }
        public string Producto { get; set; }
        public string Operador { get; set; }
        public string Propiedad { get; set; }
        public string Observaciones { get; set; }
        public DateTime HoraSalida { get; set; }
        public string Estado { get; set; }
    }
}
