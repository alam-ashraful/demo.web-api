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
    public class StudentController : ApiController
    {
        private StudentApiDbContext studentApiDbContext;

        public StudentController()
        {
            studentApiDbContext = new StudentApiDbContext();
        }

        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentApiDbContext.Students.ToList();
        }

        // GET: api/Student/5
        [HttpGet]
        public Student Get(int id)
        {
            return studentApiDbContext.Students.Find(id);
        }

        // POST: api/Student
        [HttpPost]
        public IHttpActionResult Post([FromBody]Student student)
        {
            if (!ModelState.IsValid) return BadRequest("Unable to create student");
            studentApiDbContext.Students.Add(student);
            studentApiDbContext.SaveChanges();
            return Ok(student);
        }

        // PUT: api/Student/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Student student)
        {
            var std = studentApiDbContext.Students.SingleOrDefault(m => m.Id == id);
            if (std != null && ModelState.IsValid)
            {
                std.Name = student.Name;
                std.Cgpa = student.Cgpa;
                std.DepartmentId = student.DepartmentId;
                studentApiDbContext.SaveChanges();
                return Ok(std);
            }
            else
            {
                return BadRequest("Unable to update student information");
            }
        }

        // DELETE: api/Student/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var std = studentApiDbContext.Students.SingleOrDefault(m => m.Id == id);
            if (std != null)
            {
                studentApiDbContext.Students.Remove(std);
                studentApiDbContext.SaveChanges();
                return Ok("Student successfully deleted");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
