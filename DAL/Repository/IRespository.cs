using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRespository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool trackChange = false);
        TEntity? GetById(int id);
        void Add(TEntity TEnity);
        void Update(TEntity TEnity);
        void Delete(TEntity TEnity);
    
    }
}
