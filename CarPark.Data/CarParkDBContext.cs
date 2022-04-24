using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarPark.Data
{
    public partial class CarParkDBContext : DbContext
    {
        public CarParkDBContext()
        {
        }

        public CarParkDBContext(DbContextOptions<CarParkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingOffice> BookingOffices { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2KF4JT8\\SQLEXPRESS;Initial Catalog=CarParkDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingOffice>(entity =>
            {
                entity.HasKey(e => e.OfficeId)
                    .HasName("PK__BookingO__4B61930FEB4C0F6E");

                entity.ToTable("BookingOffice");

                entity.Property(e => e.OfficeId).HasColumnName("OfficeID");

                entity.Property(e => e.EndContractDeadline).HasColumnType("date");

                entity.Property(e => e.OfficeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficePhone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.OfficePlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartContractDeadline).HasColumnType("date");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.BookingOffices)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__BookingOf__TripI__1CF15040");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.LicensePlate)
                    .HasName("PK__Car__026BC15D3FDCA591");

                entity.ToTable("Car");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CarColor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkId).HasColumnName("ParkID");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ParkId)
                    .HasConstraintName("FK__Car__ParkID__145C0A3F");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeBirthday).HasColumnType("date");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.ToTable("Park");

                entity.Property(e => e.ParkId).HasColumnName("ParkID");

                entity.Property(e => e.ParkName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkPlace)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ParkStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.LicensePlateNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.LicensePlate)
                    .HasConstraintName("FK__Ticket__LicenseP__1920BF5C");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Ticket__TripID__1A14E395");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Driver)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
