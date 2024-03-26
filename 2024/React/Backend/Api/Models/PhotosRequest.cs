namespace Application.Backend.Api.Models;

public class PhotosRequest
{
    public required IFormFile File { get; set; }
    
    public required string FileName { get; set; }
}