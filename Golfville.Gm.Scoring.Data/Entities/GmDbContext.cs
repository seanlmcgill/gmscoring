using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities;

public partial class GmDbContext : DbContext
{
    public GmDbContext()
    {
    }

    public GmDbContext(DbContextOptions<GmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberScore> MemberScores { get; set; }

    public virtual DbSet<TeeBox> TeeBoxes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Course");

            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.EmailAddress).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<MemberScore>(entity =>
        {
            entity.Property(e => e.PostDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberScores)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_MemberScores_Members");
        });

        modelBuilder.Entity<TeeBox>(entity =>
        {
            entity.HasKey(e => e.TeeBoxId).HasName("PK_TeeBox");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rating).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
