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
	}
}
