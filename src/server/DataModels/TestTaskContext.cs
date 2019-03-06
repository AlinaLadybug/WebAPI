using Microsoft.EntityFrameworkCore;

namespace TestTask.DataModels
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        {

        }

        public virtual DbSet<DateModel> DateModels { get; set; }
    }
}
