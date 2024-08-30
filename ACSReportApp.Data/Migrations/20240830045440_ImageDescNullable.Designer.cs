﻿// <auto-generated />
using System;
using ACSReportApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    [DbContext(typeof(ACSReportAppDbContext))]
    [Migration("20240830045440_ImageDescNullable")]
    partial class ImageDescNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ACSReportApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ACSReportApp.Models.Cable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CableTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ConnectedFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ConnectedTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Delivery")
                        .HasColumnType("text");

                    b.Property<int?>("DesignLength")
                        .HasColumnType("integer");

                    b.Property<string>("FromDevice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FromLocation")
                        .HasColumnType("text");

                    b.Property<int?>("InstallLength")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLastRevision")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("PullDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("Revision")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RevisionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RevisionIssuedBy")
                        .HasColumnType("text");

                    b.Property<string>("Routing")
                        .HasColumnType("text");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("TestedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ToDevice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToLocation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CableTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Cables");
                });

            modelBuilder.Entity("ACSReportApp.Models.CableTray", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<double>("Length")
                        .HasColumnType("double precision");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Purpose")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("CableTrays");
                });

            modelBuilder.Entity("ACSReportApp.Models.CableType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("BendingRadius")
                        .HasColumnType("double precision");

                    b.Property<string>("CrossSection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double?>("Diameter")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PartNumber")
                        .HasColumnType("text");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Shield")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Voltage")
                        .HasColumnType("integer");

                    b.Property<double>("WeightPerKm")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("CableTypes");
                });

            modelBuilder.Entity("ACSReportApp.Models.Consumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("CosPhi")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Current")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Power")
                        .HasColumnType("double precision");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Voltage")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("ACSReportApp.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("CableTrayId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageDescription")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("ImageTag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CableTrayId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ACSReportApp.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("AuxPower")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PartNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("SignalType")
                        .HasColumnType("text");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Voltage")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("ACSReportApp.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int?>("CableTrayId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Diameter")
                        .HasColumnType("double precision");

                    b.Property<double?>("Height")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Length")
                        .HasColumnType("double precision");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Measurement")
                        .HasColumnType("integer");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PartAssemblyId")
                        .HasColumnType("integer");

                    b.Property<string>("PartType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double?>("Width")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CableTrayId");

                    b.HasIndex("PartAssemblyId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("ACSReportApp.Models.PartAssembly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CableTrayId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PartAssemblyType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CableTrayId");

                    b.ToTable("PartAssemblies");
                });

            modelBuilder.Entity("ACSReportApp.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contractor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ACSReportApp.Models.UserProject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ACSReportApp.Models.Cable", b =>
                {
                    b.HasOne("ACSReportApp.Models.CableType", "CableType")
                        .WithMany()
                        .HasForeignKey("CableTypeId");

                    b.HasOne("ACSReportApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CableType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ACSReportApp.Models.CableTray", b =>
                {
                    b.HasOne("ACSReportApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ACSReportApp.Models.Consumer", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSReportApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModifiedBy");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ACSReportApp.Models.Image", b =>
                {
                    b.HasOne("ACSReportApp.Models.CableTray", "CableTray")
                        .WithMany()
                        .HasForeignKey("CableTrayId");

                    b.Navigation("CableTray");
                });

            modelBuilder.Entity("ACSReportApp.Models.Instrument", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSReportApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModifiedBy");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ACSReportApp.Models.Part", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ACSReportApp.Models.CableTray", null)
                        .WithMany("Parts")
                        .HasForeignKey("CableTrayId");

                    b.HasOne("ACSReportApp.Models.PartAssembly", null)
                        .WithMany("Parts")
                        .HasForeignKey("PartAssemblyId");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("ACSReportApp.Models.PartAssembly", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSReportApp.Models.CableTray", null)
                        .WithMany("PartAssemblies")
                        .HasForeignKey("CableTrayId");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("ACSReportApp.Models.UserProject", b =>
                {
                    b.HasOne("ACSReportApp.Models.Project", "Project")
                        .WithMany("UsersProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSReportApp.Models.ApplicationUser", "User")
                        .WithMany("UsersProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ACSReportApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ACSReportApp.Models.ApplicationUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Roles");

                    b.Navigation("UsersProjects");
                });

            modelBuilder.Entity("ACSReportApp.Models.CableTray", b =>
                {
                    b.Navigation("PartAssemblies");

                    b.Navigation("Parts");
                });

            modelBuilder.Entity("ACSReportApp.Models.PartAssembly", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("ACSReportApp.Models.Project", b =>
                {
                    b.Navigation("UsersProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
