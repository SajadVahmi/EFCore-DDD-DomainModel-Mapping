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
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(new StudentIdValueConverter());
            
        }
    }




    public class StudentIdValueConverter:ValueConverter<StudentId,Guid>
    {
        public StudentIdValueConverter(ConverterMappingHints mappingHints=default)
            :base(MapTo,MapFrom,mappingHints)
        {

        }

        static Expression<Func<StudentId, Guid>> MapTo => e => e.Value;
        static Expression<Func<Guid, StudentId>> MapFrom = e => new StudentId(e);
    }
}
