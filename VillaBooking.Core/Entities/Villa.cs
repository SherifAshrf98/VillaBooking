using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBooking.Core.Entities
{
	public class Villa
	{
		public int Id { get; set; }
		[DisplayName("Villa Name")]
		[MaxLength(50)]
		public string Name { get; set; }
		public string? Description { get; set; }
		[DisplayName("Price Per Night")]
		[Range(10, 10000, ErrorMessage = "Villa Price Must Be Between 10 and 10000 $")]
		public double Price { get; set; }
		[Range(1, 6000)]
		public int Sqft { get; set; }
		[Range(1, 10, ErrorMessage = "Occupancy Must Be Between 1 and 10")]
		public int Occupancy { get; set; }
		[DisplayName("Image Url")]
		public string? ImageUrl { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
