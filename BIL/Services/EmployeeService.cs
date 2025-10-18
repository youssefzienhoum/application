global using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DataTransferObject.Employees;
using DAL.Entities;
using DAL.Repository;
using Demo.BLL.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Services
{

    public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
    {
        public int Add(EmployeeRequest request)
        {
            var employee = mapper.Map<EmployeeRequest, Employee>(request);
          
                unitOfWork.Employees.Add(employee);
            return unitOfWork.SaveChange();
        }

        public bool Delete(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            if (employee == null) return false;
             unitOfWork.Employees.Delete(employee);
            return unitOfWork.SaveChange() > 0;

        }

        public IEnumerable<EmployeeResponse> GetAll()
        {

            //var employees = unitOfWork.Employees.GetAll(e => new EmployeeResponse
            //{
            //    Age = e.Age,
            //    Email = e.Email,
            //    EmployeeType = e.EmployeeType.ToString(),
            //    Gender = e.Gender.ToString(),
            //    Id = e.Id,
            //    IsActive = e.IsActive,
            //    Salary = e.Salary,
            //    Name = e.Name,
            //    Department=e.Department.Name,

            //}).ToList();
            var employees = unitOfWork.Employees.GetAllQueryable()
  
                .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider)
                .ToList();
            return employees;
            //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employees);
        }

        public IEnumerable<EmployeeResponse> GetAll(string? searchvalue)
        {
            var employees = unitOfWork.Employees.GetAllQueryable()
                .Where(e=>e.Name.Contains(searchvalue))
              .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider)
              .ToList();
            return employees;
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            if (employee == null) return null;
            return mapper.Map<Employee, EmployeeDetailsResponse>(employee);
        }

        public int Update(EmployeeUpdateRequest employee)
        {
            var emp = mapper.Map<EmployeeUpdateRequest, Employee>(employee);
            unitOfWork.Employees.Update(emp);
            return unitOfWork.SaveChange();
        }
    }
}
