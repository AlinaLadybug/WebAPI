using server.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.DataModels
{
    interface IDateRepository
    {
        Task<ViewDateModel[]> GetDatesAsync(ViewDateModel dateModel);
        Task AddAsync(ViewDateModel dateModel);
    }
}