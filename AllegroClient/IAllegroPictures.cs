using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllegroClient
{
    interface IAllegroPictures
    {
        Task<AllegroPictureResponse> UploadAsync(byte[] binaryPicture,string token,bool useSandbox);
    }
}
