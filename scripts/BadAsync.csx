using System.Net.Http;

var client = new HttpClient();

public String DownloadStringV4(String url) {
    return Task.Run(async () => {
        var request = await client.GetAsync(url);
        var download = await request.Content.ReadAsStringAsync();
        return download;
    }).Result;
}

public String DownloadStringV5(String url) {
    // REALLY REALLY BAD CODE,
    // guaranteed deadlock
    return Task.Run(() => {
        var request = client.GetAsync(url).Result;
        var download = request.Content.ReadAsStringAsync().Result;
        return download;
    }).Result;
}

var rs = DownloadStringV5("https://github.com/wk-j");


Console.WriteLine(rs);
