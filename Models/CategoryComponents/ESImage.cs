using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE.Models.CategoryComponents
{
    public class ESImage
    {
        [Key]
        public long ESImageId { get; set; }

        [MaxLength(128)]
        public string ImageMimeType { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] ImageData { get; set; }
    }
}
