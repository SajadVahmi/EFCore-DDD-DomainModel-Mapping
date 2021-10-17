using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UseValueObjectAsIdentifier.Domain.Models;

namespace UseValueObjectAsIdentifier.Persistence.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever();
                
        }
    }

    public class CourseIdValueConverter : ValueConverter<CourseId, Guid>
    {
        public CourseIdValueConverter(ConverterMappingHints mappingHints = default)
            : base(MapTo, MapFrom, mappingHints)
        {

        }

        static Expression<Func<CourseId, Guid>> MapTo => e => e.Value;
        static Expression<Func<Guid, CourseId>> MapFrom = e => new CourseId(e);
    }
}
