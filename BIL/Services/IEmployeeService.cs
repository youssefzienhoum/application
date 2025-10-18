using BLL.DataTransferObject.Employees;
using Demo.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Services
{
    public  interface IEmployeeService
    {
        EmployeeDetailsResponse? GetById(int id);
        IEnumerable<EmployeeResponse> GetAll();
        IEnumerable<EmployeeResponse> GetAll(string? searchvalue);
        int Update(EmployeeUpdateRequest department);
        bool Delete(int id);
        int Add(EmployeeRequest department);
    }
}
