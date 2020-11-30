using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using SolicitudPermisos.Model.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IPermisoService
    {
        Task<IEnumerable<Permiso>> GetAll();
        Task<bool> Add(PermisoDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(PermisoDTO model);
        Task<Permiso> Get(int id);
    }

    public class PermisoService : IPermisoService
    {
        private readonly PermisoDbContext _permisoDbContext;

        public PermisoService(
            PermisoDbContext permisoDbContext
        )
        {
            _permisoDbContext = permisoDbContext;
        }

        public async Task<IEnumerable<Permiso>> GetAll()
        {
            var result = new List<Permiso>();

            try
            {
                result = await _permisoDbContext.Permiso.Include(tp => tp.TipoPermiso).ToListAsync();
            }
            catch (System.Exception)
            {
                
            }

            return result;
        }

        public async Task<Permiso> Get(int id)
        {
            var result = new Permiso();

            try
            {
                result = await _permisoDbContext.Permiso.Where(x => x.Id == id).Include(tp => tp.TipoPermiso).FirstOrDefaultAsync();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async Task<bool> Add(PermisoDTO model)
        {
            try
            {
                var permiso = new Permiso();
                permiso.Name = model.Name;
                permiso.LastName = model.LastName;
                permiso.Date = model.Date;
                permiso.TipoPermisoId = model.TipoPermisoId;

                _permisoDbContext.Add(permiso);
                await _permisoDbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Update(PermisoDTO model)
        {
            try
            {
                Permiso originalModel = new Permiso();
                originalModel = await _permisoDbContext.Permiso.SingleAsync(x =>
                    x.Id == model.Id
                );

                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.Date = model.Date;
                originalModel.TipoPermisoId = model.TipoPermisoId;

                _permisoDbContext.Update(originalModel);
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
                _permisoDbContext.Entry(new Permiso { Id = id }).State = EntityState.Deleted; ;
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
