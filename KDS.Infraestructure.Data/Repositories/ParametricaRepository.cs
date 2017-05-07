using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class ParametricaRepository
        : Repository<Parametrica, Entities.Parametrica>, IParametricaRepository
    {
        #region Constructor

        public ParametricaRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ParametricaRepository Members

        public IEnumerable<Parametrica> ObtenerxTipoParametrica(int? codTipoParametrica)
        {
            return Mapper.Map<IEnumerable<Entities.Parametrica>, IEnumerable<Parametrica>>(this.DataContext.Parametrica.Where(x => x.CodTipoParametrica == codTipoParametrica));
        }

        #endregion
    }
}