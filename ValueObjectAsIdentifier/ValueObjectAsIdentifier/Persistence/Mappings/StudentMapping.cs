using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using UseValueObjectAsIdentifier.Domain.Models;

namespace UseValueObjectAsIdentifier.Persistence.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

        }
    }




    public class StudentIdValueConverter : ValueConverter<StudentId, Guid>
    {

        public StudentIdValueConverter(ConverterMappingHints mappingHints = default)
            : base(MapTo, MapFrom, mappingHints)
        {

        }

        static Expression<Func<StudentId, Guid>> MapTo => e => e.Value;
        static Expression<Func<Guid, StudentId>> MapFrom = e => new StudentId(e);
    }
}
