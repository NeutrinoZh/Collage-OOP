using System.Net.Http;

class Program {
    static readonly HttpClient client = new HttpClient();

    static async Task Main() {
        try	 {
            HttpResponseMessage response = await client.GetAsync("http://example.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        } catch (HttpRequestException e) {
            Console.WriteLine("\nException Caught!");	
            Console.WriteLine("Message :{0} ",e.Message);
        }

        try {
            var values = new Dictionary<string, string> {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync("https://httpbin.org/post", content);  
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        } catch (HttpRequestException e) {
            Console.WriteLine("\nException Caught!");	
            Console.WriteLine("Message :{0} ",e.Message);
        }
    }
}