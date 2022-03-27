using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet("")]
       public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _departmentRepository.GetAllDepartmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if(department != null)
            {
               return Ok(department);
            }
            else
            {
                return NotFound();
            }
            //return Ok(await _departmentRepository.GetAllDepartmentsAsync());
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDepartment(Department department)
        {

          return Ok(await _departmentRepository.AddDepartmentAsync(department));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id,Department department)
        {
          
                 
                 return Ok(await _departmentRepository.UpdateDepartmentAsync(id, department));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {

           var department= await _departmentRepository.DeleteDepartmentAsync(id);
            if(department !=null)
            return Ok(department);
            return NotFound();
         
        }
    }
}
