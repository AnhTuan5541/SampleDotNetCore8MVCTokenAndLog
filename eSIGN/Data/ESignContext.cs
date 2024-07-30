using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eSIGN.Data;

public partial class ESignContext : DbContext
{
    public ESignContext()
    {
    }

    public ESignContext(DbContextOptions<ESignContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<LogInfo> LogInfos { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SignFlow> SignFlows { get; set; }

    public virtual DbSet<System> Systems { get; set; }

    public virtual DbSet<SystemOwner> SystemOwners { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<ValueSign> ValueSigns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.201.21.84,50150;Initial Catalog=eSIGN;Persist Security Info=True;User ID=cimitar2;Password=TFAtest1!2!;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_pk");

            entity.ToTable("application");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalComments)
                .HasColumnType("text")
                .HasColumnName("additional_comments");
            entity.Property(e => e.BussinessJustification)
                .HasColumnType("text")
                .HasColumnName("bussiness_justification");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.File)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("file");
            entity.Property(e => e.IdCardGlobalManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card_global_manager");
            entity.Property(e => e.IdCardUserCreate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card_user_create");
            entity.Property(e => e.IdCardUserRequire)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card_user_require");
            entity.Property(e => e.IdSystem).HasColumnName("id_system");
            entity.Property(e => e.IdSystemOwner).HasColumnName("id_system_owner");
            entity.Property(e => e.IdType)
                .HasComment("loai don: Improvement, New development")
                .HasColumnName("id_type");
            entity.Property(e => e.NameManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_manager");
            entity.Property(e => e.NameUserRequire)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_user_require");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.ValueSign).HasColumnName("value_sign");
        });

        modelBuilder.Entity<LogInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_info_pk");

            entity.ToTable("log_info");

            entity.HasIndex(e => e.TypeLog, "log_info_type_log_IDX");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Function)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("function");
            entity.Property(e => e.IdCard)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card");
            entity.Property(e => e.Info)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("info");
            entity.Property(e => e.Proc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proc");
            entity.Property(e => e.TypeLog)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type_log");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("owner_pk");

            entity.ToTable("owner");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.IdCard)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pk");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<SignFlow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sign_flow_pk");

            entity.ToTable("sign_flow");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.File)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("file");
            entity.Property(e => e.IdApplication).HasColumnName("id_application");
            entity.Property(e => e.IdCard)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.ValueSign).HasColumnName("value_sign");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_pk");

            entity.ToTable("system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.System1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("system");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<SystemOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_owner_pk");

            entity.ToTable("system_owner");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.IdOwner).HasColumnName("id_owner");
            entity.Property(e => e.IdSystem).HasColumnName("id_system");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_pk");

            entity.ToTable("type", tb => tb.HasComment("Loai user yeu cau"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Type1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_PK");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdCard)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card");
            entity.Property(e => e.IdCardVn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id_card_vn");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_pk");

            entity.ToTable("user_role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<ValueSign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("value_sign_pk");

            entity.ToTable("value_sign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.ValueSign1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value_sign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
