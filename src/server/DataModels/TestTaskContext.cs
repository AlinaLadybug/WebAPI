using Microsoft.EntityFrameworkCore;

namespace TestTask.DataModels
{
    public class TextTaskContext : DbContext
    {
        //private const string V = "name=TestTaskContext";

        public TextTaskContext(DbContextOptions<TextTaskContext> options) : base(options)
        {

        }

        public DbSet<DateModel> DateModels { get; set; }
    }
}
