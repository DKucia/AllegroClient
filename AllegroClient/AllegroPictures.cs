using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AllegroClient
{
    public class AllegroPictures : IAllegroPictures
    {
        private const string _allegroUploadUrl = "https://upload.allegro.pl/sale/images";
        private const string _allegroSandboxUploadUrl = "https://upload.allegro.pl.allegrosandbox.pl/sale/images";

        public async Task<AllegroPictureResponse> UploadAsync(byte[] binaryPicture, string token, bool useSandbox)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
            ByteArrayContent byteContent = new ByteArrayContent(binaryPicture);
            var response = await client.PostAsync(useSandbox ? _allegroSandboxUploadUrl : _allegroUploadUrl, byteContent);
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.UnsupportedMediaType)
                {
                    throw new AllegroException("Nieodpowiedni typ obrazu", 415);
                }
                if ((int)response.StatusCode == 413)
                {
                    throw new AllegroException("Za duży obrazek ", 413);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new AllegroException("unauthorized", 401);
                }
                throw new AllegroException(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
            }
            return JsonConvert.DeserializeObject<AllegroPictureResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
