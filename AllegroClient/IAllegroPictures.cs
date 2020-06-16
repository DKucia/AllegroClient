using System.Threading.Tasks;

namespace AllegroClient
{
    public interface IAllegroPictures
    {
        Task<AllegroPictureResponse> UploadAsync(byte[] binaryPicture, string token, bool useSandbox);
    }
}
