using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Interface
{
	public interface ILogService
	{
		Task<List<Log>> GetAllLogsAsync();
		Task<Log> GetLogByIdAsync(int id);
		Task AddLogAsync(Log log);
		Task UpdateLogAsync(Log log);
		Task DeleteLogAsync(int id);
	}

}
