using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagment.Models
{
    public partial class AssetManagementContext : DbContext
    {
        public AssetManagementContext()
        {
        }

        public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetGroup> AssetGroups { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<PositionHistory> PositionHistories { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<TechnologyTag> TechnologyTags { get; set; } = null!;
        public virtual DbSet<TechnologyType> TechnologyTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=d068;Database=AssetManagment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.AssetId)
                    .ValueGeneratedNever()
                    .HasColumnName("Asset_ID");

                entity.Property(e => e.AssetDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Asset_Desc");

                entity.Property(e => e.AssetInventoryNumber)

                    .HasColumnName("Asset_InventoryNumber");
                    

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Asset_Name");

                entity.Property(e => e.AssetTagMacAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Asset_TagMacAddress");
            });

            modelBuilder.Entity<AssetGroup>(entity =>
            {
                entity.HasKey(e => e.AssetGroupId)
                   .HasName("PK_AssetGroup");

                entity.ToTable("AssetGroup");

                entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroup_ID");

                entity.Property(e => e.AssetId).HasColumnName("Asset_ID");
                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.HasOne(d => d.AssetGroups)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_AssetGroup_group");

                entity.HasOne(d => d.Asset)
                   .WithMany()
                   .HasForeignKey(d => d.AssetId)
                   .HasConstraintName("FK_AssetGroup_Asset");


               
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK_Group");

                entity.ToTable("Group");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("Group_ID");

                entity.Property(e => e.GroupIcon)
                    .HasColumnType("image")
                    .HasColumnName("Group_Icon");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(10)
                    .HasColumnName("Group_Name")
                    .IsFixedLength();
            });

           
            
            modelBuilder.Entity<PositionHistory>(entity =>
            {
                entity.HasKey(e => e.PositionID)
                   .HasName("PK_PositionHistory");

                entity.ToTable("PositionHistory");
                entity.Property(e => e.PositionID)
                    .ValueGeneratedNever()
                    .HasColumnName("Position_ID");

                entity.Property(e => e.PositionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Position_Date");

                entity.Property(e => e.PositionTag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Position_TagMacAddress");

                entity.Property(e => e.PositionX).HasColumnName("Position_X");

                entity.Property(e => e.PositionY).HasColumnName("Position_Y");

               

               
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagMacAddress)
                    .HasName("PK_Tag");

                entity.ToTable("Tag");

                entity.Property(e => e.TagMacAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tag_MacAddress");

                entity.Property(e => e.TagBatteryStatus).HasColumnName("Tag_BatteryStatus");

                entity.Property(e => e.TagInventoryNumber).HasColumnName("Tag_InventoryNumber");
            });

            modelBuilder.Entity<TechnologyTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TechnologyTag");

                entity.Property(e => e.TagId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tag_ID");

                entity.Property(e => e.TechnologyId).HasColumnName("Technology_ID");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TagID_Key");

                entity.HasOne(d => d.Technology)
                    .WithMany()
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TechIDKey");
            });

            modelBuilder.Entity<TechnologyType>(entity =>
            {
                entity.HasKey(e => e.TechnologyId)
                    .HasName("PK__Technolo__AA289BC6D5BF9F51");

                entity.ToTable("TechnologyType");

                entity.Property(e => e.TechnologyId)
                    .ValueGeneratedNever()
                    .HasColumnName("Technology_ID");

                entity.Property(e => e.TechnologyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Technology_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
