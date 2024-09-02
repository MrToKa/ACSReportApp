using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ACSReportApp.Models;
using Microsoft.Extensions.Configuration;

namespace ACSReportApp.Data
{
    public class ACSReportAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public ACSReportAppDbContext()
        {
        }

        public ACSReportAppDbContext(DbContextOptions<ACSReportAppDbContext> options)
            : base(options)
        {
        }

        private string BuildConnectionString()
        {
            //Home settings environment
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\TOKA\source\repos\ACSReportApp\ACSReportApp\appsettings.json")
                .Build();

            //Work settings environment
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile(@"C:\Users\todor.chankov\source\repos\ACSReportApp\ACSReportApp\appsettings.json")
            //    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            return connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
        BuildConnectionString(),
        options => options.UseAdminDatabase("postgres"));
        }

        public DbSet<Cable> Cables { get; set; }
        public DbSet<CableTray> CableTrays { get; set; }
        public DbSet<CableType> CableTypes { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartAssembly> PartAssemblies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PartAssemblyPart> PartAssemblyParts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProject>()
                .HasKey(up => new { up.UserId, up.ProjectId });

            builder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.UsersProjects)
                .HasForeignKey(up => up.UserId);

            builder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UsersProjects)
                .HasForeignKey(up => up.ProjectId);

            builder.Entity<PartAssemblyPart>()
                .HasKey(pap => new { pap.PartId, pap.PartAssemblyId });

            builder.Entity<Part>()
                .HasMany(p => p.PartAssemblies)
                .WithOne(pa => pa.Part)
                .HasForeignKey(pa => pa.PartId);

            builder.Entity<PartAssembly>()
                .HasMany(pa => pa.PartAssemblyParts)
                .WithOne(pap => pap.PartAssembly)
                .HasForeignKey(pap => pap.PartAssemblyId);

            base.OnModelCreating(builder);
        }
    }
}
