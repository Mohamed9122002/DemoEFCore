using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Models
{
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    internal class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        // Navigation Property (one)
        public Student Student { get; set; } = null!;
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        // Navigation Property (one)
        public Course Course { get; set; } = null!;
        public int Grade { get; set; } 
    }
}
