using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationCRUD.Models;

public partial class DailyExpancesContext : DbContext
{
    public DailyExpancesContext()
    {
    }

    public DailyExpancesContext(DbContextOptions<DailyExpancesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Expenses__3214EC07371D5477");

            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ExpenseDate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SpentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
