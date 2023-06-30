using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MealPlanner.Logic
{
    public class BlobLogic
    {
        BlobServiceClient serviceClient;
        BlobContainerClient containerClient;

        public BlobLogic()
        {
            this.serviceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=sofs;AccountKey=cJ/DX0O6oUql1GnlaZRgcFzPGR8NN1H9PBIqOSC6zLdoKXAoUav1KfI7tiY81BUDTC1NV4+qPbxZ+AStdVg5TA==;EndpointSuffix=core.windows.net");
            this.containerClient = serviceClient.GetBlobContainerClient("pictures");
        }

        public async Task<string> Upload(string path)
        {

            string filename = Path.GetFileName(path);
            string blobName = Guid.NewGuid().ToString() + filename;
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (FileStream fs = File.OpenRead(path))
            {
                await blobClient.UploadAsync(fs, true);
            }
            blobClient.SetAccessTier(AccessTier.Cool);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
