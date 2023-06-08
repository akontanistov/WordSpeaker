using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Polsih
{
    public class WordResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("usedChars")]
        public int UsedChars { get; set; }

        [JsonPropertyName("remainChars")]
        public int RemainChars { get; set; }
    }
}
