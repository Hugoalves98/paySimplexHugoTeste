using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Infra.Interfaces;
using System.Text.RegularExpressions;

namespace Infra.Services
{
    public class AzureBlobService : IAzureBlobService
    {

        public string FileUploadBase64(string base64Image)
        {
            string fileName = Guid.NewGuid() + ".jpg";

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=paysimplexhugo;AccountKey=aFNY0+/o0NPU28dm09Tsnj9KjeOZ+avl+9GJpYRdFQZAxs+zD/RchJPqrsy56tGGhXVePgT/2AkE+AStK2WbKg==;EndpointSuffix=core.windows.net", "paysimplesteste", fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream, new BlobHttpHeaders { ContentType = "image/png" });
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
