using Inventory.API.DTOs;
using Inventory.API.Modals;

namespace Inventory.API.Services
{
    public interface IProductService
    {
        public Task<ApiResponse<ProductResponseDto>> AddProductAsync(ProductRequestDto product);
        public Task<ApiResponse<List<ProductResponseDto>>> GetProductsAsync();
        Task<ApiResponse<ProductResponseDto>> GetProductByIdAsync(int productId);


    }
}
