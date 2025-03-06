using Microsoft.EntityFrameworkCore;
using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
	{
		private readonly RpaDbContext _context;

		public ScheduleRepository(RpaDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<List<Schedule>> GetSchedulesByRobotIdAsync(int robotId)
		{
			return await _context.Schedules.Where(s => s.RobotId == robotId).ToListAsync();
		}
	}
}
