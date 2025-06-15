using Microsoft.EntityFrameworkCore;

public class GymSystemDbContext : DbContext
    {
        public GymSystemDbContext(DbContextOptions<GymSystemDbContext> options)
        : base(options)
    {

    }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Branch> Branch {  get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Signup> tblSignup { get; set; }
        public DbSet<Member> tblMember { get; set; }
        public DbSet<WalkIn> tblWalkIn { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        modelBuilder.Entity<Signup>()
            .ToTable("tblSignUp")
            .HasKey(s => s.CustomerID);

        modelBuilder.Entity<Member>()
            .ToTable("tblMember")
            .HasKey(m => m.CustomerID);

        modelBuilder.Entity<WalkIn>()
            .ToTable("tblWalkIn")
            .HasKey(w => w.CustomerID);

        modelBuilder.Entity<Coach>()
             .ToTable("tblCoach")
             .HasKey(c => c.CoachID);

        modelBuilder.Entity<Branch>()
            .ToTable("tblBranch")
            .HasKey(b => b.BranchID);

        modelBuilder.Entity<Membership>()
            .ToTable("tblMembership")
            .HasKey(ms => ms.MembershipID);
    }
}

