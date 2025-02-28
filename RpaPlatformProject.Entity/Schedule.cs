namespace RpaPlatformProject.Entity
{
	public class Schedule
	{
		public int Id { get; set; }
		public int RobotId { get; set; }
		public Robot Robot { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public bool IsRecurring { get; set; } // Tekrar eden işlem mi?
		public string Frequency { get; set; } // Örn: "Daily", "Weekly", "Monthly"
	}
}
