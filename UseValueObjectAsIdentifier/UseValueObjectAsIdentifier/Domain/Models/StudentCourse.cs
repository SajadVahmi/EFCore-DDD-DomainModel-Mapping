using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class StudentCourse:AggregateRoot<StudentCourseId>
    {
        public StudentCourse(StudentCourseId id, StudentId studentId, CourseId courseId, decimal mark)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            Mark = mark;
        }


        public StudentId StudentId { get; private set; }
        public CourseId CourseId { get; private set; }
        public decimal Mark { get; private set; }
    }
}
