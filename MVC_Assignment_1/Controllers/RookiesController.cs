using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_1.Services;

namespace MVC_Assignment_1.Controllers
{
    [Route("NashTech/[controller]/[action]")]
    public class RookiesController : Controller
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        //NashTech/Rookies/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var people = _personService.GetAll();

            return Ok(people);
        }

        //NashTech/Rookies/GetMales
        [HttpGet]
        public IActionResult GetMale()
        {
            var people = _personService.GetMales();

            return Ok(people);
        }

        //NashTech/Rookies/GetOldest
        [HttpGet]
        public IActionResult GetOldest()
        {
            var oldest = _personService.GetOldest();

            return Ok(oldest);
        }

        //NashTech/Rookies/GetFullNames
        [HttpGet]
        public IActionResult GetFullNames()
        {
            var fullNames = _personService.GetFullNames();

            return Ok(fullNames);
        }

        //NashTech/Rookies/FilterByBirthYear?condition=equal
        //NashTech/Rookies/FilterByBirthYear?condition=greater
        //NashTech/Rookies/FilterByBirthYear?condition=less
        [HttpGet]
        public IActionResult FilterByBirthYear(string condition)
        {
            var result = _personService.FilterByBirthYear(condition);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var fileContents = _personService.ExportToExcel();
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
        }
    }
}
