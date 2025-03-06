using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.DataAccess.Repositories;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Service
{
	public class LogService : ILogService
	{
		private readonly ILogRepository _logRepository;
		public LogService(ILogRepository logRepository)
		{
			_logRepository = logRepository;
		}
		public async Task AddLogAsync(Log log)
		{
			var newLog = new Log
			{
				RobotId = log.RobotId,
				LogType = log.LogType,
				Message = log.Message,
				Timestamp = log.Timestamp
			};
			await _logRepository.AddAsync(newLog);
		}

		public async Task DeleteLogAsync(int id)
		{
			var log = await _logRepository.GetByIdAsync(id);
			_logRepository.Delete(log);
		}

		public async Task<List<Log>> GetAllLogsAsync()
		{
			var logs = await _logRepository.GetAllAsync();
			return logs.Select(x => new Log
			{
				Id = x.Id,
				RobotId = x.RobotId,
				LogType = x.LogType,
				Message = x.Message,
				Timestamp = x.Timestamp
			}).ToList();
		}

		public async Task<Log> GetLogByIdAsync(int id)
		{
			var log = await _logRepository.GetByIdAsync(id);
			if (log == null)
			{
				throw new Exception("Log not found");
			}

			return new Log
			{
				Id = log.Id,
				RobotId = log.RobotId,
				LogType = log.LogType,
				Message = log.Message,
				Timestamp = log.Timestamp
			};
		}

		public async Task UpdateLogAsync(Log log)
		{
			var updatedLog = await _logRepository.GetByIdAsync(log.Id);
			if (updatedLog == null)
			{
				throw new Exception("Log not found");
			}

			updatedLog.RobotId = log.RobotId;
			updatedLog.LogType = log.LogType;
			updatedLog.Message = log.Message;
			updatedLog.Timestamp = log.Timestamp;

			_logRepository.Update(updatedLog);
		}
	}
}
