﻿using System;
using System.Collections.Generic;
using Lab_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_6.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitizenAppeal> CitizenAppeals { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleTvshow> ScheduleTvshows { get; set; }

    public virtual DbSet<Tvshow> Tvshows { get; set; }

    public virtual DbSet<TvshowEmployee> TvshowEmployees { get; set; }

    public virtual DbSet<TvshowGuest> TvshowGuests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=db9986.public.databaseasp.net; Database=db9986; User Id=db9986; Password=5f@A#Ny46-Bn; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitizenAppeal>(entity =>
        {
            entity.HasKey(e => e.AppealId).HasName("PK__CitizenA__DFAC766DB2A29641");

            entity.ToTable("CitizenAppeal");

            entity.Property(e => e.AppealId).HasColumnName("appeal_id");
            entity.Property(e => e.DateAppeal)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Organization)
                .HasMaxLength(255)
                .HasColumnName("organization");
            entity.Property(e => e.Purpose).HasColumnName("purpose");
            entity.Property(e => e.ShowId).HasColumnName("show_id");

            entity.HasOne(d => d.Show).WithMany(p => p.CitizenAppeals)
                .HasForeignKey(d => d.ShowId)
                .HasConstraintName("FK__CitizenAp__show___4AB81AF0");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8625D2B30");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__18428D426CCEE2DA");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__19778E352E3B73BE");

            entity.ToTable("Guest");

            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__C46A8A6FB9054CF4");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.Date).HasColumnName("date");
        });

        modelBuilder.Entity<ScheduleTvshow>(entity =>
        {
            entity.HasKey(e => e.ScheduleTvshowId).HasName("PK__Schedule__B35EF5FE082385AC");

            entity.ToTable("Schedule_TVShow");

            entity.Property(e => e.ScheduleTvshowId).HasColumnName("schedule_tvshow_id");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.ShowId).HasColumnName("show_id");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleTvshows)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule___sched__4D94879B");

            entity.HasOne(d => d.Show).WithMany(p => p.ScheduleTvshows)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule___show___4E88ABD4");
        });

        modelBuilder.Entity<Tvshow>(entity =>
        {
            entity.HasKey(e => e.ShowId).HasName("PK__TVShow__2B97D71C540A5873");

            entity.ToTable("TVShow");

            entity.Property(e => e.ShowId).HasColumnName("show_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Genre).WithMany(p => p.Tvshows)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow__genre_id__3D5E1FD2");
        });

        modelBuilder.Entity<TvshowEmployee>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.EmployeeId }).HasName("PK__TVShow_E__B7C537A655637BFA");

            entity.ToTable("TVShow_Employee");

            entity.Property(e => e.ShowId).HasColumnName("show_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.TvshowEmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tvshow_employee_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.TvshowEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow_Em__emplo__412EB0B6");

            entity.HasOne(d => d.Show).WithMany(p => p.TvshowEmployees)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow_Em__show___403A8C7D");
        });

        modelBuilder.Entity<TvshowGuest>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.GuestId }).HasName("PK__TVShow_G__6A00AFFF1DFDF410");

            entity.ToTable("TVShow_Guest");

            entity.Property(e => e.ShowId).HasColumnName("show_id");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.TvshowGuestId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tvshow_guest_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.TvshowGuests)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow_Gu__guest__44FF419A");

            entity.HasOne(d => d.Show).WithMany(p => p.TvshowGuests)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow_Gu__show___440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
