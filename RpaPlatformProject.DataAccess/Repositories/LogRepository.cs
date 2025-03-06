using Microsoft.EntityFrameworkCore;
using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public class LogRepository : GenericRepository<Log>, ILogRepository
	{
		private readonly RpaDbContext _context;

		public LogRepository(RpaDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<List<Log>> GetLogsByRobotIdAsync(int robotId)
		{
			return await _context.Logs.Where(l => l.RobotId == robotId).ToListAsync();
		}
	}
}
