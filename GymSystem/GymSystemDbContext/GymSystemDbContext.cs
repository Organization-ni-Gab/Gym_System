using Microsoft.EntityFrameworkCore;

public class GymSystemDbContext : DbContext
    {
        public GymSystemDbContext(DbContextOptions<GymSystemDbContext> options)
        : base(options)
    {

    }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Branch> Branch {  get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        modelBuilder.Entity<Coach>()
             .ToTable("tblCoach")
             .HasKey(c => c.CoachID);
        modelBuilder.Entity<Branch>()
            .ToTable("tblBranch")
            .HasKey(b => b.BranchID);
        modelBuilder.Entity<Member>()
            .ToTable("tblMember")
            .HasKey(m => m.MemberID);
        modelBuilder.Entity<Membership>()
            .ToTable("tblMembership")
            .HasKey(ms => ms.MembershipID);
    }
}

