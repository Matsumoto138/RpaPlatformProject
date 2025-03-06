using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.DataAccess.Repositories;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Service
{
	public class ScheduleService : IScheduleService
	{
		private readonly IScheduleRepository _scheduleRepository;
		public ScheduleService(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}
		public async Task AddScheduleAsync(Schedule schedule)
		{
			var newSchedule = new Schedule
			{
				RobotId = schedule.RobotId,
				StartTime = schedule.StartTime,
				EndTime = schedule.EndTime,
				Frequency = schedule.Frequency,
			};

			await _scheduleRepository.AddAsync(newSchedule);
		}

		public async Task DeleteScheduleAsync(int id)
		{
			var schedule = await _scheduleRepository.GetByIdAsync(id);
			_scheduleRepository.Delete(schedule);
		}

		public async Task<List<Schedule>> GetAllSchedulesAsync()
		{
			var schedules = await _scheduleRepository.GetAllAsync();
			return schedules.Select(x => new Schedule
			{
				Id = x.Id,
				RobotId = x.RobotId,
				StartTime = x.StartTime,
				EndTime = x.EndTime,
				Frequency = x.Frequency,
			}).ToList();
		}

		public async Task<Schedule> GetScheduleByIdAsync(int id)
		{
			var schedule = await _scheduleRepository.GetByIdAsync(id);
			if (schedule == null)
			{
				throw new Exception("Schedule not found");
			}

			return new Schedule
			{
				Id = schedule.Id,
				RobotId = schedule.RobotId,
				StartTime = schedule.StartTime,
				EndTime = schedule.EndTime,
				Frequency = schedule.Frequency,
			};
		}

		public async Task UpdateScheduleAsync(Schedule schedule)
		{
			var updatedSchedule = await _scheduleRepository.GetByIdAsync(schedule.Id);
			if (updatedSchedule == null)
			{
				throw new Exception("Schedule not found");
			}

			updatedSchedule.RobotId = schedule.RobotId;
			updatedSchedule.StartTime = schedule.StartTime;
			updatedSchedule.EndTime = schedule.EndTime;
			updatedSchedule.Frequency = schedule.Frequency;

			_scheduleRepository.Update(updatedSchedule);
		}
	}
}
