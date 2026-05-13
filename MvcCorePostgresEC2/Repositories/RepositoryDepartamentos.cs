using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Data;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private HospitalContext context;

        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }

        public async Task CreateDepartamento(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            await this.context.Departamentos.AddAsync(dept);
            await this.context.SaveChangesAsync();

        }
    }
}
