namespace ApiRoutingDrills.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int Code { get; set; } 
        public string[] Details { get; set; } = [];
    }
}
