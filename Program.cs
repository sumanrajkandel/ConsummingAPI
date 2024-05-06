// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;



using (HttpClient client = new HttpClient())
{
    string json = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/age-counting");

    var obj = JObject.Parse(json);

    var data = obj["data"]!.ToString();

    var keyValuePairs = data.Split(',').Select(x => x.Trim()).ToList();

    int count = 0;

    foreach (var keyValue in keyValuePairs)
    {
        var age = keyValue.Split('=')[1].Trim();
        if (int.TryParse(age, out int numericAge) && numericAge == 1)
        {
            count++;
        }
    }
    Console.WriteLine(count);

}