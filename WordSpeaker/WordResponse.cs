using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polsih
{
    public class WordRequest
    {
        public string Engine { get; set; }
        public string VoiceId { get; set; }
        public string LanguageCode { get; set; }
        public string Text { get; set; }
        public string OutputFormat { get; set; }
        public string SampleRate { get; set; }
        public string Effect { get; set; }
        public string MasterSpeed { get; set; }
        public string MasterVolume { get; set; }
        public string MasterPitch { get; set; }

        public WordRequest() 
        {
            Engine = "neural";
            VoiceId = "ai3-pl-PL-Kacper";
            LanguageCode = "pl-PL";
            Text = "default";
            OutputFormat = "mp3";
            SampleRate = "44100";
            Effect = "default";
            MasterSpeed = "0";
            MasterVolume = "0";
            MasterPitch = "0";
        }
    }
}
