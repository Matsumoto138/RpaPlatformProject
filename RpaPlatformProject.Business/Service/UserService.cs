using AutoMapper;
using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.DataAccess.Repositories;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task AddAsync(User user)
		{
			var newUser = _mapper.Map<User>(user);
			await _userRepository.AddAsync(newUser);
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<User>> GetAllAsync()
		{
			return await _userRepository.GetAllAsync();
		}

		public async Task<User?> GetByIdAsync(int id)
		{
			return await _userRepository.GetByIdAsync(id);
		}

		public Task<int> GetTotalUserCountAsync()
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(User user)
		{
			var updatedUser = await _userRepository.GetByIdAsync(user.Id);
			if (updatedUser != null)
			{
				_mapper.Map(user, updatedUser);
				_userRepository.Update(updatedUser);
			}
		}
	}
}
