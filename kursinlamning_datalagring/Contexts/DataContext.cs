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
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nikla\\Desktop\\kursinlamning_datalagring\\kursinlamning_efc_db\\kursinlamning_datalagring\\Contexts\\sql_db.mdf;Integrated Security=True;Connect Timeout=30")
            
            };
        }

        #endregion

        

    }
}

