using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataModels;
using Xunit;

namespace test
{
    public class DateRepositoryTest
    {
        private DateRepository _dateRep;
        private TestTaskContext _testTaskCtx;
        public DateRepositoryTest()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: false);
            IConfigurationRoot configuration = builder.Build();
            var testTaskOpsBuilder = new DbContextOptionsBuilder<TestTaskContext>();

            _testTaskCtx = new TestTaskContext(testTaskOpsBuilder.UseSqlServer(configuration["ConnectionStrings:TestTaskContext"]).Options);

            _dateRep = new DateRepository(_testTaskCtx);
        }

        [Theory]
        [InlineData("1111/1/1", "2030/2/2")]
        public async Task ShouldReturnDateRanges(string begin, string end)
        {
            var dateBegin =DateTime.Parse(begin);
            var dateEnd = DateTime.Parse(end);
            var dateModel = new ViewDateModel { DateBefore = dateBegin, DateAfter = dateEnd };
            var dates = await _dateRep.GetDatesAsync(dateModel);
            Assert.True(dates.Length>0,$"Expected not empty list of dates in range: {begin} - {end}");
        }

        [Theory]
        [InlineData("1112/1/1", "2030/2/2")]
        public async Task ShouldAddDateRange(string dateBefore,string dateAfter)
        {
            //add some range to DB
            var dateBegin = DateTime.Parse(dateBefore);
            var dateEnd = DateTime.Parse(dateAfter);
            var dateModel = new ViewDateModel { DateBefore = dateBegin, DateAfter = dateEnd };
            await _dateRep.AddAsync(dateModel);

            //check if it created
            var dates = await _dateRep.GetDatesAsync(dateModel);
            Assert.True(dates.Any(x => x.DateBefore == dateBegin && x.DateAfter == dateEnd), $"Expected the date range {dateBefore} - {dateAfter} be found in DB.");

        }
    }
}
