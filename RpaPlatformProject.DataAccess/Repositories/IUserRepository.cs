using RpaPlatformProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess.Repositories
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User?> GetUserByEmailAsync(string email);
	}
}
