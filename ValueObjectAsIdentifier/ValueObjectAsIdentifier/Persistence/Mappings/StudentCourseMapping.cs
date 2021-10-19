using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using UseValueObjectAsIdentifier.Domain.Models;

namespace UseValueObjectAsIdentifier.Persistence.Mappings
{
    public class StudentCourseMapping : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId);


            builder.HasOne<Course>()
               .WithMany()
               .HasForeignKey(e => e.CourseId);

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
