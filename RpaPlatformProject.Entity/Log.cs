namespace RpaPlatformProject.Entity
{
	public class Log
	{
		public int Id { get; set; }
		public int RobotId { get; set; }
		public Robot Robot { get; set; }

		public DateTime Timestamp { get; set; }
		public string Message { get; set; }
		public string LogType { get; set; } // "Info", "Warning", "Error"
	}
}
