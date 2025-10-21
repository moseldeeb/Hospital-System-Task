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

        [HttpGet]
        public IActionResult CompleteAppointment(int id)
        {
            var Doctor = _context.Doctors.SingleOrDefault(x => x.Id == id);
            if (Doctor is null) 
                return NotFound();

            ViewBag.DrName = Doctor.Name;
            ViewBag.Id = Doctor.Id;
            return View();
        }

        [HttpPost]
        public IActionResult CompleteAppointment(string Name, int Id, DateOnly Date, TimeOnly Time)
        {
            var doc = _context.Doctors.SingleOrDefault(x => x.Id == Id);
            if (doc is null)
                return NotFound();
            
            var patient = _context.Patients.SingleOrDefault(x => x.Name == Name);
            if(patient is null)
            {
                patient = new Patient
                {
                    Name = Name,
                };
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }

            var appointment = new Appointment
            {
                DoctorId = doc.Id,
                PatientId = patient.Id,
                Date = Date,
                Time = Time
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
