using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ViewModels;
using TestTask.DataModels;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly IDateRepository _dateRep;
        public DatesController(TestTaskContext dbContext)
        {
            _dateRep = new DateRepository(dbContext);
        }

        [HttpPost]
        [Route("range")]
        public async Task<ActionResult<ViewDateModel[]>> GetDatesAsync([FromBody] ViewDateModel dateModel)
        {
            try
            {
                var dates = await _dateRep.GetDatesAsync(dateModel);
                return dates;
            }
            catch
            {
               return BadRequest();
            }

        }

        // POST api/dates
        [HttpPost]
        public async Task Post([FromBody] ViewDateModel dateModel)
        {
            try
            {
                await _dateRep.AddAsync(dateModel);
                //var response = Request.<DateModel>(HttpStatusCode.Created, dateModel);
            }
            catch
            {
                BadRequest();
            }
        }


    }
}
