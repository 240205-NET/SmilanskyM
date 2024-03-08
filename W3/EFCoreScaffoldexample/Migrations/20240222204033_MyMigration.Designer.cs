﻿// <auto-generated />
using System;
using EFCoreScaffoldexample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreScaffoldexample.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20240222204u001b_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("AlbumId");

                    b.HasIndex(new[] { "ArtistId" }, "IFK_AlbumArtistId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Class", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CourseID");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnName("InstructorID");

                    b.Property<int>("RoomNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Classes__3214EC07D0481966");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Classes", "School");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RequirementId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Courses__3214EC078BD037B6");

                    b.HasIndex("RequirementId");

                    b.ToTable("Courses", "School");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Company")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex(new[] { "SupportRepId" }, "IFK_CustomerSupportRepId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "ReportsTo" }, "IFK_EmployeeReportsTo");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("BillingAddress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("BillingCity")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("BillingCountry")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("BillingPostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BillingState")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex(new[] { "CustomerId" }, "IFK_InvoiceCustomerId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.InvoiceLine", b =>
                {
                    b.Property<int>("InvoiceLineId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("InvoiceLineId");

                    b.HasIndex(new[] { "InvoiceId" }, "IFK_InvoiceLineInvoiceId");

                    b.HasIndex(new[] { "TrackId" }, "IFK_InvoiceLineTrackId");

                    b.ToTable("InvoiceLine", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaType", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Gpa")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("GPA");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Students__3214EC074075AF7A");

                    b.ToTable("Students", "School");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.StudentsClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Students__3214EC07F3BB8D98");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentsClasses", "School");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Office")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Teachers__3214EC07E422CB99");

                    b.ToTable("Teachers", "School");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Composer")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("TrackId");

                    b.HasIndex(new[] { "AlbumId" }, "IFK_TrackAlbumId");

                    b.HasIndex(new[] { "GenreId" }, "IFK_TrackGenreId");

                    b.HasIndex(new[] { "MediaTypeId" }, "IFK_TrackMediaTypeId");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "TrackId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PlaylistId", "TrackId"), false);

                    b.HasIndex(new[] { "TrackId" }, "IFK_PlaylistTrackTrackId");

                    b.ToTable("PlaylistTrack", (string)null);
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Album", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("FK_AlbumArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Class", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK__Classes__CourseI__1DB06A4F");

                    b.HasOne("EFCoreScaffoldexample.Model.Teacher", "Instructor")
                        .WithMany("Classes")
                        .HasForeignKey("InstructorId")
                        .IsRequired()
                        .HasConstraintName("FK__Classes__Instruc__1CBC4616");

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Course", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Course", "Requirement")
                        .WithMany("InverseRequirement")
                        .HasForeignKey("RequirementId")
                        .HasConstraintName("FK__Courses__Require__19DFD96B");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Customer", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Employee", "SupportRep")
                        .WithMany("Customers")
                        .HasForeignKey("SupportRepId")
                        .HasConstraintName("FK_CustomerSupportRepId");

                    b.Navigation("SupportRep");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Employee", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_EmployeeReportsTo");

                    b.Navigation("ReportsToNavigation");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Invoice", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceCustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.InvoiceLine", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Invoice", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceLineInvoiceId");

                    b.HasOne("EFCoreScaffoldexample.Model.Track", "Track")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("TrackId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceLineTrackId");

                    b.Navigation("Invoice");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.StudentsClass", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Class", "Class")
                        .WithMany("StudentsClasses")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK__StudentsC__Class__2180FB33");

                    b.HasOne("EFCoreScaffoldexample.Model.Student", "Student")
                        .WithMany("StudentsClasses")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__StudentsC__Stude__208CD6FA");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Track", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_TrackAlbumId");

                    b.HasOne("EFCoreScaffoldexample.Model.Genre", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TrackGenreId");

                    b.HasOne("EFCoreScaffoldexample.Model.MediaType", "MediaType")
                        .WithMany("Tracks")
                        .HasForeignKey("MediaTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_TrackMediaTypeId");

                    b.Navigation("Album");

                    b.Navigation("Genre");

                    b.Navigation("MediaType");
                });

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.HasOne("EFCoreScaffoldexample.Model.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrackPlaylistId");

                    b.HasOne("EFCoreScaffoldexample.Model.Track", null)
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrackTrackId");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Class", b =>
                {
                    b.Navigation("StudentsClasses");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Course", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("InverseRequirement");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Employee", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("InverseReportsToNavigation");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Genre", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Invoice", b =>
                {
                    b.Navigation("InvoiceLines");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.MediaType", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Student", b =>
                {
                    b.Navigation("StudentsClasses");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Teacher", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("EFCoreScaffoldexample.Model.Track", b =>
                {
                    b.Navigation("InvoiceLines");
                });
#pragma warning restore 612, 618
        }
    }
}