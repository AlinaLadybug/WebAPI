using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.DataModels
{
    interface IDateRepository
    {
        Task<DateModel[]> GetDatesAsync(DateTime dateBefore, DateTime dateAfter);
        void AddAsync(DateModel dateModel);
    }
}