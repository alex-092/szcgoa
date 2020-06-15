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

        public virtual DbSet<ConfigClaim> ConfigClaim { get; set; }
        public virtual DbSet<MsgContent> MsgContent { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<UserNotify> UserNotify { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigClaim>(entity =>
            {
                entity.ToTable("config_claim");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<MsgContent>(entity =>
            {
                entity.ToTable("msg_content");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("int(4)")
                    .HasComment("comment/like/post/update etc.");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasComment("消息的内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasColumnType("int(4)");

                entity.Property(e => e.SenderUserid)
                    .HasColumnName("sender_userid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetType)
                    .HasColumnName("target_type")
                    .HasColumnType("int(4)")
                    .HasComment("1-user,2-meg-content,3-product");

                entity.Property(e => e.TargetUserid)
                    .HasColumnName("target_userid")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(4)")
                    .HasComment("消息的类型，1: 公告 Announce，2: 提醒 Remind，3：信息 Message,4 sysmessage");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetType)
                    .HasColumnName("target_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UserNotify>(entity =>
            {
                entity.ToTable("user_notify");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsRead)
                    .HasColumnName("is_read")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.MsgId)
                    .HasColumnName("msg_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
