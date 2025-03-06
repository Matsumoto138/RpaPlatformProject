namespace RpaPlatformProject.Entity
{
	public class Robot
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Status { get; set; } // "Idle", "Running", "Stopped"
		public DateTime CreatedAt { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public ICollection<Schedule> Schedules { get; set; } // Zamanlama bilgisi
		public ICollection<Log> Logs { get; set; } // Çalıştırma geçmişi
	}
}
