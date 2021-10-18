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
        public static StudentCourse CreateWith(Guid id,Guid studentId,Guid courseId,decimal mark)
        {
            return new StudentCourse(id, studentId, courseId, mark);
        }
        protected StudentCourse(Guid id, Guid studentId, Guid courseId, decimal mark)
        {
            Id = new StudentCourseId(id);
            StudentId = new StudentId(studentId);
            CourseId = new CourseId(courseId);
            Mark = mark;
        }


        public StudentId StudentId { get; private set; }
        public CourseId CourseId { get; private set; }
        public decimal Mark { get; private set; }
    }
}
