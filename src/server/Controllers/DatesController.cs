using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.DataModels;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly IDateRepository _dateRep = new DateRepository();

        // GET api/dates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateModel>>> GetDatesAsync([FromBody] DateTime dateBefore, DateTime dateAfter)
        {
            var dates = await _dateRep.GetDatesAsync(dateBefore, dateAfter);
            return dates;

        }

        // POST api/dates
        [HttpPost]
        public void Post(DateModel dateModel)
        {

            _dateRep.AddAsync(dateModel);
            //var response = Request.<DateModel>(HttpStatusCode.Created, dateModel);

        }


    }
}
