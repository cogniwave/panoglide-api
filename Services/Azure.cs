using Azure.Storage.Blobs;
using Azure.Storage.Sas;

using DotNetEnv;

namespace Panoglide.Services.Azure
{
    public class AzureService
    {
        public static string GenSasToken()
        {

            string containerName = Environment.GetEnvironmentVariable("AZURE_CONTAINER_NAME");

            // Create a BlobSasBuilder to define the SAS token settings for the container
            BlobSasBuilder sasBuilder = new BlobSasBuilder {
                BlobContainerName = containerName,
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(10) // Set the expiration time for the SAS token
            };

            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

            // Generate the SAS URI for the container
            return new BlobServiceClient(Environment.GetEnvironmentVariable("AZURE_CONNECTION_STRING"))
                .GetBlobContainerClient(containerName)
                .GenerateSasUri(sasBuilder)
                .ToString();

        }
    }
}
