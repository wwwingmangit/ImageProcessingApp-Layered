using System;

namespace Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] OriginalImage { get; set; }
        public byte[] ProcessedImage { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
