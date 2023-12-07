using EvoSystems.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EvoSystems.Mapping
{
    public class EmployeeMapping
    {
        public void ConfigureMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.ToTable("Employee");
            entityBuilder.Property(e => e.Name).HasColumnType("nvarchar(max)");
            entityBuilder.Property(e => e.RG).HasColumnType("nvarchar(9)");
            entityBuilder.Property(e => e.IsActive).HasColumnType("bit");
            entityBuilder.Property(e => e.CreatedAt).HasColumnType("datetime2");
            entityBuilder.Property(e => e.LastUpdatedAt).HasColumnType("datetime2");
            entityBuilder.HasOne(e => e.Department).WithOne(x => x.Em).HasForeignKey(e => e.);

        }
    }
}
