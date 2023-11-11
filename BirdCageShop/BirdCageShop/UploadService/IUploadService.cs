namespace BirdCageShop.wwwroot.UploadService
{
    public interface IUploadService
    {
        Task<string> UploadFileAsync(IFormFile imageFile);
    }
}
