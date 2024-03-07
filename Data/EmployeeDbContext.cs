using CRUD_EF.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
