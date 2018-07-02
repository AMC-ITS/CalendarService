using System;
using System.Net;
using DateMicroservice.Data;
using Microsoft.AspNetCore.Mvc;

namespace DateMicroservice.Controllers
{
    [Route("[controller]")]
    public class DateController : Controller
    {
        private IDimDateAccess DimDateAccess { get; }
        public DateController(IDimDateAccess dimDateAccess)
        {
            DimDateAccess = dimDateAccess;
        }
        
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DateModel[]))]
        public ActionResult Get([FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day)
        {
            var dateSet = DimDateAccess.GetDateSet(year, month, day);
            if (dateSet == null || dateSet.Length == 0)
            {
                return NotFound();
            }
            return Ok(dateSet);
        }

        [HttpGet("NextBusinessDay")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type= typeof(DateTime))]
        public ActionResult GetNextBusinessDay([FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day)
        {
            var date = DimDateAccess.GetNextBusinessDay(year, month, day);
            if (date == null)
            {
                return NotFound();
            }
            return Ok(date);
        }

        [HttpGet("LastBusinessDay")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DateTime))]
        public ActionResult GetLastBusinessDay([FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day)
        {
            var date = DimDateAccess.GetLastBusinessDay(year, month, day);
            if (date == null)
            {
                return NotFound();
            }
            return Ok(date);
        }

        [HttpGet("NextHoliday")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DateTime))]
        public ActionResult GetNextHoliday([FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day)
        {
            var date = DimDateAccess.GetNextHoliday(year, month, day);
            if (date == null)
            {
                return NotFound();
            }
            return Ok(date);
        }
    }
}
