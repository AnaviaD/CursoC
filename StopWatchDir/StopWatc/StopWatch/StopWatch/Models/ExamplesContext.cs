using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StopWatch.Models;

public partial class ExamplesContext : DbContext
{
    public ExamplesContext()
    {
    }

    public ExamplesContext(DbContextOptions<ExamplesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveInvoice> ActiveInvoices { get; set; }

    public virtual DbSet<Apflat> Apflats { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentRecord> AssignmentRecords { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DateSample> DateSamples { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesOld> EmployeesOlds { get; set; }

    public virtual DbSet<EmployeesTest> EmployeesTests { get; set; }

    public virtual DbSet<Investor> Investors { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<NullSample> NullSamples { get; set; }

    public virtual DbSet<PaidInvoice> PaidInvoices { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<RealSample> RealSamples { get; set; }

    public virtual DbSet<SalesRep> SalesReps { get; set; }

    public virtual DbSet<SalesTotal> SalesTotals { get; set; }

    public virtual DbSet<Sample> Samples { get; set; }

    public virtual DbSet<StringSample> StringSamples { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FP59UDN\\SQLEXPRESS;Initial Catalog=Examples; TrustServerCertificate=True; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveInvoice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreditTotal).HasColumnType("money");
            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceTotal).HasColumnType("money");
            entity.Property(e => e.PaymentTotal).HasColumnType("money");
            entity.Property(e => e.TermsId).HasColumnName("TermsID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<Apflat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APFlat");

            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__assignme__3214EC0785947ECD");

            entity.ToTable("assignment");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Difficulty)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AssignmentRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__assignme__3214EC0716AADDCB");

            entity.ToTable("assignmentRecord");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AssigmentId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalTime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Assigment).WithMany(p => p.AssignmentRecords)
                .HasForeignKey(d => d.AssigmentId)
                .HasConstraintName("FK__assignmen__Assig__4BAC3F29");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId);

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustAddr).HasMaxLength(60);
            entity.Property(e => e.CustCity).HasMaxLength(15);
            entity.Property(e => e.CustPhone).HasMaxLength(24);
            entity.Property(e => e.CustState).HasMaxLength(15);
            entity.Property(e => e.CustZip).HasMaxLength(10);
            entity.Property(e => e.CustomerFirst).HasMaxLength(30);
            entity.Property(e => e.CustomerLast).HasMaxLength(30);
        });

        modelBuilder.Entity<DateSample>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DateSample");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo);

            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
        });

        modelBuilder.Entity<EmployeesOld>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_Employees");

            entity.ToTable("EmployeesOld");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeesTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeesTest");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
        });

        modelBuilder.Entity<Investor>(entity =>
        {
            entity.Property(e => e.InvestorId).HasColumnName("InvestorID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Investments).HasColumnType("money");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NetGain).HasColumnType("money");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.InvoiceTotal).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<NullSample>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NullSample");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.InvoiceTotal).HasColumnType("money");
        });

        modelBuilder.Entity<PaidInvoice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreditTotal).HasColumnType("money");
            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceTotal).HasColumnType("money");
            entity.Property(e => e.PaymentTotal).HasColumnType("money");
            entity.Property(e => e.TermsId).HasColumnName("TermsID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProjectNo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<RealSample>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RealSample");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<SalesRep>(entity =>
        {
            entity.HasKey(e => e.RepId);

            entity.Property(e => e.RepId).HasColumnName("RepID");
            entity.Property(e => e.RepFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RepLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalesTotal>(entity =>
        {
            entity.HasKey(e => new { e.RepId, e.SalesYear });

            entity.Property(e => e.RepId).HasColumnName("RepID");
            entity.Property(e => e.SalesYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SalesTotal1)
                .HasColumnType("money")
                .HasColumnName("SalesTotal");

            entity.HasOne(d => d.Rep).WithMany(p => p.SalesTotals)
                .HasForeignKey(d => d.RepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesTotals_SalesReps");
        });

        modelBuilder.Entity<Sample>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sample");

            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("None")
                .IsFixedLength();
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<StringSample>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StringSample");

            entity.Property(e => e.AltId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AltID");
            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasIndex(e => e.VendorName, "IX_VendorName").IsUnique();

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.AccountNo).HasDefaultValue(570);
            entity.Property(e => e.LastYtdpurchases)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("LastYTDPurchases");
            entity.Property(e => e.LastYtdreturns)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("LastYTDReturns");
            entity.Property(e => e.TermsId)
                .HasDefaultValue(3)
                .HasColumnName("TermsID");
            entity.Property(e => e.VendorAddress1).HasMaxLength(50);
            entity.Property(e => e.VendorAddress2).HasMaxLength(50);
            entity.Property(e => e.VendorCity).HasMaxLength(50);
            entity.Property(e => e.VendorContactFname)
                .HasMaxLength(35)
                .HasColumnName("VendorContactFName");
            entity.Property(e => e.VendorContactLname)
                .HasMaxLength(35)
                .HasColumnName("VendorContactLName");
            entity.Property(e => e.VendorName).HasMaxLength(50);
            entity.Property(e => e.VendorPhone).HasMaxLength(50);
            entity.Property(e => e.VendorState)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.VendorZipCode).HasMaxLength(10);
            entity.Property(e => e.Ytdpurchases)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("YTDPurchases");
            entity.Property(e => e.Ytdreturns)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("YTDReturns");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
