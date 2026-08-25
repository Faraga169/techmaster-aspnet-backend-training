namespace ApiRoutingDrills.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string[] Details { get; set; } = [];
    }
}
