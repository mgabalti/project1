﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.DataAccessLayer;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230522214630_addcollectitonInInstance")]
    partial class addcollectitonInInstance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyApp.Models.AppUser", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("user_Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("user_DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("user_lastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("user_regDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("MyApp.Models.BlogInstance", b =>
                {
                    b.Property<int>("InstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstanceId"));

                    b.Property<int>("BlogIssueId")
                        .HasColumnType("int");

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("InstanceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstanceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccuranceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InstanceId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("BlogInstances");
                });

            modelBuilder.Entity("MyApp.Models.BlogIssue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueId"));

                    b.Property<int?>("BlogInstanceInstanceId")
                        .HasColumnType("int");

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("IssueDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueId");

                    b.HasIndex("BlogInstanceInstanceId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("BlogIssues");
                });

            modelBuilder.Entity("MyApp.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("postInstance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postIssue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postauther")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postbodyhtml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postimageurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("postpublish")
                        .HasColumnType("bit");

                    b.Property<DateTime>("postpublishdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("posttitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("MyApp.Models.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CatCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("MyApp.Models.BlogInstance", b =>
                {
                    b.HasOne("MyApp.Models.BlogPost", null)
                        .WithMany("BlogInstances")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("MyApp.Models.BlogIssue", b =>
                {
                    b.HasOne("MyApp.Models.BlogInstance", null)
                        .WithMany("InstanceOfIssue")
                        .HasForeignKey("BlogInstanceInstanceId");

                    b.HasOne("MyApp.Models.BlogPost", null)
                        .WithMany("BlogIssues")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("MyApp.Models.PostCategory", b =>
                {
                    b.HasOne("MyApp.Models.BlogPost", null)
                        .WithMany("category")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("MyApp.Models.BlogInstance", b =>
                {
                    b.Navigation("InstanceOfIssue");
                });

            modelBuilder.Entity("MyApp.Models.BlogPost", b =>
                {
                    b.Navigation("BlogInstances");

                    b.Navigation("BlogIssues");

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
