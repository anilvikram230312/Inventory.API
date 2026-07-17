using Inventory.API.DTOs;
using Inventory.API.Modals;

namespace Inventory.API.Services
{
    public interface IProductService
    {
        public Task<ApiResponse<ProductResponseDto>> AddProductAsync(ProductRequestDto product);
        public Task<ApiResponse<List<ProductResponseDto>>> GetProductsAsync();
        public Task<ApiResponse<ProductResponseDto>> GetProductByIdAsync(int productId);
        public Task<ApiResponse<ProductResponseDto>> UpdateProductAsync(int id, ProductRequestDto product);
        public Task<ApiResponse<ProductResponseDto>> DeleteProductAsync(int productId);


    }
}
