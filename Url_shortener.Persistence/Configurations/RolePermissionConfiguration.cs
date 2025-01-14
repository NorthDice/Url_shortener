using Microsoft.EntityFrameworkCore;
using Url_shortener.Logic.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Url_shortener.Persistence.Repositories;
using Url_shortener.Logic.Enums;

namespace Url_shortener.Persistence.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
    {
        private readonly AuthorizationOptions _authorization;

        public RolePermissionConfiguration(AuthorizationOptions authorization)
        {
            _authorization = authorization;
        }

        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
           builder.HasKey(r => new {r.RoleId, r.PermissionId });

            builder.HasData(ParseRolePermission());
        }

        private RolePermissionEntity[] ParseRolePermission()
        {
           return _authorization.RolePermissions
                .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permissions>(p)
                }))
                .ToArray();
        }
    }
}
