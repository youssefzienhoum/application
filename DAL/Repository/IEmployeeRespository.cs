using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public  interface IEmployeeRespository: IRespository<Employee>
    {
        IQueryable<Employee> GetAllQueryable();
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee,TResult >> selector);
    }
}
