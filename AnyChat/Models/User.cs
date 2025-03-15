using System.ComponentModel.DataAnnotations;

namespace AnyChat.Models;

class User
{
	public int Id { get; set; }
	required public string Name { get; set; }

	[DataType(DataType.Password)]
	required public string Password { get; set; }
	required public string Email { get; set; }
	public bool IsOnline { get; set; }
	public DateTime LastLogin { get; set; }
}
