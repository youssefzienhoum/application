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
    public class MainRespository<TEntity>(CompanyDbContext dbcontext) : IRespository<TEntity> where TEntity : BaseEntity
    {

        protected CompanyDbContext _context = dbcontext;
        protected DbSet<TEntity> _dbset = dbcontext.Set<TEntity>();



        public virtual void Add(TEntity TEntity)
        {
            _dbset.Add(TEntity);
          
        }

        public virtual void Delete(TEntity TEntity)
        {
            _dbset.Remove(TEntity);
           
        }

       

        public virtual IEnumerable<TEntity> GetAll(bool trackChange = false)
        {
            return trackChange ? _dbset.ToList() : _dbset.AsNoTracking().ToList();


        }

        public virtual TEntity? GetById(int id)
        {
            return _dbset.Find(id);


        }

        public virtual void Update(TEntity TEntity)
        {
           _dbset.Update( TEntity);
            
        }

       
    }
}
