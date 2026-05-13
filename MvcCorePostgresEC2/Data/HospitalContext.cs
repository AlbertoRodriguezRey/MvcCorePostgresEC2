using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
