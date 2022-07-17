using Newtonsoft.Json;
using static JsonDemo.PostJson;

namespace JsonDemo
{
    class Program
    {
        static async Task  Main()
        {
            string? url = "https://my-json-server.typicode.com/typicode/demo/posts";
            HttpClient client = new HttpClient();

            try
            {
                var httpResponseMessage = await client.GetAsync(url);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);


                var jsonPost = JsonConvert.DeserializeObject<Post[]>(jsonResponse);
                foreach (var item in jsonPost)
                {
                    Console.WriteLine($"{item.Id} = {item.Title}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            finally
            {
                client.Dispose();
            }

        }


       
    }
}