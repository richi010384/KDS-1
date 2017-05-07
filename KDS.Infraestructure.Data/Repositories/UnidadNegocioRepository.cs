using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace KDS.Infraestructure.Data.Repositories
{
    public class UnidadNegocioRepository
        : Repository<UnidadNegocio, Entities.vw_UnidadNegocio>, IUnidadNegocioRepository
    {
        #region Constructor

        public UnidadNegocioRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ProductRepository Members

        public IEnumerable<UnidadNegocio> Listar()
        {
            return Mapper.Map<IEnumerable<Entities.vw_UnidadNegocio>, IEnumerable<UnidadNegocio>>(DataContext.vw_UnidadNegocio);
        }

        #endregion
    }
}