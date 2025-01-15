using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Entities;
using Url_shortener.Logic.Models.Url;
using Url_shortener.Persistence.Configurations;
using Url_shortener.Persistence.Repositories;

namespace Url_shortener.Persistence.Data
{
    public class ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options,
       IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UrlManagment> Urls { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
