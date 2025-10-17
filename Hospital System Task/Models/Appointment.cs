namespace Hospital_System_Task.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public enum AppointmentStatus
        {
            Pending,
            Confirmed,
            Completed,
            Cancelled,
            NoShow
        }

    }
}
