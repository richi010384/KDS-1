﻿using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        IEnumerable<Producto> ObtenerAutocompletado(string codUnidadNegocio, string descProducto);
    }
}