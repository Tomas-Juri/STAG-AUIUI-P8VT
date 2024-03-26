using Application.Backend.Api.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/photos")]
public class PhotosController() : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Get([FromForm] PhotosRequest request)
    {
        // Keep this secret
        var connectionString = "secret---string";

        // Connect to storage account
        var blobServiceClient = new BlobServiceClient(connectionString);

        // Create container for blobs
        var containerName = "photos";
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

        // Get a reference to a blob
        var fileName = $"photo-{Guid.NewGuid()}{Path.GetExtension(request.FileName)}";
        var blobClient = containerClient.GetBlobClient(fileName);
        
        // Upload data from the file, overwrite the blob if it already exists (true param)
        await using var stream = request.File.OpenReadStream();
        await blobClient.UploadAsync(stream, true);
            
        return Created(blobClient.Uri, null);
        
    }
}