using AutoMapper;
using BLL.DataTransferObject.Employees;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(d=>d.Department,O=>O.MapFrom(D=>D.Department.Name));
            CreateMap<Employee, EmployeeDetailsResponse>()
                .ForMember(d => d.Department, O => O.MapFrom(D => D.Department.Name));
            CreateMap<EmployeeDetailsResponse, EmployeeUpdateRequest>();
            CreateMap<EmployeeUpdateRequest, EmployeeRequest>();

        }
    }
}
