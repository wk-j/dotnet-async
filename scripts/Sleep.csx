
using System.Net.Http;
using System.Threading;

public async Task<String> Download4() {
    var sleep = await Task.Run(() => {
        Thread.Sleep(1000);
        return "Hello";
    });
    return await Task.Run(() => {
        Thread.Sleep(1000);
        return "Hello";
    });
}
