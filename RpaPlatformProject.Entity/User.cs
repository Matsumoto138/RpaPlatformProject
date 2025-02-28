namespace RpaPlatformProject.Entity
{
	public class User
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; } // "Admin", "User"

		public ICollection<Robot> Robots { get; set; } // Kullanıcının robotları
	}
}
