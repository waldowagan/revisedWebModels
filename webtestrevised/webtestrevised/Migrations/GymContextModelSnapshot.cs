﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webtestrevised.Data;

namespace webtestrevised.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webtestrevised.Models.Client", b =>
                {
                    b.Property<string>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emergency_Contact_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emergency_Contact_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("F_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Login_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("StudentID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("webtestrevised.Models.CoursePaper", b =>
                {
                    b.Property<string>("CoursePaperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursePaper_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoursePaperID");

                    b.HasIndex("StaffID");

                    b.ToTable("CoursePapers");
                });

            modelBuilder.Entity("webtestrevised.Models.Login", b =>
                {
                    b.Property<string>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoursePaperID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Has_Client")
                        .HasColumnType("bit");

                    b.Property<bool>("Has_CoursePaper")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginID");

                    b.HasIndex("ClientID");

                    b.HasIndex("CoursePaperID");

                    b.HasIndex("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("webtestrevised.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emergency_Contact_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emergency_Contact_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("F_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Login_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("webtestrevised.Models.Staff", b =>
                {
                    b.HasBaseType("webtestrevised.Models.User");

                    b.Property<string>("Staff_No")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("webtestrevised.Models.Student", b =>
                {
                    b.HasBaseType("webtestrevised.Models.User");

                    b.Property<DateTime>("Membership_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Membership_Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<string>("Student_No")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("webtestrevised.Models.Client", b =>
                {
                    b.HasOne("webtestrevised.Models.Student", "Student")
                        .WithMany("Clients")
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("webtestrevised.Models.CoursePaper", b =>
                {
                    b.HasOne("webtestrevised.Models.Staff", "Staff")
                        .WithMany("CoursePapers")
                        .HasForeignKey("StaffID");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("webtestrevised.Models.Login", b =>
                {
                    b.HasOne("webtestrevised.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("webtestrevised.Models.CoursePaper", "CoursePaper")
                        .WithMany()
                        .HasForeignKey("CoursePaperID");

                    b.HasOne("webtestrevised.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Client");

                    b.Navigation("CoursePaper");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webtestrevised.Models.Staff", b =>
                {
                    b.Navigation("CoursePapers");
                });

            modelBuilder.Entity("webtestrevised.Models.Student", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
