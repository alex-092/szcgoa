using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OA.Entitys.OaMsgDB
{
    public partial class oa_msgContext : DbContext
    {
        public oa_msgContext()
        {
        }

        public oa_msgContext(DbContextOptions<oa_msgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MsgContent> MsgContent { get; set; }
        public virtual DbSet<MsgReader> MsgReader { get; set; }
        public virtual DbSet<MsgSender> MsgSender { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsgContent>(entity =>
            {
                entity.ToTable("msg_content");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Brief)
                    .HasColumnName("brief")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeleteBy)
                    .HasColumnName("delete_by")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Subtype)
                    .HasColumnName("subtype")
                    .HasColumnType("int(4)");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(4)");
            });

            modelBuilder.Entity<MsgReader>(entity =>
            {
                entity.ToTable("msg_reader");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsRead)
                    .HasColumnName("is_read")
                    .HasColumnType("int(4)");

                entity.Property(e => e.MsgId)
                    .HasColumnName("msg_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SenderId)
                    .HasColumnName("sender_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<MsgSender>(entity =>
            {
                entity.ToTable("msg_sender");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsgId)
                    .HasColumnName("msg_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReaderId)
                    .HasColumnName("reader_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
