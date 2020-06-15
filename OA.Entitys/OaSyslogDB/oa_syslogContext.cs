using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OA.Entitys.OaSyslogDB
{
    public partial class oa_syslogContext : DbContext
    {
        public oa_syslogContext()
        {
        }

        public oa_syslogContext(DbContextOptions<oa_syslogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Syslog> Syslog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Syslog>(entity =>
            {
                entity.ToTable("syslog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AppName)
                    .HasColumnName("app_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.LogTimestamp)
                    .HasColumnName("log_timestamp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsgContent)
                    .HasColumnName("msg_content")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MsgType)
                    .HasColumnName("msg_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MsgUser)
                    .HasColumnName("msg_user")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
