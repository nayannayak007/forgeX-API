using ForgeXAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeXAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Attendance> Attendance => Set<Attendance>();
        public DbSet<Assessment> Assessments => Set<Assessment>();
        public DbSet<WorkoutCompletion> WorkoutCompletions => Set<WorkoutCompletion>();
        public DbSet<Workout> Workouts => Set<Workout>();

        public DbSet<UserSchool> UserSchools { get; set; }
         
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
        public DbSet<WorkoutCategory> WorkoutCategories { get; set; }
        public DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            // builder.Entity<Class>()
            // .HasMany(c => c.Players)
            // .WithOne(p => p.Class)
            // .HasForeignKey(p => p.ClassId)
            // .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Assessment>()
            .HasOne(a => a.Player)
            .WithMany()
            .HasForeignKey(a => a.PlayerId)
            .OnDelete(DeleteBehavior.NoAction);  

  
        builder.Entity<Assessment>()
            .HasOne(a => a.Class)
            .WithMany()
            .HasForeignKey(a => a.ClassId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<UserSchool>()
        .HasKey(us => new { us.UserId, us.SchoolId });

        builder.Entity<UserSchool>()
        .HasOne(us => us.User)
        .WithMany(u => u.UserSchools)
        .HasForeignKey(us => us.UserId);

        builder.Entity<UserSchool>()
        .HasOne(us => us.School)
        .WithMany(c => c.UserSchools)
        .HasForeignKey(us => us.SchoolId);
            
        }
    }
}
