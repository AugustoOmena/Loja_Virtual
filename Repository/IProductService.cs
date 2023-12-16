using Azure.Storage.Blobs;

namespace LojaVirtual.Repository
{
    public interface IProductService
    {
        string DeleteBlob(string name, string conteinerName);
        BlobContainerClient GetContainerClient(string containerName);
        Task<string> UploadBlobAsync(IFormFile file, string containderName);
    }
}
