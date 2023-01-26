namespace Lumia.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(this IFormFile formFile,string root,string folder)
        {
            string filename=formFile.FileName;

            filename=filename.Length>64?filename.Substring(filename.Length-64,64):filename;

            filename=Guid.NewGuid().ToString()+filename;

            string path = Path.Combine(root, folder, filename);

            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                formFile.CopyTo(stream);    
            }

            return filename;
        }
    }
}
