//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using KDS.Domain.Seedwork.Resources;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Enums;
using System;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class TiempoConsumoService : ServiceBase<TiempoConsumo>, ITiempoConsumoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITiempoConsumoRepository _tconsumoRepository;

        public TiempoConsumoService(IUnitOfWork unitOfWork, ITiempoConsumoRepository tconsumoRepository)
            : base(tconsumoRepository)
        {
            _unitOfWork = unitOfWork;
            _tconsumoRepository = tconsumoRepository;            
        }

        public IEnumerable<TiempoConsumo> ListarPorGrupos(string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarPorGrupos(CodGrupo, CodPropiedad, Cantidad, ref paginacion);
        }

        public IEnumerable<TiempoConsumo> ListarPorSubGrupos(string CodSubGrupo, string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarPorSubGrupos(CodSubGrupo, CodGrupo, CodPropiedad, Cantidad, ref paginacion);
        }

        public IEnumerable<TiempoConsumo> ListarPorProductos(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, string CodPropiedad, int Cantidad, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarPorProductos(CodGrupo, CodSubGrupo, CodProducto, DescProducto, CodPropiedad, Cantidad, ref paginacion);
        }

        public IEnumerable<Grupo> ListarMaestroGrupo(string CodGrupo, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarMaestroGrupo(CodGrupo, ref paginacion);
        }

        public IEnumerable<Subgrupo> ListarMaestroSubGrupo(string CodSubGrupo, string CodGrupo, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarMaestroSubGrupo(CodSubGrupo, CodGrupo, ref paginacion);
        }

        public IEnumerable<Producto> ListarMaestroProducto(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, ref Pagination paginacion)
        {
            return _tconsumoRepository.ListarMaestroProducto(CodGrupo, CodSubGrupo, CodProducto, DescProducto, ref paginacion);
        }

        public IEnumerable<Grupo> ListarGrupos()
        {
            return _tconsumoRepository.ListarGrupos();
        }

        public IEnumerable<Subgrupo> ListarSubGrupos(string CodGrupo)
        {
            return _tconsumoRepository.ListarSubGrupos(CodGrupo);
        }

        public IEnumerable<Parametrica> ListarParametros(int CodTipoParametro)
        {
            return _tconsumoRepository.ListarParametros(CodTipoParametro);
        }

        public ValidationResult Guardar(TiempoConsumo obj)
        {
            using (_unitOfWork)
            {
                try
                {
                    _tconsumoRepository.Guardar(obj);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch (Exception e)
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult Actualizar(TiempoConsumo obj)
        {
            using (_unitOfWork)
            {
                try
                {
                    _tconsumoRepository.Update(obj);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult Eliminar(int id)
        {
            using (_unitOfWork)
            {
                try
                {
                    _tconsumoRepository.Delete(id);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

    }
}
