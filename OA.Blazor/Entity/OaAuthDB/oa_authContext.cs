using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OA.Blazor.Entity.OaAuthDB
{
    public partial class oa_authContext : DbContext
    {
        public oa_authContext()
        {
        }

        public oa_authContext(DbContextOptions<oa_authContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthRoleClaims> AuthRoleClaims { get; set; }
        public virtual DbSet<AuthRoles> AuthRoles { get; set; }
        public virtual DbSet<AuthUserClaims> AuthUserClaims { get; set; }
        public virtual DbSet<AuthUserRoles> AuthUserRoles { get; set; }
        public virtual DbSet<AuthUserlogins> AuthUserlogins { get; set; }
        public virtual DbSet<AuthUsers> AuthUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 optionsBuilder.UseMySql("server=200.91.5.181;user id=admin;password=szcg123!@#;database=oa_auth", x => x.ServerVersion("5.5.64-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthRoleClaims>(entity =>
            {
                entity.ToTable("auth_role_claims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleClaimType)
                    .IsRequired()
                    .HasColumnName("role_claim_type")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleClaimValue)
                    .IsRequired()
                    .HasColumnName("role_claim_value")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<AuthRoles>(entity =>
            {
                entity.ToTable("auth_roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Roledescript)
                    .HasColumnName("roledescript")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AuthUserClaims>(entity =>
            {
                entity.ToTable("auth_user_claims");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AuthUserRoles>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("auth_user_roles");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<AuthUserlogins>(entity =>
            {
                entity.ToTable("auth_userlogins");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoginClient)
                    .IsRequired()
                    .HasColumnName("login_client")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("'localserver'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LoginIp)
                    .IsRequired()
                    .HasColumnName("login_ip")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LoginTimestamp)
                    .HasColumnName("login_timestamp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("uid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AuthUsers>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("auth_users");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("'未设置'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.LockStamp)
                    .HasColumnName("lock_stamp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LockType)
                    .HasColumnName("lock_type")
                    .HasColumnType("tinyint(4)")
                    .HasComment(@"锁定级别
0-未锁定
1-登录错误临时锁定.lock-stamp后修改为0
2-管理员操作锁定
3-注册未审核锁定");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneConfirmed)
                    .HasColumnName("phone_confirmed")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasColumnType("tinyint(4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
