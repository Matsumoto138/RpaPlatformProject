using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RpaPlatformProject.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaPlatformProject.DataAccess
{
	public static class DalModule
	{
		public static void AddDataAccessLayer(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IRobotRepository, RobotRepository>();
			services.AddDbContext<RpaDbContext>(options =>
				options.UseSqlServer("Server=.;Database=RpaDB;Trusted_Connection=True;"));
		}
	}
}
