namespace Pharmacy.API.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> SaveFileAsync(IFormFile file, string uploadsFolder)
        {
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath; // Returns relative path or full path depending on usage
        }
    }
}