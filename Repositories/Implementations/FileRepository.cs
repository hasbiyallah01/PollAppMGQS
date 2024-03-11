namespace MgqsPollApp.Repositories.Implementations
{
    public class FileRepository
    {
        private readonly IWebHostEnvironment _host;

        public FileRepository(IWebHostEnvironment host)
        {
            _host = host;
        }
        public string Upload(IFormFile file)
        {
            var fileType = file.ContentType.Split('/')[1];
            string? folderName;
            if (fileType == "mp3" || fileType == "wav")
            {
                folderName = "Musics";
            }
            else if (fileType == "mp4" || fileType == "mov" || fileType == "hd")
            {
                folderName = "Videos";
            }
            else
            {
                folderName = "Files";
            }

            var path = Path.Combine(_host.WebRootPath, folderName);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var filename = $"{Guid.NewGuid()}.{fileType}";
            var filePath = Path.Combine(path, filename);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return filePath;
        }
    }
}
