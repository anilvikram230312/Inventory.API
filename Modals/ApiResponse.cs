namespace Inventory.API.Modals
{
    public class ApiResponse<T>
    {
        public bool IsError { get; set; }
        public string? StatusCode { get; set; }
        //public List<string> StatusMessage { get; set; } = new List<string>();
        public string? StatusMessage { get; set; }
       //public List<T?> Data { get; set; } = new List<T?>();
        public T? Result { get; set; } 
    }
}
