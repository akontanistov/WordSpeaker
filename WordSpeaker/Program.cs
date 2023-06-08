using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Polsih
{
    internal class Program
    {
        static HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            string url = "https://developer.voicemaker.in/voice/api";
            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", "xxxxxxxxxxxx-xxxxxxxx-xxxxxxxxx-xxxxxxxxxxxx");

            WordRequest wordRequest = new WordRequest();

            Console.WriteLine("Start!");

            Directory.CreateDirectory("output");

            foreach (var word in Words.words) 
            {
                wordRequest.Text= word;
                var payload = JsonSerializer.Serialize(wordRequest);
                HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
                using var httpResponse = await httpClient.PostAsync(url, httpContent);
                string responseText = await httpResponse.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<WordResponse>(responseText);

                if (response != null)
                {
                    try
                    {
                        using var stream = await httpClient.GetStreamAsync(response.Path);
                        using var fileStream = new FileStream($"output/{wordRequest.Text}.mp3", FileMode.OpenOrCreate);
                        await stream.CopyToAsync(fileStream);
                        Console.WriteLine($"Word: '{word}' download success.");
                    }
                    catch
                    {
                        Console.WriteLine($"Word: '{word}' download error.");
                    }
                }
                else
                {
                    Console.WriteLine($"Word: '{word}' request error.");
                }
            }

            Console.WriteLine("End!");
        }
    }
}