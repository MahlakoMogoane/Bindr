using System.ComponentModel.DataAnnotations;

namespace BindrAPI.Models.Entities 
{
    public class LocationInfo
    {
        [Key]
        public Guid locationID { get; set; }                    
        public double Latitude { get; set; }            
        public double Longitude { get; set; }           
        public string? City { get; set; }               
        public string? Country { get; set; }            
        public string? IPAddress { get; set; }          
        public DateTime CapturedAt { get; set; }        
    }
}