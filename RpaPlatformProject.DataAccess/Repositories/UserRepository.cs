using Microsoft.EntityFrameworkCore;
using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly RpaDbContext _context;
		public UserRepository(RpaDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}
	}
}
