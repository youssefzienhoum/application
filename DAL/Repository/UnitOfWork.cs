using DAL.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork(CompanyDbContext dbContext,IEmployeeRespository employeeRespository,IDepartmentRepository departmentRepository ) : IUnitOfWork
    {
        public IEmployeeRespository Employees => employeeRespository;

        public IDepartmentRepository Departments => departmentRepository;

        public int SaveChange()
        {
         return   dbContext.SaveChanges();
        }
    }
}
