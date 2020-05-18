using System;
using System.Collections.Generic;
using System.Text;

namespace AllegroClient
{
    public class AllegroClientSettings
    {
        public AllegroClientSettings(AllegroEnviromentType enviromentType)
        {
            SetBaseUrl(enviromentType);
        }

        private void SetBaseUrl(AllegroEnviromentType enviromentType)
        {
            if (enviromentType.Equals(AllegroEnviromentType.Production))
            {
                BaseUrl = "https://api.allegro.pl/";
            }
            else
            {
                BaseUrl = "https://api.allegro.pl.allegrosandbox.pl/";
            }
        }

        public string BaseUrl { get; private set; }
        public string AuthToken { get; set; } = "db73a745fe8450a8c3a20514da8241e";
    }
}
