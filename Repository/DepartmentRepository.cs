using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();

        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var department= await _context.Departments.FindAsync(departmentId);
            return department;

        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            var existdepartment = new Department()
            {
                Name = department.Name
            };
             _context.Departments.Add(existdepartment);
              await _context.SaveChangesAsync();
              return existdepartment;
            //return department;

        }

        public async Task<Department> UpdateDepartmentAsync(int departmentId, Department newDepartment)
        {

            var existdepartment = new Department()
            {
                Id=departmentId,
                Name = newDepartment.Name
            };
             _context.Departments.Update(existdepartment);
             await _context.SaveChangesAsync();
             return existdepartment;


        }

        public async Task<Department> DeleteDepartmentAsync(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }


            return department;

        }

    }
}
