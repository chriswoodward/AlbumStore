﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlbumStore.Data
{
    public partial class AlbumStoreDbContext : DbContext
    {

        public AlbumStoreDbContext(DbContextOptions<AlbumStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.HasIndex(e => e.ArtistId)
                    .HasName("IFK_AlbumArtistId");

                entity.Property(e => e.ReferenceNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistId");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.ArtistId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.SupportRepId)
                    .HasName("IFK_CustomerSupportRepId");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Company).HasMaxLength(80);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SupportRepId)
                    .HasConstraintName("FK_CustomerSupportRepId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.ReportsTo)
                    .HasName("IFK_EmployeeReportsTo");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_EmployeeReportsTo");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IFK_InvoiceCustomerId");

                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.Property(e => e.BillingAddress).HasMaxLength(70);

                entity.Property(e => e.BillingCity).HasMaxLength(40);

                entity.Property(e => e.BillingCountry).HasMaxLength(40);

                entity.Property(e => e.BillingPostalCode).HasMaxLength(10);

                entity.Property(e => e.BillingState).HasMaxLength(40);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceCustomerId");
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.ToTable("InvoiceLine");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("IFK_InvoiceLineInvoiceId");

                entity.HasIndex(e => e.TrackId)
                    .HasName("IFK_InvoiceLineTrackId");

                entity.Property(e => e.InvoiceLineId).ValueGeneratedNever();

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineInvoiceId");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineTrackId");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("MediaType");

                entity.Property(e => e.MediaTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.PlaylistId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.ToTable("PlaylistTrack");

                entity.HasKey(e => new { e.PlaylistId, e.TrackId })
                    .IsClustered(false);

                entity.HasIndex(e => e.TrackId)
                    .HasName("IFK_PlaylistTrackTrackId");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistTrackPlaylistId");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistTrackTrackId");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("IFK_TrackAlbumId");

                entity.HasIndex(e => e.GenreId)
                    .HasName("IFK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeId)
                    .HasName("IFK_TrackMediaTypeId");

                entity.Property(e => e.TrackId).ValueGeneratedNever();

                entity.Property(e => e.Composer).HasMaxLength(220);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_TrackAlbumId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_TrackGenreId");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackMediaTypeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
