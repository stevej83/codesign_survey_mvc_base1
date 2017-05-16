using SurveyMVCBase1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SurveyMVCBase1.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("aspnet-CodeSignSurveyBase1")
        {

        }

        public DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}