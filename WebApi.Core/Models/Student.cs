using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Core.Models
{
    [Table("Students")]
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student must have a valid name")]
        public string Name { get; set; }
        public double Cgpa { get; set; }

        [Required(ErrorMessage = "Student must assign a department")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}