using Microsoft.EntityFrameworkCore;
using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public class RobotRepository : GenericRepository<Robot>, IRobotRepository
	{
		private readonly RpaDbContext _context;

		public RobotRepository(RpaDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Robot>> GetActiveRobotAsync()
		{
			return await _context.Robots.Where(r => r.Status == "Running").ToListAsync();
		}

		public async Task<List<Robot>> GetRecentRobotsAsync(int count = 5)
		{
			return await _context.Robots
			.OrderByDescending(r => r.CreatedAt)
			.Take(count)
			.ToListAsync();
		}

		public async Task<int> GetRunningRobotCountAsync()
		{
			return await _context.Robots.CountAsync(r => r.Status == "Running");
		}

		public async Task<int> GetStoppedRobotCountAsync()
		{
			return await _context.Robots.CountAsync(r => r.Status == "Stopped");
		}

		public async Task<int> GetTotalRobotCountAsync()
		{
			return await _context.Robots.CountAsync();
		}
	}
}
