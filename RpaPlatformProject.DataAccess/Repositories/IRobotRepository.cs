using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public interface IRobotRepository : IGenericRepository<Robot>
	{
		Task<IEnumerable<Robot>> GetActiveRobotAsync();
		Task<int> GetTotalRobotCountAsync();
		Task<int> GetRunningRobotCountAsync();
		Task<int> GetStoppedRobotCountAsync();
		Task<List<Robot>> GetRecentRobotsAsync(int count = 5);
	}
}
