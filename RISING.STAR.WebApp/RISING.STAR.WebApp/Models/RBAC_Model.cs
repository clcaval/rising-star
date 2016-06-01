namespace RISING.STAR.WebApp.Models
{

    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using RISING.STAR.DAL;
    //using RISING.STAR.Business.Models;
    
    public partial class RBAC_Model : DbContext
    {
        public RBAC_Model()
            : base("name=RISINGSTAREntities")
        {
        }

        public virtual DbSet<Permission> PERMISSIONS { get; set; }
        public virtual DbSet<Role> ROLES { get; set; }
        public virtual DbSet<User> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("RolePermission").MapLeftKey("PermissionID").MapRightKey("RoleID"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleID").MapRightKey("UserID"));
        }
    }

}