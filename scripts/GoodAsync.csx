#! "netcoreapp2.0"

using System.Net.Http;
using System.Threading;

var client = new HttpClient();

// good
public async Task<String> Download(String url) {
    var request = await client.GetAsync(url);
    var download = await request.Content.ReadAsStringAsync();
    return download;
}

// yeah
public Task<String> Download2(String url) {
    var reqeust = client.GetAsync(url);
    var download = reqeust.ContinueWith(http => http.Result.Content.ReadAsStringAsync());
    return download.Unwrap();
}

// work in some context
public String Download3(String url) {
    var request = client.GetAsync(url).Result;
    var download = request.Content.ReadAsStringAsync().Result;
    return download;
}

var url = "https://github.com/wk-j";

// var rs = Download2("https://microsoft.com").GetAwaiter().GetResult();
// Console.WriteLine(rs);

var rs = Download3(url);
Console.WriteLine(rs);