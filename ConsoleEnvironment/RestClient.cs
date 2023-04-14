using System.Text;
using System.Text.Encodings.Web;
using ConsoleEnvironment.Models;
using Newtonsoft.Json;

namespace ConsoleEnvironment;

public class RestClient: IDisposable
{
    private readonly Settings _settings;
    private readonly HttpClient _httpClient;

    public RestClient(Settings settings)
    {
        _settings = settings;
        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(6),
            BaseAddress = new Uri(_settings.Server?.Host??"http://localhost:5000")
        };
    }

    public async Task PostResult(SortingResult result)
    {
        var json = JsonConvert.SerializeObject(result);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        using var request = new HttpRequestMessage(HttpMethod.Post, _settings.Server?.SendUrl??"/api/sorting-result")
        {
            Content = content
        };

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Host response with {response.StatusCode} status code.");
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}