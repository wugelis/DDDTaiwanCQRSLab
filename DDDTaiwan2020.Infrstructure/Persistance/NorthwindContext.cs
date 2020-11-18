using System;
using System.Threading.Tasks;
using DDDTaiwan2020.Application.Common.Interfaces;
using DDDTaiwan2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDDTaiwan2020.Infrastructure.Persistance
{
    public partial class NorthwindContext : DbContext, IApplicationDbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomersEnt> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=(local)\\MSSQLSERVER2017;Database=Northwind;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomersEnt>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.City)
                    .HasName("City");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("CompanyName");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("PostalCode");

                entity.HasIndex(e => e.Region)
                    .HasName("Region");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(bool cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
