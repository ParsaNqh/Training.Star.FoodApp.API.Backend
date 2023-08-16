namespace Star.FoodApp.API.Security.DTOs
{
    public class LoginResultDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
    }
}
