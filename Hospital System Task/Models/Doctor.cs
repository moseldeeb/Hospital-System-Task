namespace Hospital_System_Task.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string img { get; set;   }
        public ICollection<Appointment> appointments { get; set;  } = new List<Appointment>();

    }
}
