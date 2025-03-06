using AutoMapper;
using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.DataAccess.Repositories;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.Business.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task AddAsync(User user)
		{
			var newUser = new User
			{
				FullName = user.FullName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				Role = user.Role
			};
			await _userRepository.AddAsync(newUser);
		}

		public async Task DeleteAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);
			_userRepository.Delete(user);
		}

		public async Task<List<User>> GetAllAsync()
		{
			return await _userRepository.GetAllAsync();
		}

		public async Task<User?> GetByIdAsync(int id)
		{
			return await _userRepository.GetByIdAsync(id);
		}

		public async Task<int> GetTotalUserCountAsync()
		{
			var allUsers = await _userRepository.GetAllAsync();
			return allUsers.Count;
		}

		public async Task UpdateAsync(User user)
		{
			var updatedUser = await _userRepository.GetByIdAsync(user.Id);
			if (updatedUser != null)
			{
				updatedUser.FullName = user.FullName;
				updatedUser.Email = user.Email;
				updatedUser.PasswordHash = user.PasswordHash;
				updatedUser.Role = user.Role;

				_userRepository.Update(updatedUser);
			}
		}
	}
}
