using Microsoft.AspNetCore.Http;

namespace WebJar.Application.Extention
{
    public static class FileUpload
    {
        /// <summary>
        /// This methode upload photo and return path of the image.
        /// </summary>
        public static string UploadImage(IFormFile file, string placeFile)
        {
            var date = ConvertDate.GetMonthAndYear(DateTime.Now);
            string folder = $@"wwwroot\Images\{placeFile}\{date}\";
            var uploadsRootFolder = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }

            string fileName = DateTime.Now.Ticks.ToString() + "-" + file.FileName;
            string filePath = Path.Combine(uploadsRootFolder, fileName);
            using (var FileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(FileStream);
            }
            return (placeFile + "/" + date + "/" + fileName);
        }
        public static string UploadImages(IEnumerable<IFormFile> files, string placeFile)
        {
            var date = ConvertDate.GetMonthAndYear(DateTime.Now);
            string folder = $@"wwwroot\Images\{placeFile}\{date}\";
            var uploadsRootFolder = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            string imagesPath = "";
            foreach (var file in files)
            {
                string fileName = DateTime.Now.Ticks.ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var FileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(FileStream);
                }
                imagesPath += placeFile + "/" + date + "/" + fileName + ",";
            }
            return imagesPath;
        }
    }
}
