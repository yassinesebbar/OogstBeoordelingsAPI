﻿using System.Drawing;
using System.Drawing.Imaging;

namespace OogstBeoordelingsAPI.IServices
{
    public interface IImageService
    {
        public Boolean StoreImage(IFormFile fileModel, string imageName);

        public Task<Byte[]> GetFile(string imageName);
    }
}
