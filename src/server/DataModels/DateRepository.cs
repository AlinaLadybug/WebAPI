using Microsoft.EntityFrameworkCore;
using server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.DataModels
{
    public class DateRepository : IDateRepository
    {
        private TestTaskContext _dbContext;


        public DateRepository(TestTaskContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ViewDateModel dateVm)
        {
            if (dateVm == null)
            {
                throw new ArgumentNullException("dateVm");
            }
            DateModel dateModel = new DateModel { DateBefore = dateVm.DateBefore, DateAfter = dateVm.DateAfter };
            _dbContext.DateModels.Add(dateModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ViewDateModel[]> GetDatesAsync(ViewDateModel dateModel)
        {
            var dateBefore = dateModel.DateBefore;
            var dateAfter = dateModel.DateAfter;
            var dates = await _dbContext.Set<DateModel>()
                                         .Where(x => x.DateBefore >= dateBefore && x.DateAfter <= dateAfter)
                                         .Select(x => new ViewDateModel
                                         {
                                             DateBefore = x.DateBefore,
                                             DateAfter = x.DateAfter
                                         })
                                         .ToArrayAsync();
            return dates;
        }
    }
}