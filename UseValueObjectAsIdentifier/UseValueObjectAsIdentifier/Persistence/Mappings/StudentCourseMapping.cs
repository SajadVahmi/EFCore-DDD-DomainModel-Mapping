using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UseValueObjectAsIdentifier.Domain;
using UseValueObjectAsIdentifier.Domain.Models;

namespace UseValueObjectAsIdentifier.Persistence.Mappings
{
    public class StudentCourseMapping : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(new StudentCourseIdValueConverter());

            builder.Property(e => e.StudentId)
                .HasConversion(new StudentIdValueConverter());

            builder.Property(e => e.CourseId)
                .HasConversion(new CourseIdValueConverter());

            builder.HasOne<Student>()
                .WithMany()
                .HasForeignKey("StudentId");


            builder.HasOne<Course>()
               .WithMany()
               .HasForeignKey("CourseId");

        }
    }

    public class StudentCourseIdValueConverter : ValueConverter<StudentCourseId, Guid>
    {
        public StudentCourseIdValueConverter(ConverterMappingHints mappingHints = default)
            : base(MapTo, MapFrom, mappingHints)
        {

        }

        static Expression<Func<StudentCourseId, Guid>> MapTo => e => e.Value;
        static Expression<Func<Guid, StudentCourseId>> MapFrom = e => new StudentCourseId(e);
    }
}
