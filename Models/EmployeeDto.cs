using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models
{
	public class EmployeeDto
	{

		public string Name { get; set; } = string.Empty;

		[StringLength(9)]
		public string NationalId { get; set; } 	= string.Empty;

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { get; set; }

		public int AccountId { get; set;}
	}
}
