using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Interface
{
	public interface IScheduleService
	{
		Task<List<Schedule>> GetAllSchedulesAsync();
		Task<Schedule> GetScheduleByIdAsync(int id);
		Task AddScheduleAsync(Schedule schedule);
		Task UpdateScheduleAsync(Schedule schedule);
		Task DeleteScheduleAsync(int id);
	}

}
