#! "netcoreapp2.0"

using System.Net.Http;

public async Task<String> DownloadStringV1(String url) {
    var client = new HttpClient();
    var request = await client.GetAsync(url);
    var download = await request.Content.ReadAsStringAsync();
    return download;
}

var rs = DownloadStringV1("https://microsoft.com").GetAwaiter().GetResult();
Console.WriteLine(rs);