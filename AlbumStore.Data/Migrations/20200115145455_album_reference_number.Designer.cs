﻿// <auto-generated />
using System;
using AlbumStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbumStore.Data.Migrations
{
    [DbContext(typeof(AlbumStoreDbContext))]
    [Migration("20200115145455_album_reference_number")]
    partial class album_reference_number
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbumStore.Core.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId")
                        .HasName("IFK_AlbumArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AlbumStore.Core.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("AlbumStore.Core.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("SupportRepId")
                        .HasName("IFK_CustomerSupportRepId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AlbumStore.Core.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("EmployeeId");

                    b.HasIndex("ReportsTo")
                        .HasName("IFK_EmployeeReportsTo");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AlbumStore.Core.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("AlbumStore.Core.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("BillingCity")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("BillingCountry")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("BillingPostalCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("BillingState")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId")
                        .HasName("IFK_InvoiceCustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("AlbumStore.Core.InvoiceLine", b =>
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

                    b.HasIndex("InvoiceId")
                        .HasName("IFK_InvoiceLineInvoiceId");

                    b.HasIndex("TrackId")
                        .HasName("IFK_InvoiceLineTrackId");

                    b.ToTable("InvoiceLine");
                });

            modelBuilder.Entity("AlbumStore.Core.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("AlbumStore.Core.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("AlbumStore.Core.PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "TrackId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("TrackId")
                        .HasName("IFK_PlaylistTrackTrackId");

                    b.ToTable("PlaylistTrack");
                });

            modelBuilder.Entity("AlbumStore.Core.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Composer")
                        .HasColumnType("nvarchar(220)")
                        .HasMaxLength(220);

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId")
                        .HasName("IFK_TrackAlbumId");

                    b.HasIndex("GenreId")
                        .HasName("IFK_TrackGenreId");

                    b.HasIndex("MediaTypeId")
                        .HasName("IFK_TrackMediaTypeId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("AlbumStore.Core.Album", b =>
                {
                    b.HasOne("AlbumStore.Core.Artist", "Artist")
                        .WithMany("Album")
                        .HasForeignKey("ArtistId")
                        .HasConstraintName("FK_AlbumArtistId")
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumStore.Core.Customer", b =>
                {
                    b.HasOne("AlbumStore.Core.Employee", "SupportRep")
                        .WithMany("Customer")
                        .HasForeignKey("SupportRepId")
                        .HasConstraintName("FK_CustomerSupportRepId");
                });

            modelBuilder.Entity("AlbumStore.Core.Employee", b =>
                {
                    b.HasOne("AlbumStore.Core.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_EmployeeReportsTo");
                });

            modelBuilder.Entity("AlbumStore.Core.Invoice", b =>
                {
                    b.HasOne("AlbumStore.Core.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_InvoiceCustomerId")
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumStore.Core.InvoiceLine", b =>
                {
                    b.HasOne("AlbumStore.Core.Invoice", "Invoice")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_InvoiceLineInvoiceId")
                        .IsRequired();

                    b.HasOne("AlbumStore.Core.Track", "Track")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK_InvoiceLineTrackId")
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumStore.Core.PlaylistTrack", b =>
                {
                    b.HasOne("AlbumStore.Core.Playlist", "Playlist")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("PlaylistId")
                        .HasConstraintName("FK_PlaylistTrackPlaylistId")
                        .IsRequired();

                    b.HasOne("AlbumStore.Core.Track", "Track")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK_PlaylistTrackTrackId")
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumStore.Core.Track", b =>
                {
                    b.HasOne("AlbumStore.Core.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_TrackAlbumId");

                    b.HasOne("AlbumStore.Core.Genre", "Genre")
                        .WithMany("Track")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TrackGenreId");

                    b.HasOne("AlbumStore.Core.MediaType", "MediaType")
                        .WithMany("Track")
                        .HasForeignKey("MediaTypeId")
                        .HasConstraintName("FK_TrackMediaTypeId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
