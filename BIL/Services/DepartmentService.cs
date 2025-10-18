
using DAL.Entities;
using DAL.Repository;
using Demo.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Services
{
    public class DepartmentService(IUnitOfWork unitOfWork): IDepartmentService
    {
      
      

        public int Add(DepartmentRequest department)
        {
             unitOfWork.Departments.Add(department.ToEntity());
            return unitOfWork.SaveChange();
        }

        public bool Delete(int id)
        {
            var department=unitOfWork.Departments.GetById(id);
            if (department==null) return false;
            unitOfWork.Departments.Delete(department);
            return unitOfWork.SaveChange() > 0;

        }

        public IEnumerable<DepartmentResponse> GetAll()
        {
           return unitOfWork.Departments.GetAll()
                .Select(d=>d.ToResponse());
        }

        public DepartmentDetailsResponse? GetById(int id)
        {
           return unitOfWork.Departments.GetById(id)?.ToDetailsResponse();
        }

        public int Update(DepartmentUpdateRequest department)
        {
           unitOfWork.Departments.Update(department.ToEntity());
            return unitOfWork.SaveChange();
        }
    }
}
