using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using EventsSystem_iThome.ViewModels;

namespace EventsSystem_iThome.Services
{
    public static class EventsImageUploadService
    {
        public static (IFormFile IFormFile, string FileName, string FilePath) UploadedFile(EventsCreateViewModel model, IWebHostEnvironment webHostEnvironment)
        {
            string UploadFolder = Path.Combine(webHostEnvironment.WebRootPath, @"images\Upload\Events");
            string FileName = string.Empty;
            string FilePath = string.Empty;

            if (model.FormEventsImage != null)
            {
                if (!Directory.Exists(UploadFolder))      // 檢查 wwwroot 是否有上傳資料夾
                {
                    Directory.CreateDirectory(UploadFolder);
                }
                FileName = Guid.NewGuid().ToString() + "_" + model.FormEventsImage.FileName;
                FilePath = Path.Combine(UploadFolder, FileName);

                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    model.FormEventsImage.CopyTo(fileStream);
                }
            }

            return (model.FormEventsImage, FileName, FilePath);
        }
    }
}
