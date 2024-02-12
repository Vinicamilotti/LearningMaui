using HelloTux.Model;
using System.Net.Http.Json;

namespace HelloTux.Services;

public class MonkeyService
{
    List<Monkey> monkeyList = new();
    HttpClient httpClient;

    public MonkeyService()
    {
        this.httpClient = new HttpClient();

    }
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
        }
        return monkeyList;

    }
}