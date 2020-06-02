using DealingWithTimezonesInMvcCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DealingWithTimezonesInMvcCore.Controllers
{
    public class TestModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? NullableDate { get; set; }
    }

    public class TestController : Controller
    {
        private readonly UserCultureInfo _userCulture;

        public TestController(UserCultureInfo userCulture)
        {
            _userCulture = userCulture;
        }

        // GET: /<controller>/  
        public IActionResult Index()
        {
            return View(new TestModel());
        }
        
        [HttpPost]
        public IActionResult Index(TestModel model)
        {
            return View(model);
        }

        public IActionResult Json()
        {
            return Json(new
            {
                Id = 1,
                // real UTC datetime
                UtcDate = DateTime.UtcNow.ToString(),
                // UTC datetime converted by DateTimeConverter
                UtcDateConvertedByDateTimeConverter = DateTime.UtcNow,
                // user local time
                LocalTime = _userCulture.GetUserLocalTime()
            });
        }
    }
}
