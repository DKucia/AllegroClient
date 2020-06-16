namespace AllegroClient
{
    public class TokenResponse
    {
        [Newtonsoft.Json.JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [Newtonsoft.Json.JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int ExpireTime { get; set; }
    }
}
