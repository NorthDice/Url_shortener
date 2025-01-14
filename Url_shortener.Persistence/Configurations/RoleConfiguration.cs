using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Entities;
using Url_shortener.Logic.Enums;

namespace Url_shortener.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<RolePermissionEntity>(
                    j => j.HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.PermissionId),
                    j => j.HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.RoleId),
                    j =>
                    {
                        j.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                    }
                );
            var roles = Enum
                .GetValues<Role>()
                .Select(r => new RoleEntity
                 {
                     Id = (int)r,
                     Name = r.ToString()
                 });

            builder.HasData(roles);
        }
    }
}
