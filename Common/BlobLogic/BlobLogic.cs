using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.BlobLogic
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
            string ret = Regex.Replace(filename.Trim(), "[^A-Za-z0-9]+", "");
            ret.Replace(" ", String.Empty);
            string blobName = Guid.NewGuid().ToString() + ret;
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (FileStream fs = File.OpenRead(path))
            {
                await blobClient.UploadAsync(fs, true);
            }
            blobClient.SetAccessTier(AccessTier.Cool);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<string> Upload(IFormFile image)
        {
            string fileName = image.FileName;
            String ret = Regex.Replace(fileName.Trim(), "[^A-Za-z0-9]+", "");
            ret.Replace(" ", String.Empty);
            string blobName = Guid.NewGuid().ToString() + fileName;
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (var uploadFileStream = image.OpenReadStream())
            {
                await blobClient.UploadAsync(uploadFileStream, true);
            }
            blobClient.SetAccessTier(AccessTier.Cool);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> Delete(string url)
        {
            string blobName = new Uri(url).Segments.Last();

            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            var deleted = await blobClient.DeleteAsync();

            return !deleted.IsError;
        }
    }
}
