using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldCupFoodie.Models
{
    public partial class WorldCupFoodieContext : DbContext
    {
        public WorldCupFoodieContext()
        {
        }

        public WorldCupFoodieContext(DbContextOptions<WorldCupFoodieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=WorldCupFoodie;Integrated Security=SSPI;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Dish1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Dish");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK__Dishes__MatchId__267ABA7A");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.MatchDate).HasColumnType("datetime");

                entity.Property(e => e.Team1).HasMaxLength(30);

                entity.Property(e => e.Team2).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
