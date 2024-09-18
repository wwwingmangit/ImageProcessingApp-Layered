using System.IO;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BusinessLogicLayer
{
    public class ImageService
    {
        private readonly AppDbContext _context;

        public ImageService()
        {
            _context = new AppDbContext();
        }

        public async Task<ImageModel> UploadImageAsync(byte[] imageData, string fileName)
        {
            var imageModel = new ImageModel
            {
                FileName = fileName,
                OriginalImage = imageData,
                ProcessedImage = new byte[0], // Initialize with an empty byte array
                UploadedAt = DateTime.Now
            };

            _context.Images.Add(imageModel);
            await _context.SaveChangesAsync();

            return imageModel;
        }
        public async Task<ImageModel> ApplyFilterAsync(int imageId, string filterType)
        {
            var imageModel = await _context.Images.FindAsync(imageId);
            if (imageModel == null) return null;

            using (var image = Image.Load(imageModel.OriginalImage))
            {
                switch (filterType)
                {
                    case "grayscale":
                        image.Mutate(x => x.Grayscale());
                        break;
                    case "invert":
                        image.Mutate(x => x.Invert());
                        break;
                    // Add more filters as needed
                    default:
                        break;
                }

                using (var ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    imageModel.ProcessedImage = ms.ToArray();
                }
            }

            await _context.SaveChangesAsync();
            return imageModel;
        }
    }
}
