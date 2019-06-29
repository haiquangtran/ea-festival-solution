using System;
using System.Collections.Generic;
using System.Text;

namespace EA.Festival.ApplicationCore
{
    public class AppConfig
    {
        public string MusicFestivalApiBaseAddress { get; set; }
        public string MusicFestivalApiGetFestivalEndpointUri { get; set; }
        public int ApiTimeoutSeconds { get; set; }
    }
}
