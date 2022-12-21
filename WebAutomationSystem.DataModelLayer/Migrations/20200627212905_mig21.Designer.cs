﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAutomationSystem.DataModelLayer;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200627212905_mig21")]
    partial class mig21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.AdministrativeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdministrativeFormContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdministrativeFormTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AdministrativeFormType")
                        .HasColumnType("bit");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("AdministrativeForm");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.ApplicationRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("RoleLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDayDateMilladi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsAdmin")
                        .HasColumnType("tinyint");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MelliCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignaturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.JobsChart", b =>
                {
                    b.Property<int>("JobsChartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobsChartDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobsChartLevel")
                        .HasColumnType("int");

                    b.Property<string>("JobsChartName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobsChartID");

                    b.ToTable("JobsChart");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Leave", b =>
                {
                    b.Property<int>("LeaveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FromDate_Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FromTime_Saati")
                        .HasColumnType("datetime2");

                    b.Property<byte>("LeaveAccept")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("LeaveRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("LeaveType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("ToDate_Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ToTime_Saati")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID_Confirm")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID_Request")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LeaveID");

                    b.HasIndex("UserID_Confirm");

                    b.HasIndex("UserID_Request");

                    b.ToTable("Leave");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Letters", b =>
                {
                    b.Property<int>("LetterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AttachmentStatus")
                        .HasColumnType("bit");

                    b.Property<byte>("ClassificationStatus")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ImmediatellyStatus")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsInDraft")
                        .HasColumnType("bit");

                    b.Property<string>("LetterAttachamentFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LetterContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LetterCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LetterNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LetterSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("LetterType")
                        .HasColumnType("tinyint");

                    b.Property<int>("MainLetterID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ReplyStatus")
                        .HasColumnType("bit");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LetterID");

                    b.HasIndex("UserID");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Notation", b =>
                {
                    b.Property<int>("NotationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NotationContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotationTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID_Creator")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID_Reciever")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotationID");

                    b.HasIndex("UserID_Creator");

                    b.HasIndex("UserID_Reciever");

                    b.ToTable("Notation");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.ReferralLetters", b =>
                {
                    b.Property<int>("ReferralLettersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LetterID")
                        .HasColumnType("int");

                    b.Property<bool>("ReadType")
                        .HasColumnType("bit");

                    b.Property<string>("RecieveReferUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReferDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("mainUserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReferralLettersID");

                    b.HasIndex("LetterID");

                    b.HasIndex("RecieveReferUserID");

                    b.HasIndex("ReferUserID");

                    b.HasIndex("mainUserID");

                    b.ToTable("ReferralLetters");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Reminder", b =>
                {
                    b.Property<int>("ReminderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("ReminderContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReminderCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReminderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReminderTtile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReminderID");

                    b.HasIndex("UserID");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.RolePattern", b =>
                {
                    b.Property<int>("RolePatternID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RolePatternDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolePatternName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolePatternID");

                    b.ToTable("RolePattern");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.RolePatternDetails", b =>
                {
                    b.Property<int>("RolePatternDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RolePatternID")
                        .HasColumnType("int");

                    b.HasKey("RolePatternDetailsID");

                    b.HasIndex("RoleID");

                    b.HasIndex("RolePatternID");

                    b.ToTable("RolePatternDetails");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.SentLetters", b =>
                {
                    b.Property<int>("SentLetterdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LetterID")
                        .HasColumnType("int");

                    b.Property<bool>("ReadType")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SentLetterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId_reciever")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userId_sender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SentLetterdID");

                    b.HasIndex("LetterID");

                    b.HasIndex("userId_reciever");

                    b.ToTable("SentLetters");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.UserJob", b =>
                {
                    b.Property<int>("UserJobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndJobDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IaHaveJob")
                        .HasColumnType("bit");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartJobDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserJobID");

                    b.HasIndex("JobID");

                    b.HasIndex("UserID");

                    b.ToTable("UserJob");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.AdministrativeForm", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Leave", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "User_Confirm")
                        .WithMany()
                        .HasForeignKey("UserID_Confirm");

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "User_Request")
                        .WithMany()
                        .HasForeignKey("UserID_Request");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Letters", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Notation", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "User_Creator")
                        .WithMany()
                        .HasForeignKey("UserID_Creator");

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "User_Reciever")
                        .WithMany()
                        .HasForeignKey("UserID_Reciever");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.ReferralLetters", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.Letters", "Letters")
                        .WithMany()
                        .HasForeignKey("LetterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users_RecieveUserId")
                        .WithMany()
                        .HasForeignKey("RecieveReferUserID");

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users_ReferUserId")
                        .WithMany()
                        .HasForeignKey("ReferUserID");

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users_main")
                        .WithMany()
                        .HasForeignKey("mainUserID");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.Reminder", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.RolePatternDetails", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationRoles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.RolePattern", "RP")
                        .WithMany()
                        .HasForeignKey("RolePatternID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.SentLetters", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.Letters", "Letter")
                        .WithMany()
                        .HasForeignKey("LetterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users_Reciever")
                        .WithMany()
                        .HasForeignKey("userId_reciever");
                });

            modelBuilder.Entity("WebAutomationSystem.DataModelLayer.Entities.UserJob", b =>
                {
                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.JobsChart", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutomationSystem.DataModelLayer.Entities.ApplicationUsers", "Users")
                        .WithMany()
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
