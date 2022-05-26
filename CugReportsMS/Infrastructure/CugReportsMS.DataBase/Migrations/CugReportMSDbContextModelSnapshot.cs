﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReportingDB;

#nullable disable

namespace ReportingDB.Migrations
{
    [DbContext(typeof(CugReportMSDbContext))]
    partial class CugReportMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReportingDB.DataBaseModels.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Parameters")
                        .HasColumnType("text");

                    b.Property<Guid?>("ReportGuidInGenerator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeWithTemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeWithTemplateId");

                    b.ToTable("Reports", (string)null);
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.ReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FormatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OutputFormat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TypeNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReportTypes", (string)null);
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.ReportTypesWithTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("ReportTypesWithTemplate", (string)null);
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("OrderNum")
                        .HasColumnType("int");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SectionNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.Report", b =>
                {
                    b.HasOne("ReportingDB.DataBaseModels.ReportTypesWithTemplate", "TypeWithTemplate")
                        .WithMany("Reports")
                        .HasForeignKey("TypeWithTemplateId")
                        .IsRequired()
                        .HasConstraintName("FK_Reports_ReportTypesWithTemplate");

                    b.Navigation("TypeWithTemplate");
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.ReportTypesWithTemplate", b =>
                {
                    b.HasOne("ReportingDB.DataBaseModels.ReportType", "ReportType")
                        .WithMany("ReportTypesWithTemplates")
                        .HasForeignKey("ReportTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_T_TypesWithTemplate_T_Types");

                    b.Navigation("ReportType");
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.Section", b =>
                {
                    b.HasOne("ReportingDB.DataBaseModels.ReportType", "ReportType")
                        .WithMany("Sections")
                        .HasForeignKey("ReportTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_T_Sections_T_Types");

                    b.Navigation("ReportType");
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.ReportType", b =>
                {
                    b.Navigation("ReportTypesWithTemplates");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("ReportingDB.DataBaseModels.ReportTypesWithTemplate", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
