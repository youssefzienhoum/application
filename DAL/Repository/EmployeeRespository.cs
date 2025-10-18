using DAL.context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmployeeRespository(CompanyDbContext dbcontext) : MainRespository<Employee>(dbcontext), IEmployeeRespository
    {
        public IQueryable<Employee> GetAllQueryable()
        {
            return _dbset;
        }

        IEnumerable<TResult> IEmployeeRespository.GetAll<TResult>(Expression<Func<Employee, TResult>> selector)
        {
            return _dbset.Select(selector);
        }
        public override Employee? GetById(int id)
        {
            return _dbset.Include(e=>e.Department).FirstOrDefault(e=>e.Id == id);
        }

       
    }
}
