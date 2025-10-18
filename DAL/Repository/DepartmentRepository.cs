using DAL.context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DepartmentRepository(CompanyDbContext dbcontext): MainRespository<Department>(dbcontext), IDepartmentRepository
    {
        //private CompanyDbContext _context = dbcontext;
        //private DbSet<Department> _departments= dbcontext.Departments;
        
        

        //public int Add(Department department)
        //{
        //    _departments.Add(department);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    _departments.Remove(department);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Department> GetAll(bool trackChange = false)
        //{
        //    return trackChange? _departments.ToList(): _departments.AsNoTracking().ToList();


        //}

        //public Department? GetById(int id)
        //{
        //    return _departments.Find(id);   
          

        //}

        //public int Update(Department department)
        //{
        //    _departments.Update(department);
        //    return _context.SaveChanges();
        //}
    }
}
