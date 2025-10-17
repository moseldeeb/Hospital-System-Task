namespace Hospital_System_Task.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int Age => DateTime.Now.Year - DOB.Year;
        public ICollection<Appointment> appointments { get; set; } = new List<Appointment>();
    }
}
