using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Models;
using System.Diagnostics;

namespace MvcCoreAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentosContext context;

        public RepositoryDepartamento(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoAsync(int iddepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == iddepartamento);
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
