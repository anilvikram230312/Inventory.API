using System.ComponentModel.DataAnnotations;

namespace Inventory.API.DTOs
{
    public class ProductRequestDto
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int IsActive { get; set; }
    }
}
