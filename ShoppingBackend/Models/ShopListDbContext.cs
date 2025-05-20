using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingBackend.Models;

public partial class ShopListDbContext : DbContext
{
    public ShopListDbContext()
    {
    }

    public ShopListDbContext(DbContextOptions<ShopListDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Shoplist> Shoplist { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            
            //Paikallinen tietokanta
        //=> optionsBuilder.UseSqlServer("Data Source=Tony\\SQLEXPRESS; Database=ShopListDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    //Azure tietokanta
    => optionsBuilder.UseSqlServer("Server=tcp:tonysqlserver2.database.windows.net,1433;Initial Catalog=ShopListDB;Persist Security Info=False;User ID=admintony;Password=Spiderman989;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shoplist>(entity =>
        {
            entity.ToTable("Shoplist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Item)
                .HasMaxLength(50)
                .HasColumnName("item");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
