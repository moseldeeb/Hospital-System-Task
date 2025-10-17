using System.Diagnostics;
using Hospital_System_Task.DataAccess;
using Hospital_System_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System_Task.Controllers
{
    public class DoctorsController : Controller
    {

        private readonly ILogger<DoctorsController> _logger;
        private ApplicationDbContext _context = new ApplicationDbContext();

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BookAppointment()
        {
            var Doctors = _context.Doctors.AsQueryable();
            return View(Doctors.AsEnumerable());
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
