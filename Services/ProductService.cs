using Inventory.API.Data;
using Inventory.API.DTOs;
using Inventory.API.Modals;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services
{
    public class ProductService : IProductService
    {
        // private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext Context)
        {
            //IConfiguration configuration,
            // this._configuration = configuration;
            this._context = Context;

        }
        public async Task<ApiResponse<ProductResponseDto>> AddProductAsync(ProductRequestDto product)
        {
            Product productToAdd = new Product();
            ApiResponse<ProductResponseDto> apiResponse = new ApiResponse<ProductResponseDto>();
            try
            {
                if (product != null)
                {
                    productToAdd.ProductName = product.ProductName;
                    productToAdd.Description = product.Description;
                    productToAdd.Price = product.Price;
                    productToAdd.Quantity = product.Quantity;
                    productToAdd.IsActive = product.IsActive;
                    productToAdd.CreatedDate = DateTime.UtcNow;
                    productToAdd.UpdatedDate = DateTime.UtcNow;

                    var result = await _context.AddAsync(productToAdd);
                    if (result != null)
                    {
                        apiResponse.IsError = false;
                        apiResponse.StatusCode = "201";
                        apiResponse.StatusMessage = "Recored Added Successfully";
                        //apiResponse.Data.Add(result);

                        apiResponse.Result = new ProductResponseDto
                        {
                            ProductId = productToAdd.ProductId,
                            ProductName = productToAdd.ProductName,
                            Description = productToAdd.Description,
                            Price = productToAdd.Price,
                            Quantity = productToAdd.Quantity,
                            IsActive = productToAdd.IsActive
                        };
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        apiResponse.IsError = true;
                        apiResponse.StatusCode = "102";
                        apiResponse.StatusMessage = "Recored Added Failed";
                        apiResponse.Result = null;

                    }

                }
                else
                {
                    apiResponse.IsError = true;
                    apiResponse.StatusCode = "102";
                    apiResponse.StatusMessage = "Recored Added Failed";
                    apiResponse.Result = null;
                }
            }
            catch (Exception ex)
            {
                apiResponse.IsError = true;
                apiResponse.StatusCode = "102";
                apiResponse.StatusMessage = ex.Message;
                apiResponse.Result = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse<List<ProductResponseDto>>> GetProductsAsync()
        {
            var apiResponse = new ApiResponse<List<ProductResponseDto>>();

            try
            {
                var productList = await _context.Products.ToListAsync();

                if (productList == null || !productList.Any())
                {
                    apiResponse.IsError = true;
                    apiResponse.StatusCode = "404";
                    apiResponse.StatusMessage = "No products found.";
                    apiResponse.Result = new List<ProductResponseDto>();

                    return apiResponse;
                }

                var productDtoList = productList.Select(product => new ProductResponseDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    IsActive = product.IsActive
                }).ToList();

                apiResponse.IsError = false;
                apiResponse.StatusCode = "200";
                apiResponse.StatusMessage = "Products fetched successfully.";
                apiResponse.Result = productDtoList;

                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.IsError = true;
                apiResponse.StatusCode = "500";
                apiResponse.StatusMessage = ex.Message;
                apiResponse.Result = new List<ProductResponseDto>();

                return apiResponse;
            }
        }

        public async Task<ApiResponse<ProductResponseDto>> GetProductByIdAsync(int productId)
        {
            var apiResponse = new ApiResponse<ProductResponseDto>();

            try
            {
                var singleProduct = await _context.Products.Where(x=>x.ProductId == productId).FirstOrDefaultAsync();

                if (singleProduct == null)
                {
                    apiResponse.IsError = true;
                    apiResponse.StatusCode = "404";
                    apiResponse.StatusMessage = "No products found.";
                    apiResponse.Result = new ProductResponseDto();

                    return apiResponse;
                }


                apiResponse.IsError = false;
                apiResponse.StatusCode = "200";
                apiResponse.StatusMessage = "Products fetched successfully.";
                apiResponse.Result = new ProductResponseDto()
                {
                    ProductId = singleProduct.ProductId,
                    ProductName = singleProduct.ProductName,
                    Price = singleProduct.Price,
                    Quantity = singleProduct.Quantity,
                    Description = singleProduct.Description,
                    IsActive = singleProduct.IsActive,
                };

                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.IsError = true;
                apiResponse.StatusCode = "500";
                apiResponse.StatusMessage = ex.Message;
                apiResponse.Result = new ProductResponseDto();

                return apiResponse;
            }
        }
    }
}
