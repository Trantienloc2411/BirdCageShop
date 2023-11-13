namespace BirdCageShop.wwwroot.UploadService
{
    public class LocalFileUploadService : IUploadService
    {

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;
        public LocalFileUploadService(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }
        public async Task<string> UploadFileAsync(IFormFile imageFile)
        {
            var path = environment.WebRootPath;
            var filePath = "Content/Image/" + imageFile.FileName;
            var fullPath = Path.Combine(path, filePath);
            //var filePath = Path.Combine(environment.ContentRootPath, @"wwwroot\images", imageFile.FileName);
            using var fileStream = new FileStream(fullPath, FileMode.Create);
            await imageFile.CopyToAsync(fileStream);
            return filePath;
        }
    }
}
