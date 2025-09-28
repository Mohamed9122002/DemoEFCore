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
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        // Navigation Property (one)
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        // Navigation Property (one)
        public virtual Course Course { get; set; } = null!;
        public int Grade { get; set; } 
    }
}
