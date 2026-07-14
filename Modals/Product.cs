using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Modals
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int IsActive { get; set; }
    }
}
