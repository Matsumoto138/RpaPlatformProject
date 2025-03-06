using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Interface
{
	public interface IRobotService
	{
		Task<List<Robot>> GetAllRobotsAsync();
		Task<Robot> GetRobotByIdAsync(int id);
		Task AddRobotAsync(Robot robot);
		Task UpdateRobotAsync(Robot robot);
		Task DeleteRobotAsync(int id);
		Task<int> GetTotalRobotCountAsync();
		Task<int> GetRunningRobotCountAsync();
		Task<int> GetStoppedRobotCountAsync();
		Task<List<Robot>> GetRecentRobotsAsync(int count);
	}
}
