using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
	public class Student
	{
		[Key]
		public Guid Id { get; set; }

		[Display(Name = "Student Name")]
		[DataType("varchar")]
		[MaxLength(40)]
		[Required]
		public string Name { get; set; } = null!;


		[DataType(DataType.EmailAddress)]
		[MaxLength(100)]
		[Required]
		public string Email { get; set; } = null!;


		[DataType(DataType.Password)]
		[MaxLength(100)]
		[Required]
		public string Password { get; set; } = null!;


	}
}
