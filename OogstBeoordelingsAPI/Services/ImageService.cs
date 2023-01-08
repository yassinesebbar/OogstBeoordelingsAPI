using OogstBeoordelingsAPI.IServices;
using System.Drawing;

namespace OogstBeoordelingsAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly string imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Upoad\\images");

        public async Task<Byte[]> GetFile(string filename)
        {
            return await System.IO.File.ReadAllBytesAsync(Path.Combine(imageFolder, filename));

        }

        public bool StoreImage(IFormFile fileModel, string fileName)
        {
            try
            {
                if (!ImageFolderExist(imageFolder)) CreateImageFolderDirectory(imageFolder);
                string filePath = Path.Combine(imageFolder, fileName);
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    fileModel.CopyTo(fileStream);
                    fileStream.Flush();
                }

                return true;
            }
            catch (Exception) { return false;}
        }

        private bool ImageFolderExist(string folder) => Directory.Exists(folder);
        private void CreateImageFolderDirectory(string newFolder) => Directory.CreateDirectory(newFolder);

      
    }
}
