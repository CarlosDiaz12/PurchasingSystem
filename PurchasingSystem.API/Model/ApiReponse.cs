namespace PurchasingSystem.API.Model
{
    public class ApiReponse
    {
        public ApiReponse(dynamic data, bool success = true)
        {
            Data = data;
            Success = success;
        }

        public ApiReponse(bool success, string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = success;
        }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; } = true;
        public dynamic Data { get; set; }
    }
}
