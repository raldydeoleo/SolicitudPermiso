using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using SolicitudPermisos.Model.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface ITipoPermisoService
    {
        Task<IEnumerable<TipoPermiso>> GetAll();
        Task<bool> Add(TipoPermisoDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(TipoPermisoDTO model);
        Task<TipoPermiso> Get(int id);
    }

    public class TipoPermisoService : ITipoPermisoService
    {
        private readonly PermisoDbContext _permisoDbContext;

        public TipoPermisoService(
            PermisoDbContext permisoDbContext
        )
        {
            _permisoDbContext = permisoDbContext;
        }

        public async Task<IEnumerable<TipoPermiso>> GetAll()
        {
            var result = new List<TipoPermiso>();

            try
            {
                result = await _permisoDbContext.TipoPermiso.ToListAsync();
            }
            catch (System.Exception)
            {
                
            }

            return result;
        }

        public async Task<TipoPermiso> Get(int id)
        {
            var result = new TipoPermiso();

            try
            {
                result = await _permisoDbContext.TipoPermiso.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async Task<bool> Add(TipoPermisoDTO model)
        {
            try
            {
                var tpermiso = new TipoPermiso();
                tpermiso.Descripcion = model.Descripcion;              

                _permisoDbContext.Add(tpermiso);
                await _permisoDbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Update(TipoPermisoDTO model)
        {
            try
            {
                TipoPermiso originalTipoPermiso = new TipoPermiso();
                originalTipoPermiso = await _permisoDbContext.TipoPermiso.SingleAsync(x =>
                    x.Id == model.TipoPermisoId
                );

                originalTipoPermiso.Descripcion = model.Descripcion;
               

                _permisoDbContext.Update(originalTipoPermiso);
                await _permisoDbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                _permisoDbContext.Entry(new TipoPermiso { Id = id }).State = EntityState.Deleted; ;
                await _permisoDbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
