namespace BindrAPI.Models.DTOs
{
    public class LocationInfoDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime CapturedAt { get; set; }
    }
}
