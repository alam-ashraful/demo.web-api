using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Core.ApiDbContext;
using WebApi.Core.Models;

namespace WebApi.Core.Controllers
{
    public class DepartmentController : ApiController
    {
        private StudentApiDbContext studentApiDbContext;
        public DepartmentController()
        {
            studentApiDbContext = new StudentApiDbContext();
        }

        // GET: api/Department
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return studentApiDbContext.Departments.ToList();
        }

        // GET: api/Department/5
        [HttpGet]
        public Department Get(int id)
        {
            return studentApiDbContext.Departments.SingleOrDefault(m => m.DepartmentId == id);
        }

        // POST: api/Department
        [HttpPost]
        public IHttpActionResult Post([FromBody]Department department)
        {
            if (!ModelState.IsValid) return BadRequest("Unable to create department");
            studentApiDbContext.Departments.Add(department);
            studentApiDbContext.SaveChanges();
            return Ok(department);
        }

        // PUT: api/Department/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Department department)
        {
            var dept = studentApiDbContext.Departments.Find(id);
            if (dept != null && ModelState.IsValid)
            {
                dept.Name = department.Name;
                studentApiDbContext.SaveChanges();
                return Ok(dept);
            }else
            {
                return BadRequest("Failed to update department");
            }
        }

        // DELETE: api/Department/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dept = studentApiDbContext.Departments.Find(id);
            if (ModelState.IsValid && dept != null)
            {
                studentApiDbContext.Departments.Remove(dept);
                studentApiDbContext.SaveChanges();
                return Ok("successfully removed department");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
