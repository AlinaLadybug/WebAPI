using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.DataModels
{
    public class DateRepository : IDateRepository
    {
        private TestTaskContext _dbContext;

        public DateRepository()
        {
        }

        public DateRepository(TestTaskContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void AddAsync(DateModel dateModel)
        {
            if (dateModel == null)
            {
                throw new ArgumentNullException("dateModel");
            }
            _dbContext.DateModels.Add(dateModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DateModel[]> GetDatesAsync(DateTime dateBefore, DateTime dateAfter)
        {
            var dates = await _dbContext.Set<DateModel>()
                                         .Where(x => x.DateBefore >= dateBefore && x.DateAfter <= dateAfter)
                                         .ToArrayAsync();
            return dates;
        }
    }
}