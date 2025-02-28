namespace RpaPlatformProject.Entity.DTO
{
	public class DashboardStatsDto
	{
		public int TotalRobots { get; set; }
		public int RunningRobots { get; set; }
		public int StoppedRobots { get; set; }
		public int ErrorCount { get; set; }
	}
}
