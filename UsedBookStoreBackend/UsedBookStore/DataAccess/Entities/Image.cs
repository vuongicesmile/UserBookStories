using System.ComponentModel.DataAnnotations.Schema;

namespace UsedBookStore.DataAccess.Entities
{
    // we created domain model  for the image upload functionally and we have a iamge

    public class Image
    {
        public Guid Id { get; set; }

        // because we are not going to store this file inside db
        // we are going to add a atribute to this which will be not mapped
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }


    }
}
