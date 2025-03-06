using AutoMapper;
using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.DataAccess.Repositories;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Service
{
	public class RobotService : IRobotService
	{
		private readonly IRobotRepository _robotRepository;
		private readonly IMapper _mapper;

		public RobotService(IRobotRepository robotRepository, IMapper mapper)
		{
			_robotRepository = robotRepository;
			_mapper = mapper;
		}

		public async Task<List<Robot>> GetAllRobotsAsync()
		{
			return (await _robotRepository.GetAllAsync()).ToList();
		}

		public async Task<Robot> GetRobotByIdAsync(int id)
		{
			return await _robotRepository.GetByIdAsync(id);
		}

		public async Task AddRobotAsync(Robot robot)
		{
			var newRobot = _mapper.Map<Robot>(robot);
			await _robotRepository.AddAsync(newRobot);
		}

		public async Task UpdateRobotAsync(Robot robot)
		{
			var existingRobot = await _robotRepository.GetByIdAsync(robot.Id);
			if (existingRobot != null)
			{
				_mapper.Map(robot, existingRobot);
				_robotRepository.Update(existingRobot);
			}
		}

		public async Task DeleteRobotAsync(int id)
		{
			var robot = await _robotRepository.GetByIdAsync(id);
			if (robot != null)
			{
				_robotRepository.Delete(robot);
			}
		}

		public async Task<int> GetTotalRobotCountAsync()
		{
			return await _robotRepository.GetTotalRobotCountAsync();
		}

		public async Task<int> GetRunningRobotCountAsync()
		{
			return await _robotRepository.GetRunningRobotCountAsync();
		}

		public async Task<int> GetStoppedRobotCountAsync()
		{
			return await _robotRepository.GetStoppedRobotCountAsync();
		}

		public async Task<List<Robot>> GetRecentRobotsAsync(int count)
		{
			return await _robotRepository.GetRecentRobotsAsync(count);
		}
	}
}
