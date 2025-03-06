using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Interface
{
	public interface IUserService
	{
		Task<List<User>> GetAllAsync();
		Task<User?> GetByIdAsync(int id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(int id);
		Task<int> GetTotalUserCountAsync();
	}
}
