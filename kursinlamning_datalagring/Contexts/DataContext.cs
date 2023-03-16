using kursinlamning_datalagring.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace kursinlamning_datalagring.Contexts
{
    internal class DataContext : DbContext
    {
        #region Constructors    
        public DataContext()
        {

        }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion

        #region Overrides   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nikla\Desktop\kursinlamning_datalagring\kursinlamning_efc_db\kursinlamning_datalagring\Contexts\Repairshopdb.mdf;Integrated Security=True;Connect Timeout=30");
            
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentsEntity>()
                .HasOne(c => c.ErrorReport)
                .WithMany(o => o.Comments)
                .HasForeignKey(c => c.ErrorReportId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        #endregion


        public DbSet<CarOwnersEntity> CarOwners { get; set; } = null!;
        public DbSet<VehiclesEntity> Vehicles { get; set; } = null!;

        public DbSet<ErrorReportsEntity> ErrorReports { get; set; } = null!;

        public DbSet<MechanicsEntity> Mechanics { get; set; } = null!;

        public DbSet<CommentsEntity> Comments { get; set; } = null!;

        public DbSet<ErrorStatusesEntity> ErrorStatuses { get; set; } = null!;


    }
}

